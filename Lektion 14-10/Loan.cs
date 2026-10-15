using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion_14_10
{
    public class Loan
    {
        public Book Title { get; set; }
        public User Name { get; set; }
        public string Date { get; set; }

        public Loan(Book title, User userid, string date)
        {
            Title = title;
            Name = userid;
            Date = date;
        }

        public override string ToString()
        {
            return $"{Title} {Name} {Date}";
        }
    }
}