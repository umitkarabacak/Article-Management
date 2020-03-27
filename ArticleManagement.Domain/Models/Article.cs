using System.Collections.Generic;

namespace ArticleManagement.Domain.Models
{
    public class Article : BaseEntity
    {
        public Article()
        {
            Comments = new List<Comment>();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public List<Comment> Comments { get; set; }
    }
}