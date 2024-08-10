using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Directory.Entities.Models
{
    public class Directory : BaseModel
    {
        public string Firstname { get; set; }
        public string? Lastname { get; set; }
        public string Phonenumber { get; set; }
        public string? Address { get; set; }
        public int UserId { get; set; }
    }
}
