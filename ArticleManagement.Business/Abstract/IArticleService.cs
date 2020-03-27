using System.Collections.Generic;
using System.Threading.Tasks;
using ArticleManagement.Business.DTOs.Article;

namespace ArticleManagement.Business.Abstract
{
    public interface IArticleService
    {
        IEnumerable<ResponseArticle> Articles();

        IEnumerable<ResponseArticleDetail> ArticlesWithComments();

        Task<ResponseArticle> GetArticle(int articledId);

        Task<ResponseArticle> AddArticle(RequestArticle article);

        Task UpdateArticle(int articledId, RequestArticle requestArticle);

        Task RemoveArticle(int articledId);
    }
}