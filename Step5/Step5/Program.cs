using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace Step5
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = makeRequest("http://challenge.code2040.org/api/dating", "{\"token\" :\"c542488ecdbab538ee07b0383f7d7af3\"}");
            //Console.WriteLine(data);
            //Console.ReadLine();



            Dictionary<string, Object> values = JsonConvert.DeserializeObject<Dictionary<string, Object>>(data);
            var datestamp = values["datestamp"].ToString();
            var interval = Convert.ToDouble(values["interval"]);
            Console.WriteLine(datestamp);
            Console.WriteLine(interval);

            DateTime datetime = DateTime.Parse(datestamp);
            DateTime newdatetime = datetime.AddSeconds(interval);
            string datetime2 = newdatetime.ToString("yyyy-MM-ddTHH:mm:ssZ");
          
            Console.WriteLine(datetime2);

            

            
            var json = "{\"token\" :\"c542488ecdbab538ee07b0383f7d7af3\", " + "\"datestamp\": \"" + datetime2 + "\"}";
            Console.WriteLine(json);
            var newdata = makeRequest("http://challenge.code2040.org/api/dating/validate", json);

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

