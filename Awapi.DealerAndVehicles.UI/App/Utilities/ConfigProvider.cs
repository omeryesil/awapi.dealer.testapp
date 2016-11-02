using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Awapi.DealerAndVehicles.UI.App.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConfigProvider
    {
        public static String API_BaseURL
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["DealersAndVehicles_API_BaseUrl"];
            }
        }
    }
}