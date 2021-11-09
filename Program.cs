using System;
using System.IO;
using System.Xml.Serialization;

namespace DisposeTest
{
    public class Program
    {
        public static void Main()
        {
            var deserializeDisposeResult = DeserializeDispose<Bookstore>(CreateXml());
            Console.WriteLine(deserializeDisposeResult);

            var deserializeNoDispose = DeserializeNoDispose<Bookstore>(CreateXml());
            Console.WriteLine(deserializeNoDispose);
            
            var deserializeDisposeAlt = DeserializeDisposeAlt<Bookstore>(CreateXml());
            Console.WriteLine(deserializeDisposeAlt);

            var deserializeDisposeAltNoUsing = DeserializeDisposeAltNoUsing<Bookstore>(CreateXml());
            Console.WriteLine(deserializeDisposeAltNoUsing);
            
            // Playing around
            var sigTest = DeserializeDisposeAltNoUsing<Bookstore, Bookstore, Bookstore, Bookstore, Bookstore, Bookstore>(CreateXml());
            Console.WriteLine(sigTest.GetType());
        }

        public static TResult DeserializeDispose<TResult>(string xml) where TResult : class
        {
            using var sr = new StringReader(xml);

            var xs = new XmlSerializer(typeof(TResult), new XmlRootAttribute("bookstore"));

            return (TResult)xs.Deserialize(sr);
        }

        public static TResult DeserializeNoDispose<TResult>(string xml) where TResult : class
        {
            var xs = new XmlSerializer(typeof(TResult), new XmlRootAttribute("bookstore"));

            return (TResult)xs.Deserialize(new StringReader(xml));
        }

        public static TResult DeserializeDisposeAlt<TResult>(string xml) where TResult : class
        {
            using var sr = new StringReader(xml);

            var xs = new XmlSerializer(typeof(TResult), new XmlRootAttribute("bookstore"));

            var result = (TResult)xs.Deserialize(sr);

            sr.Dispose();

            return result;
        }

        public static TResult DeserializeDisposeAltNoUsing<TResult>(string xml) where TResult : class
        {
            var sr = new StringReader(xml);

            var xs = new XmlSerializer(typeof(TResult), new XmlRootAttribute("bookstore"));

            var result = (TResult)xs.Deserialize(sr);

            sr.Dispose();

            return result;
        }

        // Signature test
        public static TR DeserializeDisposeAltNoUsing<T, TR, TRA, TRB, TRC, TRD>(string xml) where T : class where TR : class
        {
            var sr = new StringReader(xml);

            var xs = new XmlSerializer(typeof(T), new XmlRootAttribute("bookstore"));
            
            var result = (TR)xs.Deserialize(sr);

            sr.Dispose();

            return result;
        }

        private static string CreateXml()
        {
            var xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><bookstore><book category=\"COOKING\"><title lang =\"en\">Everyday Italian</title><author>Giada De Laurentiis</author><year>2005</year><price>30.00</price></book></bookstore>";
            return xml;
        }
    }
}



