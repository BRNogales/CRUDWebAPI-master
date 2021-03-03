using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDWebAPI
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        public static string employee
        {
            get
            {
                return AppSettings.GetValueOrDefault("employee", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("employee", value);
            }
        }
        public static string password
        {
            get
            {
                return AppSettings.GetValueOrDefault("password","");
            }
            set
            {
                AppSettings.AddOrUpdateValue("password", value);
            }
        }
        public static string token
        {
            get
            {
                return AppSettings.GetValueOrDefault("token", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("token", value);
            }
        }


    }
}
