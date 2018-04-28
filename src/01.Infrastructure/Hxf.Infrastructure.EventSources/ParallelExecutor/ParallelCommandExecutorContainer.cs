using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hxf.Infrastructure.Data;
using Hxf.Infrastructure.EventSources.Ioc;
using Hxf.Infrastructure.Exceptions;
using Hxf.Infrastructure.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Hxf.Infrastructure.EventSources.ParalleExecutor {
    public class ParallelCommandExecutorContainer : IParallelCommandExecutorContainer {
        private List<ParallelCommandExecutorConfig> _executorConfigs;
        private IEntityframeworkContext _dbContext;
        private IHttpContextAccessor _httpContextAccessor;

        public CommandContext CommandContext { get; }

        public ParallelCommandExecutorContainer(
            IEntityframeworkContext efContext,
            IHttpContextAccessor httpContextAccessor) {
            _dbContext = efContext;
            _httpContextAccessor = httpContextAccessor;
            _executorConfigs = new List<ParallelCommandExecutorConfig>();
            CommandContext = new CommandContext();
        }

        public async Task<JsonResponse> DoExecutorParallel(ICommand command) {
            var jsonResponse = new JsonResponse();

            try {
                await InternalDoExecutor(command);
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

            return jsonResponse;;
        }

        public IParallelCommandExecutorContainer RegisterExecutor<TExecutor>()
        where TExecutor : class, IParallelCommandExecutor {
            var executor = _httpContextAccessor.HttpContext.RequestServices.GetService<TExecutor>();
            var executorConfig = new ParallelCommandExecutorConfig(executor);
            CheckExecutorConfigDuplicate(executorConfig);
            _executorConfigs.Add(executorConfig);
            return this;
        }

        private void CheckExecutorConfigDuplicate(ParallelCommandExecutorConfig config) {
            var existsExecutorConfigs = _executorConfigs.Select(e => e.Name);
            if (existsExecutorConfigs.Contains(config.Name)) {
                throw new DupilicateExecutorException();
            }
        }

        private async Task InternalDoExecutor(ICommand command) {
            var tasks = new List<Task>(_executorConfigs.Count);
            _executorConfigs.ForEach(c => tasks.Add(Task.Run(async() => await c.Executor.Excute(command))));
            await Task.WhenAll(tasks);
        }
    }
}