using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Music
    {
        [Key]
        public int ID { get; set; }
        public string Musics{get;set;}
        public string UserName{ get; set; }
        public string Content { get; set; }
    }
}