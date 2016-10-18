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
            Console.WriteLine(data);


            Dictionary<string, string[]> values = new Dictionary<string, string[]>();
            



            //string needle = values[]

            //var json = "{\"token\" :\"c542488ecdbab538ee07b0383f7d7af3\"," + "\"string\":\"" + reversestring + "\"}";
            //Console.WriteLine(json);
            //var newdata = makeRequest("http://challenge.code2040.org/api/haystack/validate", json);
            //Console.WriteLine(newdata);


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
