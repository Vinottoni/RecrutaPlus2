namespace Safety.Domain.Services
{
    public class ServiceResultError
    {
        public ServiceResultError(string propertyName, string errorMessage) 
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
