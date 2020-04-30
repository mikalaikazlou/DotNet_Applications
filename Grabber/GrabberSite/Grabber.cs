using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;

namespace GrabberSite
{
    public class Grabber
    {
        private static string _siteUrl;
        private static bool _run;
        private static bool _src;
        readonly static string _directoryPath = Directory.GetCurrentDirectory();
        readonly static string _fileName = ConfigurationManager.AppSettings["fileName"];
        readonly static string _fullPath = Path.Combine(_directoryPath, _fileName);

        public static bool SaveInformation()
        {
            bool _operationSave;
            using StreamWriter streamWriter = File.CreateText(_fullPath);
            {
                try
                {
                    WebClient webClient = new WebClient();
                    webClient.Headers.Add("User-Agent: Other");
                    streamWriter.WriteLine(webClient.DownloadString(_siteUrl));
                    webClient.Dispose();
                }
                catch (System.Exception)
                {
                    return _operationSave = false;
                }
                finally
                {
                    streamWriter.Close();
                }

                return _operationSave = true;
            }
        }
        public static void GetParseSite(List<string> ts)
        {
            for (int i = 0; i < ts.Count; i++)
            {
                if (Searcher.IsItAddressSite(ts[i]))
                {
                    _siteUrl =  ts[i];
                }

                if (_src)
                {
                    SaveInformation();
                }

                if (_run)
                {
                    Browser.OpenBrowser(_fullPath);
                }
            }
        }
        public static List<string> GetArgument(string[] _args)
        {
            List<string> list = new List<string>();

            for (int i = 0; i < _args.Length; i++)
            {
                if (_args[i].ToUpper() == "/SRC")
                {
                    _src = true;
                }
                else if (_args[i].ToUpper() == "/RUN")
                {
                    _run = true;
                }
                else
                {
                    list.Add(_args[i]);
                }
            }

            return list;
        }
    }
}