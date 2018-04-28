using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hxf.Infrastructure.Data;
using Hxf.Infrastructure.EventSources.Ioc;
using Hxf.Infrastructure.Exceptions;
using Hxf.Infrastructure.Validation;
using Serilog;

namespace Hxf.Infrastructure.EventSources.ChainExecutor {
    public class CommandExecutorContainer : ICommandExecutorContainer {
        private List<CommandExecutorConfig> _executorConfigs;
        private int _pos = 0;
        private IEntityframeworkContext _dbContext;

        public CommandContext CommandContext { get; }

        public CommandExecutorContainer() {
            _executorConfigs = new List<CommandExecutorConfig>();
            CommandContext = new CommandContext();
        }
        public async Task<JsonResponse> DoExecutor(ICommand command) {
            var jsonResponse = new JsonResponse();

            try {
                await InternalDoNextExecutor(command);
                 _executorConfigs.Clear();
            } catch (DomainException ex) {
                jsonResponse.Errors.AddErrors(ex.ValidationErrors.ErrorItems);
            } catch (AggregateException ex) {
                Log.Error(ex.Message);
            } catch (Exception ex) {
                Log.Error(ex.Message);
                var errorMessage = ex.InnerException == null ? ex.Message : ex.InnerException?.Message;
                jsonResponse.Errors.AddSystemError("IsAlter", errorMessage);
                jsonResponse.SystemErrorMessage = errorMessage;

            }

            return jsonResponse;
        }

        public async Task<JsonResponse> DoExecutorTransaction(ICommand command) {
            var jsonResponse = new JsonResponse();
            var db = _dbContext as EntityframeworkContext;
            using(var transaction = db.Database.BeginTransaction()) {
                try {
                    await InternalDoNextExecutor(command);
                    // db.Commit();
                    transaction.Commit();
                     _executorConfigs.Clear();
                } catch (DomainException ex) {
                    jsonResponse.Errors.AddErrors(ex.ValidationErrors.ErrorItems);
                } catch (AggregateException ex) {
                    Log.Error(ex.Message);
                } catch (Exception ex) {
                    Log.Error(ex.Message);
                    var errorMessage = ex.InnerException == null ? ex.Message : ex.InnerException?.Message;
                    jsonResponse.Errors.AddSystemError("IsAlter", errorMessage);
                    jsonResponse.SystemErrorMessage = errorMessage;
                }

                return jsonResponse;
            }
        }

        public ICommandExecutorContainer RegisterExecutor<TExecutor>()
        where TExecutor : class, ICommandExecutor {
            var executor = IocContainer.Resolve<TExecutor>();
            var executorConfig = new CommandExecutorConfig(executor);
            CheckExecutorConfigDuplicate(executorConfig);
            _executorConfigs.Add(executorConfig);
            if (_dbContext == null) {
                _dbContext = executor.DbContext;
            }

            return this;
        }

        private void CheckExecutorConfigDuplicate(CommandExecutorConfig config) {
            var existsExecutorConfigs = _executorConfigs.Select(e => e.Name);
            if (existsExecutorConfigs.Contains(config.Name)) {
                throw new DupilicateExecutorException();
            }
        }

        private async Task InternalDoNextExecutor(ICommand command) {

            if (_pos < _executorConfigs.Count) {
                NextExecutor = _executorConfigs[_pos++];
                HasNextExecutor = NextExecutor != null;
                if (!HasNextExecutor) {
                    await Task.FromResult(0);
                }
                await NextExecutor.Executor.Excute(command, CommandContext);
                await InternalDoNextExecutor(command);
            }
        }

        private bool HasNextExecutor {
            get;
            set;
        }

        private CommandExecutorConfig NextExecutor {
            get;
            set;
        }

    }
}