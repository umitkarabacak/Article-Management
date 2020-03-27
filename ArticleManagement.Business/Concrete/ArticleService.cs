using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleManagement.Business.Abstract;
using ArticleManagement.Business.DTOs.Article;
using ArticleManagement.Business.DTOs.Comment;
using ArticleManagement.Core.DataAccess.Abstract;
using ArticleManagement.Domain.Models;

namespace ArticleManagement.Business.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ResponseArticle> Articles()
        {
            var articles = _unitOfWork.Repository<Article>().Get();

            return articles.Select(article => new ResponseArticle
            {
                Id = article.Id,
                Title = article.Title,
                Description = article.Content
            });
        }

        public IEnumerable<ResponseArticleDetail> ArticlesWithComments()
        {
            var articles = _unitOfWork.Repository<Article>().Include("Comments,Comments.Author,Comments.Article");

            return articles?.Select(article => new ResponseArticleDetail
            {
                Id = article.Id,
                Title = article.Title,
                Description = article.Content,
                ResponseCommentDetails = article.Comments.SelectMany(i => new List<ResponseCommentDetail>
                {
                    new ResponseCommentDetail
                    {
                        Content = i.Content,
                        CommentId = i.Id,
                        ArticleId = i.ArticleId,
                        ArticleName = i.Article.Title,
                        AuthorId = i.AuthorId,
                        AuthorName =i.Author.Fullname
                    }
                }).ToList()
            });
        }

        public async Task<ResponseArticle> GetArticle(int articledId)
        {
            ResponseArticle article = await _unitOfWork.Repository<Article>().Find(articledId);

            return article;
        }

        public async Task<ResponseArticle> AddArticle(RequestArticle requestCreateArticle)
        {
            var article = new Article
            {
                Title = requestCreateArticle.Title,
                Content = requestCreateArticle.Description
            };

            await _unitOfWork.Repository<Article>().Add(article);
            await _unitOfWork.CommitAsync();
            return new ResponseArticle
            {
                Id = article.Id,
                Title = article.Title,
                Description = article.Content
            };
        }

        public async Task UpdateArticle(int articledId, RequestArticle requestArticle)
        {
            var article = await _unitOfWork.Repository<Article>().Find(articledId);
            if (article == null)
                return;

            article.Title = requestArticle.Title;
            article.Content = requestArticle.Description;

            _unitOfWork.Repository<Article>().Update(article);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveArticle(int articledId)
        {
            await _unitOfWork.Repository<Article>().Remove(articledId);
            await _unitOfWork.CommitAsync();
        }
    }
}