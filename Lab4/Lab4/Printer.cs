using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab4
{
    internal class Printer
    {
        internal void IAmPrinting(PrintedEdition check)
        {
            if (check is Author author)
            {
                author.ToString();
            }
            if (check is Book book)
            {
                book.ToString();
            }
            if (check is Journal journal)
            {
                journal.ToString();
            }
            if (check is Person person)
            {
                person.ToString();
            }
            if (check is Textbook textbook)
            {
                textbook.ToString();
            }
        }
    }
}
