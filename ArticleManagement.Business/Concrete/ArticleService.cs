using System;
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
        private readonly ICacheProvider _cacheProvider;
        private string searchKey = "article";

        public ArticleService(IUnitOfWork unitOfWork, ICacheProvider cacheProvider)
        {
            _unitOfWork = unitOfWork;
            _cacheProvider = cacheProvider;
        }

        public async Task<IEnumerable<ResponseArticle>> Articles()
        {
            var isInCache = await _cacheProvider.IsInCache(searchKey);
            if (isInCache)
                return await _cacheProvider.Get<IEnumerable<ResponseArticle>>(searchKey);

            var allArticles = _unitOfWork.Repository<Article>().Get().Select(article => new ResponseArticle
            {
                Id = article.Id,
                Title = article.Title,
                Description = article.Content
            });
            return await SetRedis(searchKey, allArticles);
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
            searchKey = $"{searchKey}-{articledId}";
            var isInCache = await _cacheProvider.IsInCache(searchKey);

            if (isInCache)
                return await _cacheProvider.Get<ResponseArticle>(searchKey);

            ResponseArticle article = await _unitOfWork.Repository<Article>().Find(articledId);
            return await SetRedis(searchKey, article);
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

            searchKey = $"{searchKey}-{article.Id}";
            return await SetRedis(searchKey, (ResponseArticle)article);
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

            searchKey = $"{searchKey}-{articledId}";
            await SetRedis(searchKey, (ResponseArticle)article);
        }

        public async Task RemoveArticle(int articledId)
        {
            await _unitOfWork.Repository<Article>().Remove(articledId);
            await _unitOfWork.CommitAsync();

            searchKey = $"{searchKey}-{articledId}";
            await _cacheProvider.Delete(searchKey);
        }

        private async Task<T> SetRedis<T>(string key, T t)
        {
            await _cacheProvider.Delete(searchKey);
            return await _cacheProvider.Set(key, t, TimeSpan.FromMinutes(10));
        }
    }
}