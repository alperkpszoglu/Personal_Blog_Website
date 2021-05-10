using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMvcApp.Entity
{
    public class Blog
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public DateTime AddedTime { get; set; }
        public bool Approve { get; set; }
        public bool Homepage { get; set; }

        public int CategoryId { get; set; } //foreign key
        public Category Category { get; set; } //navigation properties
    }
}