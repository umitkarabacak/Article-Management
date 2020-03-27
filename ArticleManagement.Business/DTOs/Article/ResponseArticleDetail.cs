using System.Collections.Generic;
using ArticleManagement.Business.DTOs.Comment;

namespace ArticleManagement.Business.DTOs.Article
{
    public class ResponseArticleDetail
    {
        public ResponseArticleDetail()
        {
            ResponseCommentDetails = new List<ResponseCommentDetail>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<ResponseCommentDetail> ResponseCommentDetails { get; set; }
    }
}