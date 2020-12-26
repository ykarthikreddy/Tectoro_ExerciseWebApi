using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;  

namespace AspcoreTestApp.Models
{
    public class Users
    {
        
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }       
        public string Email { get; set; }
        public string Alias { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int Level { get; set; }
        public int MgrId { get; set; }
    }
}
