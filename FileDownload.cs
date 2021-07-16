using System;
using System.Net;

namespace VerikaiCodeChallenge
{
    class FileDownload
    {
        public static void GetFile(string uri, string fileName)
        {
            string path = uri + fileName;
            WebClient client = new();
            Console.WriteLine("Downloading Web File...");

            client.DownloadFile(path, fileName);
            Console.WriteLine("File Downloaded.");
        }
    }
}
