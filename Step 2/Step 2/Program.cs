using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace Step_2
{
    class Program
    {
        static void Main(string[] args)
       {
            var data = makeRequest("http://challenge.code2040.org/api/reverse", "{\"token\" :\"c542488ecdbab538ee07b0383f7d7af3\"}");
            Console.WriteLine(data);



            string reversestring = "";
            char[] cArray = data.ToCharArray();
            for(int i = cArray.Length -1; i > -1; i--)
            {
                reversestring += cArray[i];
            }

            var json = "{\"token\" :\"c542488ecdbab538ee07b0383f7d7af3\"," + "\"string\":\"" + reversestring + "\"}";
            Console.WriteLine(json);
            var newdata = makeRequest("http://challenge.code2040.org/api/reverse/validate", json);
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
            string givenstring = null;

            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                givenstring = streamReader.ReadToEnd();
            }
            return givenstring;

            

        }
    }
}
