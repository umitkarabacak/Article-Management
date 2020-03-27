namespace ArticleManagement.Business.DTOs.Article
{
    public class ResponseArticle
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }


        public static implicit operator ResponseArticle(Domain.Models.Article article)
        {
            return new ResponseArticle
            {
                Id = article.Id,
                Title = article.Title,
                Description = article.Content
            };
        }
    }
}