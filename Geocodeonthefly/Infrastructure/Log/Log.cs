using System;
using System.IO;

namespace Geocodeonthefly.Infrastructure.Log
{
    public class Log
    {
        private readonly string _baseDirectory = string.Format(@"{0}Log\", AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyy-MM-dd"));

        public Log()
        {
            if (!Directory.Exists(_baseDirectory))
                Directory.CreateDirectory(_baseDirectory);

        }

        public void GmapsError(string requestUrl, int requestStatusCode, string requestResponse)
        {
            bool wrote;

            // Concurrent requests to write log may occur, so try to open the file until you can.
            do
            {
                wrote = false;

                try
                {
                    using (StreamWriter writer = new StreamWriter(string.Format(@"{0}log-{1}.txt", _baseDirectory, DateTime.Now.ToString("yyyy-MM-dd")), true))
                    {
                        writer.WriteLine(string.Format("---------- ERROR ({0}) ----------", DateTime.Now.ToString("HH:mm:ss")));
                        writer.WriteLine("Request URI: " + requestUrl);
                        writer.WriteLine("Request Code: " + requestStatusCode);
                        writer.WriteLine("Response: " + requestResponse);
                    }

                    wrote = true;

                } catch {}

            } while (!wrote);
        }
    }
}
