namespace ArticleManagement.Business.DTOs.Comment
{
    public class ResponseCommentDetail
    {
        public int CommentId { get; set; }

        public string Content { get; set; }

        public int ArticleId { get; set; }

        public string ArticleName { get; set; }

        public int AuthorId { get; set; }

        public string AuthorName { get; set; }
    }
}