using System;
using System.Collections.Generic;
using System.Text;

namespace Modul25.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfPublication { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        //  Навигационное свойство 
        public User User { get; set; }
    }
}
