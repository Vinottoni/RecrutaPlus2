using RecrutaPlus.Domain.Constants;
using RecrutaPlus.Domain.Services;
using System.Collections.Generic;
using System.Text;

namespace RecrutaPlus.Domain.Services
{
    public class ServiceResult
    {
        public ServiceResult() => Errors = new List<ServiceResultError>();

        public List<ServiceResultError> Errors { get; set; }
        public bool HasErrors => Errors.Count > 0;
        public void AddError(string propertyName, string errorMessage) => Errors.Add(new ServiceResultError(propertyName, errorMessage));
        public void AddError(string errorMessage) => Errors.Add(new ServiceResultError(null, errorMessage));
        public void AddError(ServiceResultError error) => Errors.Add(error);
        public void AddErrors(IEnumerable<ServiceResultError> errors) => Errors.AddRange(errors);
        public void AddErrors(params ServiceResultError[] errors) => Errors.AddRange(errors);
        public string GetAllErrors()
        {
            string errorMessages = string.Empty;
            foreach (var error in Errors)
            {
                errorMessages = errorMessages + error.ErrorMessage + DefaultConst.CARRIAGE_RETURN;
            }
            return errorMessages;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var error in Errors)
            {
                if (string.IsNullOrWhiteSpace(error.PropertyName))
                {
                    stringBuilder.AppendLine(error.ErrorMessage);
                }
                else
                {
                    stringBuilder.AppendLine(error.PropertyName + ": " + error.ErrorMessage);
                }
            }

            return stringBuilder.ToString();
        }
    }
}
