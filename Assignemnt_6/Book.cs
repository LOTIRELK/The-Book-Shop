using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignemnt_6
{
   public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Price { get; set; }

        public Book() { }

        public Book(string isbn, string title, string author, string price)
        {
            this.ISBN = isbn;
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public string GetDisplayText(string sep)
        {
            return ISBN + sep + Title + sep + Author + sep + Price;
        }

    }

    
}
