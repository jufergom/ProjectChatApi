using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Chat.DATA.Entities
{
    public class UserChannel
    {
     
        [ForeignKey("Channel")]
        public long idChannel { get; set; }
     
        [ForeignKey("User")]
        public string userTag { get; set; }

        public User User { get; set; }
        public Channel Channel { get; set; }
    }
}
