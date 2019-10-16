using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Railways.Tests
{
    public abstract class BaseApiTests
    {
        public string TestBaseHost = "localhost:5001";
        protected string TestsBaseUrl => $"https://{TestBaseHost}";

        private static Process _serverProcess;

        /// <summary>
        ///     Initialization
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            var baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace(".Tests", ".Web");
            var serverPath = Path.Combine(baseDir, "Railways.Web.exe");
            // Start Parser.Cloud.Web
            var psi = new ProcessStartInfo(serverPath)
            {
                UseShellExecute = false,
                WorkingDirectory = baseDir,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            psi.EnvironmentVariables.Add("ASPNETCORE_ENVIRONMENT", "Development");
            _serverProcess = Process.Start(psi);

            // wait for server initialize
            Thread.Sleep(5000);

            // Disable SSL check
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => true;
        }

        /// <summary>
        ///     Cleaning
        /// </summary>
        [OneTimeTearDown]
        public void Clean()
        {
            _serverProcess?.Kill();
        }

        protected string BuildUrl(string path)
        {
            var url = $"{TestsBaseUrl}/railways/{path}";
            return url;
        }

        public async Task<T> InvokeApi<T>(
            string path,
            string method,
            string body) where T : class
        {
            WebRequest request = PrepareRequest(path, method, body);
            return await ReadResponseAsync<T>(request);
        }

        private HttpWebRequest PrepareRequest(
            string path,
            string method,
            string body)
        {
            var client = (HttpWebRequest)WebRequest.Create(path);

            client.Method = method;
            client.ContentType = "application/json";

            MemoryStream streamToSend = null;
            try
            {
                switch (method)
                {
                    case "GET":
                        break;
                    case "POST":
                    case "PUT":
                    case "DELETE":
                        streamToSend = new MemoryStream();

                        if (body != null)
                        {
                            var requestWriter = new StreamWriter(streamToSend);
                            requestWriter.Write(body);
                            requestWriter.Flush();
                        }

                        break;
                    default:
                        throw new Exception("Unknown method type " + method);
                }

                if (streamToSend != null)
                    using (var requestStream = client.GetRequestStream())
                    {
                        CopyTo(streamToSend, requestStream);
                    }
            }
            finally
            {
                streamToSend?.Dispose();
            }

            return client;
        }

        private static void CopyTo(Stream source, Stream destination, int bufferSize = 81920)
        {
            if (source.CanSeek)
            {
                source.Flush();
                source.Position = 0;
            }

            var array = new byte[bufferSize];
            int count;
            while ((count = source.Read(array, 0, array.Length)) != 0)
                destination.Write(array, 0, count);
        }

        private async Task<T> ReadResponseAsync<T>(WebRequest client) where T : class
        {
            var webResponse = await GetResponseAsync(client);
            var httpWebResponse = webResponse as HttpWebResponse;

            var resultStream = new MemoryStream();

            var responseStream = httpWebResponse.GetResponseStream();
            if (responseStream != null)
                responseStream.CopyTo(resultStream);

            try
            {
                resultStream.Position = 0;

                if (typeof(T) == typeof(HttpWebResponse))
                    return httpWebResponse as T;

                if (typeof(T) == typeof(Stream))
                    return resultStream as T;

                var str = Encoding.UTF8.GetString(resultStream.ToArray());

                if (typeof(T) == typeof(string))
                    return str as T;

                if (typeof(T) == typeof(JObject))
                    return JObject.Parse(str) as T;
                return Deserialize(str, typeof(T)) as T;
            }
            catch (Exception)
            {
                resultStream.Dispose();
                throw;
            }
        }

        private async Task<WebResponse> GetResponseAsync(WebRequest request)
        {
            try
            {
                return await request.GetResponseAsync();
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                    return wex.Response;

                throw;
            }
        }

        public static object Deserialize(string json, Type type)
        {
            if (string.IsNullOrEmpty(json)) return null;

            if (json.StartsWith("{") || json.StartsWith("["))
                return JsonConvert.DeserializeObject(json, type);

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(json);
            return JsonConvert.SerializeXmlNode(xmlDoc);
        }

        public static string Serialize(object obj)
        {
            var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            return obj != null ? JsonConvert.SerializeObject(obj, settings) : null;
        }
    }
}