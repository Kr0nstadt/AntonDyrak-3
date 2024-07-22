using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Kyrsach
{
    internal class Book
    {
        private string author;
        private string title;
        private string publisher;
        private int yearCreation;
        private int numPages;
         public Book(string author, string title, string publisher, int yearCreation, int numPages)
        {
            this.author = author;
            this.title = title;
            this.publisher = publisher;
            this.yearCreation = yearCreation;
            this.numPages = numPages;
        }

        public override string ToString()
        {
            return $"{author}\t{title}\t{publisher}\t{yearCreation}\t{numPages}";
        }
    }
}
