using System;
using System.Threading.Tasks;
using ArticleManagement.Business.Abstract;
using ArticleManagement.Business.DTOs.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArticleManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;
        private readonly ILogger<ArticleController> _logger;

        public ArticleController(IArticleService articleService, ICommentService commentService, ILogger<ArticleController> logger)
        {
            _articleService = articleService;
            _commentService = commentService;

            _logger = logger;
        }

        // GET Article
        [HttpGet("/Article")]
        public IActionResult Get()
        {
            var articles = _articleService.Articles();

            _logger.LogInformation($"Get call all articles {DateTime.Now:U}");
            return Ok(articles);
        }

        // GET Article/1
        [HttpGet("{articledId}")]
        public async Task<IActionResult> Get(int articledId)
        {
            var article = await _articleService.GetArticle(articledId);

            _logger.LogInformation($"Get article with {articledId} {DateTime.Now:U}");
            return Ok(article);
        }

        // POST Article
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequestArticle article)
        {
            var responseModel = await _articleService.AddArticle(article);

            return Created(string.Empty, $"{responseModel.Id}");
        }

        // PUT Article/5  
        [HttpPut("{articledId}")]
        public IActionResult Put(int articledId, [FromBody] RequestArticle article)
        {
            _articleService.UpdateArticle(articledId, article);

            return NoContent();
        }

        // DELETE Article/5  
        [HttpDelete("{articledId}")]
        public async Task<IActionResult> Remove(int articledId)
        {
            await _articleService.RemoveArticle(articledId);

            return NoContent();
        }

        //GET ArticleWithComments
        [HttpGet("/ArticleWithComments")]
        public IActionResult GetDetails()
        {
            var articles = _articleService.ArticlesWithComments();

            _logger.LogInformation($"Get call all articles with details {DateTime.Now:U}");
            return Ok(articles);
        }

        //GET ArticleWithComments/1/Comments
        [HttpGet("/Article/{articleId}/Comments")]
        public IActionResult GetDetails(int articleId)
        {
            var comments = _commentService.ArticlesWithComments(articleId);

            return Ok(comments);
        }

        //GET ArticleWithComments/1/Comments/1
        [HttpGet("/Article/{articleId}/Comments/{commentId}")]
        public IActionResult GetDetails(int articleId, int commentId)
        {
            var comments = _commentService.ArticlesWithComment(articleId, commentId);

            return Ok(comments);
        }
    }
}