using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Chat.DATA.Entities
{
    public class User
    {
        public string name { get; set; }
        
        [Key]
        public string username { get; set; }

        public string password { get; set; }

    }
}
