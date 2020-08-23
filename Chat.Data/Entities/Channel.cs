using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Chat.DATA.Entities
{
    public class Channel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string name { get; set; }

        public string topic { get; set; }
        
        public IEnumerable<Message> messages { get; set; }
    }
}
