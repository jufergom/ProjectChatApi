using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Chat.DATA.Entities
{
    public class Message
    {
        [Key]
        public long id { get; set; }    
        [Required]
        public string message { get; set; }
        public Channel channel { get; set; }
        public virtual User User { get; set; }
    }
}
