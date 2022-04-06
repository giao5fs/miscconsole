using System;
using System.Net;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var res = RemoteFileExists(@"https://tools.l1cache.pixelz.com/api/Image/2/2/o%2F58%2F11%2F52%2F31%2");
            Console.WriteLine(res);
            Console.ReadLine();
        }
        ///
        /// Checks the file exists or not.
        ///
        /// The URL of the remote file.
        /// True : If the file exits, False if file not exists
        static bool RemoteFileExists(string url)
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "GET";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                var res = response.StatusCode == HttpStatusCode.OK;
                response.Close();
                return res;
            }
            catch
            {
                //Any exception will returns false.
                return false;
            }
        }
    }
}
