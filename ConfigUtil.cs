using System;
using System.Collections.Generic;
using System.Text;
using LitJson;
using System.IO;

namespace MetroUITest
{
    class ConfigUtil
    {
        public static JsonData configData 
        {
            get {
                string configFile = AppDomain.CurrentDomain.BaseDirectory + "config.json";
                StreamReader sr = new StreamReader(configFile);
                string config = sr.ReadToEnd();
                return  JsonMapper.ToObject(config);
            }
        }

        public ConfigUtil() 
        {
        }

        public static string getConfig(string key) 
        {
            string[] keyArray = key.Split('.');
            JsonData nodeJsonData = configData;
            
            for (int i = 0; i < keyArray.Length-1; i++)
            {
                nodeJsonData = nodeJsonData[keyArray[i]];
            }
            string fieldname = keyArray[keyArray.Length-1];
            return nodeJsonData[fieldname].ToString();
        }

        public static List<string> getList(string key)
        {
            string[] keyArray = key.Split('.');
            JsonData nodeJsonData = configData;
            
            for (int i = 0; i < keyArray.Length - 1; i++)
            {
                nodeJsonData = nodeJsonData[keyArray[i]];
            }

            string fieldname = keyArray[keyArray.Length - 1];
            List<string> list = new List<string>();
            JsonData listJsonData = nodeJsonData[fieldname];
            if (!listJsonData.IsArray)
            {
                return list;
            }

            for (int i = 0, length = listJsonData.Count; i < length; i++)
            {
                list.Add(listJsonData[i].ToString());
            }
            return list;
        }
    }
}
