using Safety.Domain.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;
using System.Text.Json;

namespace Safety.Web.Extensions
{
    public static class ServiceResultExtension
    {

        public static string Serialize(this ServiceResult serviceResult)
        {
            return JsonSerializer.Serialize(serviceResult.Errors);
        }
        public static ServiceResult Deserialize(this ServiceResult serviceResult, string errorMessage)
        {
            IList<ServiceResultError> errors = JsonSerializer.Deserialize<IList<ServiceResultError>>(errorMessage);
            serviceResult.AddErrors(errors);
            return serviceResult;
        }
        public static string ToHtml(this ServiceResult serviceResult)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var error in serviceResult.Errors)
            {
                stringBuilder.AppendLine("<ul>");
                if (string.IsNullOrWhiteSpace(error.PropertyName))
                {
                    stringBuilder.AppendLine("<li>");
                    stringBuilder.AppendLine(error.ErrorMessage);
                    stringBuilder.AppendLine("</li>");
                }
                else
                {
                    stringBuilder.AppendLine("<li>");
                    stringBuilder.AppendLine(error.PropertyName + ": " + error.ErrorMessage);
                    stringBuilder.AppendLine("</li>");
                }
                stringBuilder.AppendLine("</ul>");
            }

            return stringBuilder.ToString();
        }
        public static void ToModelStateDictionary(this ServiceResult serviceResult, ModelStateDictionary modelStateDictionary)
        {
            List<KeyValuePair<string, string>> keyValuePairList = new List<KeyValuePair<string, string>>();
            foreach (var error in serviceResult.Errors)
            {
                if (!keyValuePairList.Exists(e => e.Key == error?.PropertyName && e.Value == error?.ErrorMessage))
                {
                    keyValuePairList.Add(new KeyValuePair<string, string>(error.PropertyName, error.ErrorMessage));
                }
            }

            foreach (var keyValue in keyValuePairList)
            {
                modelStateDictionary.AddModelError(keyValue.Key, keyValue.Value);
            }
        }
    }
}
