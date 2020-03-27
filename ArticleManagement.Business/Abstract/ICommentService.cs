using System.Collections.Generic;
using ArticleManagement.Business.DTOs.Comment;

namespace ArticleManagement.Business.Abstract
{
    public interface ICommentService
    {
        IEnumerable<ResponseCommentDetail> ArticlesWithComments(int articleId);

        IEnumerable<ResponseCommentDetail> ArticlesWithComment(int articledId, int commentId);
    }
}