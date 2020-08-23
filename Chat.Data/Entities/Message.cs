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

        [ForeignKey(nameof(User))]
        public string userTag { get; set; }

        [ForeignKey(nameof(Channel))]
        public long channelId { get; set; }

        public Channel Channel { get; set; }
        public virtual User User { get; set; }
    }
}
