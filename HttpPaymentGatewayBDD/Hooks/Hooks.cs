using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;
using TechTalk.SpecFlow;

namespace HttpPaymentGatewayBDD
{
    [Binding]
    class Hooks
    {
        [BeforeFeature]
        public static void BeforeFeature()
        {
            string ConfigFile = "conf.json";
            if (File.Exists(ConfigFile)) 
                RestClientBase.Config = new ConfigurationBuilder().AddJsonFile(ConfigFile).Build();
            else
                Environment.Exit(2);
        }
    }
}
