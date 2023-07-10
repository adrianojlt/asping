using System.IO.Compression;
using System.Text;
using System.Xml;

namespace Sharping
{
    public static void Something() 
    { 
    }

    public class SoapConnection
    {
        private readonly string MimeBoundary = "--MIME_Boundary";
        
        private string url { get; set; }
        private string user { get; set; }
        private string pass { get; set; }
        private string body { get; set; }

        public SoapConnection(string url, string user, string pass, string body) 
        { 
            this.url = url;
            this.body = body;

            this.user = user;
            this.pass = pass;
        }

        public async void Cenas() 
        {
            var httpClient = GetHttpClient();

            var request = new HttpRequestMessage(HttpMethod.Post, url);

            request.Content = new StringContent(body, encoding: Encoding.UTF8, "application/xml");

            using (var response = httpClient.SendAsync(request).Result) 
            {
                using (var reader = XmlReader.Create(response.Content.ReadAsStreamAsync().Result))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "Include" && reader.NamespaceURI == "http://www.w3.org/2004/08/xop/include")
                        {
                            // Read the MTOM attachment
                            var contentID = reader.GetAttribute("href").Substring(4); // Remove "cid:"
                            var attachmentReader = reader.ReadSubtree();
                            attachmentReader.ReadToDescendant("Inline");
                        }
                    }
                }
            }
        }

        private HttpClient GetHttpClient() 
        {
            var auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{user}:{pass}"));

            var handler = new HttpClientHandler();

            handler.ClientCertificateOptions = ClientCertificateOption.Manual;

            handler.ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) =>
            {
                return true;
            };

            var httpClient = new HttpClient(handler);

            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {auth}");

            return httpClient;
        }

        public async Task<string> PostRequest() 
        {
            var httpClient = GetHttpClient();

            using (HttpContent content = new StringContent(body, Encoding.UTF8, "application/xml"))
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Content = content;

                using (HttpResponseMessage response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
                {
                    // throws an Exception if 404, 500, etc.
                    response.EnsureSuccessStatusCode();
                    //return await response.Content.ReadAsStringAsync();

                    // Read the response content as a stream
                    var contentType = response.Content.Headers.ToString();
                    Stream stream = await response.Content.ReadAsStreamAsync();

                    //var xmlCenas = System.Xml.XmlDictionaryReader.CreateMtomReader(stream, Encoding.UTF8, XmlDictionaryReaderQuotas.Max);
                    //var xmlCenas = System.Xml.XmlDictionaryReader.CreateMtomReader(stream, new[] { Encoding.UTF8 }, contentType, XmlDictionaryReaderQuotas.Max);

                    // Create a new instance of the StreamReader class to read the message as a text stream
                    StreamReader reader = new StreamReader(stream);

                    var allLines = new StringBuilder();

                    // Read the message line by line
                    string line;

                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        // Check if the line contains the MIME boundary
                        if (line == MimeBoundary)
                        {
                            // Read the MIME headers of the part
                            var headers = new Dictionary<string, string>();

                            while ((line = await reader.ReadLineAsync()) != "")
                            {
                                var parts = line.Split(": ");
                                headers.Add(parts[0], parts[1]);
                            }

                            // Check if the part is a ZIP attachment
                            if (headers["Content-Type"] == "application/octet-stream")
                            {
                                // Read the ZIP data from the part
                                string zipStringContent = await reader.ReadToEndAsync();

                                int index = zipStringContent.IndexOf("--MIME_Boundary");

                                string resultString = zipStringContent.Substring(0, index);

                                resultString = resultString.Remove(resultString.Length - 2);

                                var convertedFromBase64 = Convert.FromBase64String(resultString);

                                byte[] zipByteContent = await resultString.ToByteArray();

                                // Save the ZIP data to a file
                                File.WriteAllBytes("attachment.zip", convertedFromBase64);

                                var xml = ExtractXmlFromZip(zipByteContent);

                                if (xml != null) 
                                { 
                                    Console.WriteLine($"codigo: {xml.GetElementsByTagName("codigo")}"); 
                                    Console.WriteLine($"descricao: {xml.GetElementsByTagName("descricao")}"); 
                                }

                            }
                        }

                        allLines.AppendLine(line);
                    }

                    return allLines.ToString();
                }
            }
        }

        private XmlDocument? ExtractXmlFromZip(byte[] content) 
        {
            using (MemoryStream stream = new MemoryStream(content))
            {
                using (ZipArchive archive = new ZipArchive(stream))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.Name.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                        {
                            XmlDocument xmlDoc = new XmlDocument();

                            using (Stream xmlStream = entry.Open())
                            {
                                xmlDoc.Load(xmlStream);
                            }

                            return xmlDoc;
                        }
                    }
                }
            }

            return default;
        }
    }
}
