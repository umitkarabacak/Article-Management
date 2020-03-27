namespace ArticleManagement.Domain.Models
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }


        public int ArticleId { get; set; }

        public Article Article { get; set; }


        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}