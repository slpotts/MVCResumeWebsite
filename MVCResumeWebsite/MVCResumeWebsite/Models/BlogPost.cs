using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCResumeWebsite.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString="{0:MM/dd/yy}", ApplyFormatInEditMode=true )]
        public DateTimeOffset CreatedDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset UpdatedDate { get; set; }
        [Required]
        public string Title { get; set; }
        [AllowHtml]
        [Required]
        public string BodyText { get; set; }
        public string Url { get; set; }
        public bool Published { get; set; }

        public string Slug { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public BlogPost()
        {
            Comments = new HashSet<Comment>();
        }
    }
}