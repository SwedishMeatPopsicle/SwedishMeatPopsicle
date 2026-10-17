using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Lektion_14_10
{
    public class Book
    {
        public string Author {  get; set; }
        public string Title {  get; set; }
        public string ISBN { get; set; }
        public bool Available { get; set; }

        public Book(string author, string titel, string isbn, bool available)
        {
            Author = author;
            Title = titel;
            ISBN = isbn;
            Available = available; //Finns boken inne eller är den utlånad?
        }

        public override string ToString()
        {
            return $"Författare: {Author} Titel: {Title} ISBN: {ISBN} finns inne: {Available}";
        }
    }
}
