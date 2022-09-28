using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_API_Json.Utils
{
    internal class TestDataUtils<T>
    {
        public static string GetConfigData(string key)
        {
            using StreamReader reader = File.OpenText("configData.json");
            {
                JsonTextReader jsonTextReader = new JsonTextReader(reader);
                JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);
                string value = jsonObject[key].ToString();
                reader.Close();
                return value;
            }
        }
        public static T GetTestData(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string json = reader.ReadToEnd();
                T testdata = JsonConvert.DeserializeObject<T>(json);
                reader.Close();
                return testdata;
            }

        }
        //public static T GetExpectedData(string key)
        //{
        //    using StreamReader reader = File.OpenText("configData.json");
        //    {
        //        JsonTextReader jsonTextReader = new JsonTextReader(reader);
        //        JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);
        //        T value = JsonConvert.DeserializeObject<T>(jsonObject[key].ToString());
        //        reader.Close();
        //        return value;
        //    }
        //}
    }
}
