using ProjectLib.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLib
{
    public class Repository
    {
        private static readonly string settingsFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"ProjectLib\Settings");
        


        public static List<Representation> GetRepresentationsData(string url)
        {
            var client = new RestClient(url);
            var response = client.Execute<List<Representation>>(new RestRequest());

            return response.Data;
        }


        public static List<Match> GetMatchData(string url)
        {
            var client = new RestClient(url);

            var response = client.Execute<List<Match>>(new RestRequest());

            return response.Data;
        }

        public static string GetPropertiesFromFile(string file)
        {
            string settings = "";

            try
            {
                using (StreamReader r = new StreamReader(Path.Combine(settingsFilePath, file)))
                {
                    while (!r.EndOfStream)
                    {
                        settings += r.ReadLine() + ';';
                    }

                    settings = settings.Remove(settings.LastIndexOf(';'), 1);
                }

                return settings;
            }
            catch (Exception)
            {
                return settings;
            }
        }

        public static void SaveToFile(string text, string path)
        {
            if (!Directory.Exists(settingsFilePath))
            {
                Directory.CreateDirectory(settingsFilePath);
            }

            using (StreamWriter w = new StreamWriter(path))
            {
                w.WriteLine(text);
            }
        }

    }
}
