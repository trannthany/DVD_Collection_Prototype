using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLib
{
    public class DVD
    {
        public int ID { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Language { get; set; }

        public DVD(string title, string director, int year, string language) 
        {
           // ID = id;
            Year = year;
            Title = title;
            Director = director;
            Language = language;
        }

        public override string ToString()
        {
            return string.Format("Title: {0} \nDirector: {1} \nLanguage: {2}\nYear: {3} \nID:{4}", Title, Director, Language, Year, ID);
        }
    }
}
