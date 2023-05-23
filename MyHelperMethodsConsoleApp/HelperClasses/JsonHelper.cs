using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MyHelperMethodsConsoleApp.HelperClasses
{
    public class JsonHelper
    {
        public static HelperModels.JsonHelper.BaseTable LoadJson()
        {
            using (StreamReader r = new StreamReader("C:\\Users\\umutu\\Downloads\\response_1684765708395.json"))
            {
                string json = r.ReadToEnd();
                HelperModels.JsonHelper.BaseTable baseTable = JsonConvert.DeserializeObject<HelperModels.JsonHelper.BaseTable>(json);
                return baseTable;
            }
        }

        public static List<HelperModels.JsonHelper.Item2> LoadJson2()
        {
            using (StreamReader r = new StreamReader("C:\\Users\\umutu\\Downloads\\response_1684765827104.json"))
            {
                string json = r.ReadToEnd();
                List<HelperModels.JsonHelper.Item2> json2 = JsonConvert.DeserializeObject<List<HelperModels.JsonHelper.Item2>>(json);
                return json2;
            }
        }

        public static List<HelperModels.JsonHelper.Item3> LoadJson3()
        {
            using (StreamReader r = new StreamReader("C:\\Users\\umutu\\Downloads\\response_1684771141645.json"))
            {
                string json = r.ReadToEnd();
                List<HelperModels.JsonHelper.Item3> json3 = JsonConvert.DeserializeObject<List<HelperModels.JsonHelper.Item3>>(json);
                return json3;
            }
        }
    }
}