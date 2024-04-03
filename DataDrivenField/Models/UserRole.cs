using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataDrivenField.Models
{
    public class UserRole : BaseModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}