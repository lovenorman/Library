﻿namespace FjärdeOchSIstaFörsöket.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string AuthorName { get; set; }

        public List<Book> Books { get; set;} = new List<Book>();
    }
}
