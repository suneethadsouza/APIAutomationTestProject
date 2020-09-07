using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIAutomationTestProject.Helper
{
    public class DataHelper
    {
        public static T Deserialize<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
