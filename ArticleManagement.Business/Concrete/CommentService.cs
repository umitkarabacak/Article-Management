using System.Collections.Generic;
using System.Linq;
using ArticleManagement.Business.Abstract;
using ArticleManagement.Business.DTOs.Comment;
using ArticleManagement.Core.DataAccess.Abstract;
using ArticleManagement.Domain.Models;

namespace ArticleManagement.Business.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ResponseCommentDetail> ArticlesWithComments(int articledId)
        {
            return _unitOfWork.Repository<Comment>()
                .Include("Author,Article", i => i.ArticleId.Equals(articledId))
                .Select(i => new ResponseCommentDetail
                {
                    CommentId = i.Id,
                    Content = i.Content,
                    ArticleId = i.ArticleId,
                    ArticleName = i.Article.Title,
                    AuthorId = i.AuthorId,
                    AuthorName = i.Author.Fullname
                });
        }

        public IEnumerable<ResponseCommentDetail> ArticlesWithComment(int articledId, int commentId)
        {
            return _unitOfWork.Repository<Comment>()
                .Include("Author,Article", i => i.Id.Equals(commentId) && i.ArticleId.Equals(articledId))
                .Select(i => new ResponseCommentDetail
                {
                    CommentId = i.Id,
                    Content = i.Content,
                    ArticleId = i.ArticleId,
                    ArticleName = i.Article.Title,
                    AuthorId = i.AuthorId,
                    AuthorName = i.Author.Fullname
                });
        }
    }
}