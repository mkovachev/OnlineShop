using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace OnlineShop.Controllers.Infrastructure
{
    public static class TempDataDictionaryExtensions
    {
        public static void AddSuccessMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[ControllerConstants.SuccessMessage] = message;
        }

        public static void AddErrorMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[ControllerConstants.ErrorMessage] = message;
        }

        public static void AddWarningMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[ControllerConstants.WarningMessage] = message;
        }
    }
}
