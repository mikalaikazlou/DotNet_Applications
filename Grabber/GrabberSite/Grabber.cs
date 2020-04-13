using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;

namespace GrabberSite
{
    public class Grabber
    {
        static string _siteUrl;
        readonly static string _directoryPath = Directory.GetCurrentDirectory();
        readonly static string _fileName = ConfigurationManager.AppSettings.Get(0);
        readonly static string _fullPath = Path.Combine(_directoryPath, _fileName);

        public static void SaveInformation(string _siteUrl, string _fullPath)
        {
            using StreamWriter streamWriter = File.CreateText(_fullPath);
            {
                try
                {
                    WebClient webClient = new WebClient();
                    webClient.Headers.Add("User-Agent: Other");
                    streamWriter.WriteLine(webClient.DownloadString(_siteUrl));
                    webClient.Dispose();
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception(ex.Message);
                }
                finally
                {
                    streamWriter.Close();
                }
            }
        }
        public static void GetParseSite(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (Searcher.IsItAddressSite(args[i]))
                {
                    _siteUrl = @"https:\\" + args[i];
                }

                if (args[i].ToUpper() == "/SRC")
                {
                    SaveInformation(_siteUrl, _fullPath);
                }

                if (args[i].ToUpper() == "/RUN")
                {
                    Browser.OpenBrowser(_siteUrl);
                }
            }
        }
        public static List<string> GetArgument(string[] _args)
        {
            List<string> list = new List<string>();

            for (int i = 0; i < _args.Length; i++)
            {
                list.Add(_args[i]);
            }

            return list;
        }
    }
}