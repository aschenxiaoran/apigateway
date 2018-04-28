using System;
using System.Linq.Expressions;
using Hxf.Infrastructure.Entities;
using Hxf.Infrastructure.Entities.Companys;
using Hxf.Infrastructure.Enums;
using Hxf.Infrastructure.Extensions;
using Hxf.Infrastructure.Specifications;

namespace Hxf.Infrastructure.Paging {
    public abstract class PageQueryDto : IPageQueryDto {

        public PageQueryDto() {
            PageIndex = PaginationValueConstant.PageIndex;
            PageSize = PaginationValueConstant.PageSize;
        }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int MemId { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string SelectedType { get; set; }
        public string SelectedValue { get; set; }

        public virtual void InitCurrentLoginUser(ILoginUser loginUser) {
            UserId = loginUser.UserId;
            MemId = loginUser.MemId;
        }
    }

    public abstract class PageQueryRequest : PageQueryDto {

        public PageQueryRequest() {
            Status = 1;
        }
        public SystemConfigResponse SystemConfig { get; set; }

        public int? Status { get; set; }

    }

    public interface IPageQueryDto : IQueryDto {
        int PageIndex { get; set; }

        int PageSize { get; set; }

        int MemId { get; set; }
    }

    public abstract class QueryDto : IQueryDto {
        /// <summary>
        /// ����˾ID
        /// </summary>
        public int MemId { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string QueryKey { get; set; }

    }

    public abstract class QueryKeyDto<T> : IQueryDto where T : IAggregateRoot, IPinYinRoot {
        public int MemId { get; set; }

        public string QueryKey { get; set; }

        public Expression<Func<T, bool>> GetExpression() {

            Expression<Func<T, bool>> customerExpressionAnd = m => m.Status >= 0;
            if (QueryKey.IsNullOrWhiteSpace()) {
                return customerExpressionAnd;
            }

            Expression<Func<T, bool>> customerExpression = m => m.Status > 0;
            // customerExpression = customerExpression.OrNotNull(m => m.Code.Contains(QueryKey), QueryKey);
            // customerExpression = customerExpression.OrNotNull(m => m.FirstWord == QueryKey, QueryKey);
            var expression = customerExpressionAnd.And(customerExpression);
            return expression;
        }
    }

    public interface IQueryDto {

    }

    public interface IReportQueryDto {
        /// <summary>
        /// ʱ������
        /// </summary>
        ReportDemensionForTime TimeDemensionType { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        TimeDemensionSummaryType DateType { get; set; }
    }

    public abstract class ReportQueryDto : PageQueryDto, IReportQueryDto {
        /// <summary>
        /// ʱ��ά��
        /// </summary>
        public ReportDemensionForTime TimeDemensionType {
            get;
            set;
        }

        /// <summary>
        /// ʱ��ά��ֵ
        /// </summary>
        public string TimeDemensionTypeValue {
            get;
            set;
        }

        /// <summary>
        /// ��������
        /// </summary>
        public TimeDemensionSummaryType DateType {
            get;
            set;
        }

        /// <summary>
        /// ��������ֵ����
        /// </summary>
        public string DateTypeValue {
            get;
            set;
        }
    }
}