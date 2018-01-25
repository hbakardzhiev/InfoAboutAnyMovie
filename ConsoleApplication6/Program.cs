using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ConsoleApplication6
{
    class Program
    {
        public static string getJson()
        {
            string titleOfDesiredMovie = Console.ReadLine();
            WebClient client = new WebClient();
            string json = client.DownloadString("http://www.omdbapi.com/?t=" + titleOfDesiredMovie + "&apikey=291bbe79");
            return json;
        }
        static void Main(string[] args)
        {
            RootObject movie = new JavaScriptSerializer().Deserialize<RootObject>(getJson());
            string[] array = {
                                 "Title",
                                 "Year",
                                 "Rated",
                                 "Genre",
                                 "Writer",
                                 "Plot"
                             };
            for (int i = 0; i < array.Length;i++ )
            { 
                var propertyInfo = movie.GetType().GetProperty(array[i]);
                Console.WriteLine(propertyInfo.GetValue(movie).ToString());
                Console.WriteLine();
            }
            var key = Console.ReadKey();
        }
    }
}
