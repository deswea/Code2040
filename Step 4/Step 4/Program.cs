using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace Step_4
{
    class Program
    {
        static void Main(string[] args)
        {

            var data = makeRequest("http://challenge.code2040.org/api/prefix", "{\"token\" :\"c542488ecdbab538ee07b0383f7d7af3\"}");
            //Console.WriteLine(data);
            //Console.ReadLine();



            Dictionary<string, Object> values = JsonConvert.DeserializeObject<Dictionary<string, Object>>(data);
            var prefix = values["prefix"];

            var array = values["array"].ToString().Replace("\"", "").Replace("[", "").Replace("]", "").Replace("\r\n", "").Replace(" ", "").Split(',');
            Console.WriteLine(array);
            List<string> newlist = null;

            for(int i = 0; i< array.Length; i++)
            if (array[i].Contains((string)prefix))
            {
                    newlist.Add(array[i]);        
            }
                else
                {
                    newlist = null;
                }
            


            var json = "{\"token\" :\"c542488ecdbab538ee07b0383f7d7af3\"," + "\"array\":\"" + newlist +  "\"}";
            Console.WriteLine(json);
            var newdata = makeRequest("http://challenge.code2040.org/api/prefix/validate", json);
            Console.WriteLine(newdata);
        }

        public static string makeRequest(string url, string json)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }


            var dictionary = "";
            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                dictionary = streamReader.ReadToEnd();
            }
            return dictionary;

        }
    }
}
