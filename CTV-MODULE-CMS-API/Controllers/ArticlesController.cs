//using CTV_MODULE_CMS_API.Data;
//using CTV_MODULE_CMS_API.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ArticlesApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ArticlesController : ControllerBase
//    {
//        private readonly ApplicationDbContext _context;

//        public ArticlesController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Articles/Highlighted
//        [HttpGet("Highlighted")]
//        public async Task<ActionResult<IEnumerable<Articles>>> GetHighlightedArticles()
//        {
//            return await _context.Articles.Where(a => a.getHighlighted()).ToListAsync();
//        }

//        // GET: api/Articles/{id}
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Articles>> GetArticle(int id)
//        {
//            var article = await _context.Articles.FindAsync(id);

//            if (article == null)
//            {
//                return NotFound();
//            }

//            return article;
//        }
//    }
//}


//using CTV_MODULE_CMS_API.Models;
//using CTV_MODULE_CMS_API.Services;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace CTV_MODULE_CMS_API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ArticlesController : ControllerBase
//    {
//        private readonly ArticleService _articleService;

//        public ArticlesController(ArticleService articleService)
//        {
//            _articleService = articleService;
//        }

//        // GET: api/Articles/Highlighted
//        [HttpGet("Highlighted")]
//        public async Task<ActionResult<IEnumerable<Articles>>> GetHighlightedArticles()
//        {
//            var articles = await _articleService.GetHighlightedArticlesAsync();
//            return Ok(articles);
//        }

//        // GET: api/Articles/{id}
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Articles>> GetArticle(int id)
//        {
//            var article = await _articleService.GetArticleByIdAsync(id);

//            if (article == null)
//            {
//                return NotFound();
//            }

//            return Ok(article);
//        }

//        // GET: api/Articles
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Articles>>> GetAllArticles()
//        {
//            var articles = await _articleService.GetAllArticlesAsync();
//            return Ok(articles);
//        }

//        // Add more endpoints as needed
//    }
//}


using CTV_MODULE_CMS_API.Models;
using CTV_MODULE_CMS_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CTV_MODULE_CMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ArticleService _articleService;

        public ArticlesController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        // GET: api/Articles/Highlighted
        [HttpGet("Highlighted")]
        public async Task<ActionResult<IEnumerable<Articles>>> GetHighlightedArticles()
        {
            try
            {
                var articles = await _articleService.GetHighlightedArticlesAsync();
                return Ok(articles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Articles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Articles>> GetArticle(int id)
        {
            try
            {
                var article = await _articleService.GetArticleByIdAsync(id);

                if (article == null)
                {
                    return NotFound($"Article with ID {id} not found.");
                }

                return Ok(article);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Articles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articles>>> GetAllArticles()
        {
            try
            {
                var articles = await _articleService.GetAllArticlesAsync();
                return Ok(articles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Add more endpoints as needed
    }
}
