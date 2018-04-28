using System.Collections.Generic;
using System.Text;
using Hxf.Infrastructure.Paging;

namespace Hxf.Infrastructure.Validation {
    public class JsonResponse : ViewResponse, IJsonResponse {

        public IValidationErrors Errors { get; set; }

        public string SystemErrorMessage { get; set; }

        public bool IsValid => Errors == null || Errors.IsValid;

        public string ErrorProperty {
            get {
                if (Errors != null && !IsValid) {
                    foreach (ValidationErrorItem validationErrorItem in Errors.ErrorItems) {
                        if (validationErrorItem.PropertyName == ErrorMessage.IsAlter) {
                            return ErrorMessage.IsAlter;
                        }
                    }
                }
                return string.Empty;
            }
        }

        public JsonResponse() {
            Errors = new ValidationErrors();
        }

        public string ErrorMessages {
            get {
                var errorMessages = new StringBuilder();
                if (Errors != null && !IsValid) {
                    foreach (ValidationErrorItem validationErrorItem in Errors.ErrorItems) {
                        errorMessages.AppendFormat("{0}", validationErrorItem.ErrorMessage);
                    }
                }
                return errorMessages.ToString();
            }
        }

        public string RedirectUrl { get; set; }

        public int EntityId { get; set; }

        public string Code { get; set; }

        public static JsonResponse Create(bool isValid) {
            var jsonResponse = new JsonResponse();
            if (!isValid) {
                jsonResponse.Errors.AddSystemError();
            }
            return jsonResponse;
        }

        public static JsonResponse CreateOpenBill(bool isValid) {
            var jsonResponse = new JsonResponse();
            if (!isValid) {
                jsonResponse.Errors.AddError(ErrorMessage.IsAlter, ErrorMessage.UnOpenBill, null, true);
            }
            return jsonResponse;
        }

        public static JsonResponse CreateUnAuthorize(string code = null) {
            var jsonResponse = new JsonResponse();

            if (string.IsNullOrWhiteSpace(code)) {
                jsonResponse.Errors.AddError(ErrorMessage.IsAlter, ErrorMessage.UnAuthorize, null, true);
            } else {
                jsonResponse.Errors.AddError(ErrorMessage.IsAlter, $"{ErrorMessage.UnAuthorize}，权限码：{code}", null, true);
            }

            return jsonResponse;
        }
    }

    public interface IJsonResponse {
        IValidationErrors Errors { get; set; }

        string RedirectUrl { get; set; }

        bool IsValid { get; }

        int EntityId { get; set; }

        string Code { get; set; }
    }
}