using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TVGrid
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static void setVar(string nameSettings, string value) {
            ConfigurationManager.AppSettings[nameSettings] = value;
        }
        public static string getVar(string nameSettings)
        {
            return ConfigurationManager.AppSettings[nameSettings];
        }
    }
}
