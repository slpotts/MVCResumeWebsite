using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCResumeWebsite.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public string Message { get; set; }
        public string AuthorId { get; set; }
        public bool ShowComment { get; set; }

        public virtual BlogPost Post { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
}