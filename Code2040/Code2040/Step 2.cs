using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace Code2040
{
    class Step_2
    {
        static void Main(string[] args)
        {
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://challenge.code2040.org/api/reverse");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using(var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    string givenstring = streamReader.ReadToEnd();
                    Console.WriteLine(givenstring);
                }

                

                    }
                }
            }

        }
    


