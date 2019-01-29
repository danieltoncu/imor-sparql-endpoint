using System;
using System.IO;
using System.Reflection;
using VDS.RDF;

namespace Imor.Database
{
    public static class DatabaseInitializer
    {
        public static string ontology = "C:\\ImagesOntologyV1.owl";

        public static IGraph Initialize()
        {
            //var path= Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\"));

            //path += "Imor.Database\\ImagesOntologyV1.owl";

            IGraph g = new Graph();

            g.LoadFromUri(new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#"));

            if (!string.IsNullOrEmpty(ontology))
            {
                g.LoadFromFile(ontology);
            }
            else
            {
                var assembly = Assembly.GetExecutingAssembly();

                var test = assembly.GetManifestResourceNames();

                using (Stream stream = assembly.GetManifestResourceStream("Imor.Database.ImagesOntologyV1.owl"))

                using (StreamReader reader = new StreamReader(stream))
                {
                    string result = reader.ReadToEnd();

                    g.LoadFromString(result);
                }
            }

            return g;
        }
    }
}