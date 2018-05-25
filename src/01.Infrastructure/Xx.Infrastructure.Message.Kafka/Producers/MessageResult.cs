using System;
using System.Collections.Generic;
using System.Linq;

namespace Xx.Infrastructure.Message.Kafka.Producers {
    public class MessageResult {
        public MessageResult() {
            Errors = new List<MessageResultItem>();
        }

        public bool Successed => Errors.Count == 0;

        public IList<MessageResultItem> Errors { get; set; }

        public string ErrorMessage => string.Join(",", Errors.Select(e => e.ErrorMessage));


    }

    public class MessageResultItem {
        public void Add(string errorCode, string errorReson) {
            Code = errorCode;
            ErrorMessage = errorReson;
        }

        public string ErrorMessage { get; set; }

        public string Code { get; set; }
    }

    public static class MessageResultExtensions {
        public static void Add(this IList<MessageResultItem> itemList, string errorCode, string errorMessage) {
            itemList.Add(new MessageResultItem() {
                Code = errorCode,
                ErrorMessage = errorMessage
            });
        }

        public static void Add(this IList<MessageResultItem> itemList, Exception exception) {
            itemList.Add(new MessageResultItem {
                Code = "Exception",
                ErrorMessage = exception.InnerException?.Message ?? exception.Message
            });
        }
    }
}