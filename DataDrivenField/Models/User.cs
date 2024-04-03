using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataDrivenField.Models
{
    public class User : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}