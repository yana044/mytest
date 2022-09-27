using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace TestKaspersky
{
    public class GetDataUtils
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
    }
}
