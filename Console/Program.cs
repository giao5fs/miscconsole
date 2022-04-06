using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleA
{
    #region Old


    class MyClass
    {
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
        public string MyProperty3 { get; set; }
    }
    class Program3
    {
        //static void Main(string[] args)
        //{

        //    System.Console.WriteLine(ASCIItoHex("6220000008a01000"));
        //    System.Console.ReadLine();

        //}



        public TParent CopyChild<TParent, TChild>(TChild child, TParent parent) where TChild : TParent
        {
            var properties = typeof(TParent).GetProperties();
            foreach (var item in properties)
            {
                var value = item.GetValue(child);
                item.SetValue(parent, value);
            }
            return parent;
        }



        public async static Task TestMethod()
        {
            Console.WriteLine("Start");
            var result = await Task.Run(LongTask);

            Console.WriteLine("End");
        }

        public async static void Method()
        {
            //await Task.Run(new Action(LongTask));
            //Console.WriteLine("New Thread");
        }
        public static int LongTask()
        {
            Thread.Sleep(3000);
            return 1;

        }

        public static string ASCIItoHex(string Value)
        {
            StringBuilder sb = new StringBuilder();

            foreach (byte b in Value)
            {
                sb.Append(string.Format("{0:x2}", b));
            }

            return sb.ToString();
        }
        public static string ConvertHex(string hexString)
        {
            try
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexString.Length; i += 2)
                {
                    string hs = string.Empty;

                    hs = hexString.Substring(i, 2);
                    ulong decval = Convert.ToUInt64(hs, 16);
                    long deccc = Convert.ToInt64(hs, 16);
                    char character = Convert.ToChar(deccc);
                    ascii += character;

                }

                return ascii;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);

            }

            return string.Empty;
        }
        public static string ASCIItoHex2(string Value)
        {
            StringBuilder sb = new StringBuilder();

            byte[] inputByte = Encoding.UTF8.GetBytes(Value);

            foreach (byte b in inputByte)
            {
                sb.Append(string.Format("{0:x2}", b));
            }

            return sb.ToString();
        }

    }

    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Department { get; set; }
        public string PhotoPath { get; set; }
    }
    class Program4
    {
        static HttpClient client = new HttpClient();

        static void ShowProduct(Product product)
        {
            Console.WriteLine($"Name: {product.Name}\tPrice: " +
                $"{product.Name}\tCategory: {product.Email}");
        }

        static async Task<Uri> CreateProductAsync(Product product)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/student", product);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<object> GetProductAsync()
        {
            HttpResponseMessage response = await client.GetAsync("api/student");
            if (response.IsSuccessStatusCode)
            {

            }
            var result = await response.Content.ReadAsAsync<object>();
            return result;
        }

        static async Task<object> UpdateProductAsync(Product product)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/products/{product.Id}", product);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            var result = await response.Content.ReadAsAsync<object>();

            return result;
        }

        static async Task<HttpStatusCode> DeleteProductAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/products/{id}");
            return response.StatusCode;
        }

        //static void Main()
        //{
        //    RunAsync().GetAwaiter().GetResult();
        //    Console.WriteLine("End Program");
        //}

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:64766/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var obj = await GetProductAsync();
            var res = JsonConvert.SerializeObject(obj);
            var prod = JsonConvert.DeserializeObject<List<Product>>(obj.ToString());
            foreach (var item in prod)
            {
                Console.WriteLine(item.Name);
            }
            //try
            //{
            //    //Create a new product

            //    //Get the product

            //    //ShowProduct(JsonConvert.DeserializeObject<Product>(product.Name));
            //    // Update the product
            //    //Console.WriteLine("Updating price...");
            //    //product.Price = 80;
            //    //await UpdateProductAsync(product);

            //    // Get the updated product
            //    //product = await GetProductAsync(url.PathAndQuery);
            //    //ShowProduct(product);

            //    //// Delete the product
            //    //var statusCode = await DeleteProductAsync(product.Id);
            //    //Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            Console.ReadLine();
        }
    }
    #endregion
    class FileInfoDownload
    {
        public string ImageId { get; set; }
        public string BucketId { get; set; }
        public string FileKey { get; set; }
    }
    class Program
    {
        static void Main()
        {
            HttpClient httpClient = new HttpClient();
            Console.WriteLine("Start Comsuming..");

            List<FileInfoDownload> context = new List<FileInfoDownload>();
            FileInfoDownload f1 = new FileInfoDownload();
            f1.ImageId = "53958860";
            f1.BucketId = "5";
            f1.FileKey = HttpUtility.UrlEncode("t/p/o/53/95/88/60/1/100041076_JJ_7636.jpg");
            FileInfoDownload f2 = new FileInfoDownload();
            f2.ImageId = "53958861";
            f2.BucketId = "5";
            f2.FileKey = HttpUtility.UrlEncode("t/p/o/53/95/88/61/1/100041076_JJ_7638.jpg");
            FileInfoDownload f3 = new FileInfoDownload();
            f3.BucketId = "5";
            f3.ImageId = "53958862";
            f3.FileKey = HttpUtility.UrlEncode("t/p/o/53/95/88/62/1/100041077_JJ_7620.jpg");
            FileInfoDownload f4 = new FileInfoDownload();
            f4.ImageId = "53958863";
            f4.BucketId = "5";
            f4.FileKey = HttpUtility.UrlEncode("t/p/o/53/95/88/64/1/100041082_JJ_7627.jpg");
            FileInfoDownload f5 = new FileInfoDownload();
            f5.ImageId = "53958864";
            f5.BucketId = "5";
            f5.FileKey = HttpUtility.UrlEncode("t/p/o/53/95/88/66/1/100041092_JJ_7670.jpg");
            context.Add(f1);
            context.Add(f2);
            context.Add(f3);
            context.Add(f4);
            context.Add(f5);

            string baseUrl = "https://tools.l1cache.pixelz.com/api/Image";
            string officeId = "2";


            foreach (var file in context)
            {
                string dir = "C:\\ImgTemp\\";
                if (!System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.CreateDirectory(dir);
                }
                string dest = dir + file.ImageId + ".jpg";
                Console.WriteLine("----------------------------------------------");
                string url = $"{baseUrl}/{officeId}/{file.BucketId}/{file.FileKey}";
                httpClient.GetAsync(url).ContinueWith(x =>
                {
                    
                    var result = x.Result;
                    Console.WriteLine(result.RequestMessage.RequestUri.AbsoluteUri);
                    result.EnsureSuccessStatusCode();
                    //result.Content
                    //.ReadAsAsync<JsonArray>()
                    //.ContinueWith(readResult =>
                    //{
                    //    var arr = readResult.Result;
                    //    Console.WriteLine(arr.Count);
                       
                    //});

                    using (WebClient wc = new WebClient())
                    {
                        wc.DownloadFileTaskAsync(result.RequestMessage.RequestUri.AbsoluteUri, dest).ContinueWith((g) => {
                            Console.WriteLine(x.Result);
                            Console.WriteLine(g.Status);
                            Console.WriteLine(g.IsCompleted);
                        });
                    }
                });


            }


            Console.ReadLine();
        }
    }

}
