using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clz.Model
{
    internal class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }

        public string Faculty  { get; set; }
        public string  Semester { get; set; }
        public int Quantity { get; set; }
    }
}
