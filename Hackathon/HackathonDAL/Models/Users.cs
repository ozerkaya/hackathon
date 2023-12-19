using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonDAL.Models
{
    [Table("Users")]
    public class Users
    {
        public int ID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? NameSurname { get; set; }
        public bool IsEnable { get; set; }
        public string? TeamName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
    }
}
