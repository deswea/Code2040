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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://challenge.code2040.org/api/reverse");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"token\" :\"c542488ecdbab538ee07b0383f7d7af3\"}";
                              
            
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();

            }

            
        }


    }
}
    

