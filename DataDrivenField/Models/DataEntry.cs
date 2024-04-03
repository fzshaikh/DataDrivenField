using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataDrivenField.Models
{
    public class DataEntry:BaseModel
    {
        public string FirstName { get; set; }
        public string Contact { get; set; }
        public string PIN { get; set; }
        public decimal Salary { get; set; }
        public string CreatedBy { get; set; }
    }
}