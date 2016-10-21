using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
namespace Step_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = makeRequest("http://challenge.code2040.org/api/haystack", "{\"token\" :\"c542488ecdbab538ee07b0383f7d7af3\"}");
            //Console.WriteLine(data);

            //Console.ReadLine();



            Dictionary<string, Object> values = JsonConvert.DeserializeObject<Dictionary<string, Object>>(data);
            var needle = values["needle"];
            var haystack = values["haystack"].ToString().Replace("\"", "").Replace("[","").Replace("]","").Replace("\r\n", "").Replace(" ", "").Split(',');
            Console.WriteLine(haystack);

            int index = 0;

            for (int i = 0; i < haystack.Length; i++)
            {
                if ((string)needle == haystack[i])
                {
                    index = haystack[i].Length;

                }
                else
                {
                    index = 0;
                }
            }


            var json = "{\"token\" :\"c542488ecdbab538ee07b0383f7d7af3\"," + "\"needle\":\"" + index + "\"}";
            Console.WriteLine(json);
            var newdata = makeRequest("http://challenge.code2040.org/api/haystack/validate", json);
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


            string dictionary = null;
            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                dictionary = streamReader.ReadToEnd();
            }
            return dictionary;

        }
    }
}
