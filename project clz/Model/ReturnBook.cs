using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clz.Model
{
    internal class ReturnBook
    {

    
            public string StudentID { get; set; }
            public string StudentName { get; set; }
            public string Contact { get; set; }
            public string BookID { get; set; }
            public string BookName { get; set; }
            public string Faculty { get; set; }
            public string Semester { get; set; }
            public DateTime IssueDate { get; set; }
            public DateTime? ReturnDate { get; set; }
            public string Status { get; set; } // New property added
  

}
}
