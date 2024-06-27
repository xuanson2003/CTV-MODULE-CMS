
//using CTV_MODULE_CMS_API.Data;
//using CTV_MODULE_CMS_API.Models;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace CTV_MODULE_CMS_API.Services
//{
//    public class ArticleService
//    {
//        private readonly ApplicationDbContext _context;

//        public ArticleService(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<List<Articles>> GetHighlightedArticlesAsync()
//        {
//            return await _context.Articles.Where(a => a.getHighlighted()).ToListAsync();
//        }

//        public async Task<Articles> GetArticleByIdAsync(int id)
//        {
//            return await _context.Articles.FindAsync(id);
//        }

//        public async Task<List<Articles>> GetAllArticlesAsync()
//        {
//            return await _context.Articles.ToListAsync();
//        }

//        // Add more methods as needed for other operations
//    }
//}


using CTV_MODULE_CMS_API.Data;
using CTV_MODULE_CMS_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTV_MODULE_CMS_API.Services
{
    public class ArticleService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ArticleService> _logger;

        public ArticleService(ApplicationDbContext context, ILogger<ArticleService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Articles>> GetHighlightedArticlesAsync()
        {
            try
            {
                return await _context.Articles.Where(a => a.getHighlighted()).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting highlighted articles.");
                throw;
            }
        }

        public async Task<Articles> GetArticleByIdAsync(int id)
        {
            try
            {
                return await _context.Articles.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while getting article with ID {id}.");
                throw;
            }
        }

        public async Task<List<Articles>> GetAllArticlesAsync()
        {
            try
            {
                return await _context.Articles.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all articles.");
                throw;
            }
        }

        // Add more methods as needed for other operations
    }
}
