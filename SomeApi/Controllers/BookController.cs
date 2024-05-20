using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SomeApi.Models;

namespace SomeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public BookController (MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Start by creating a book here!
        /// </summary>
        /// <param name="name"></param>
        /// <param name="authorName"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task CreateBook(string name, string authorName)
        {
            await _dbContext.Set<Book>().AddAsync(new Book { Name = name, Author = authorName});
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Try to get all the books now! volume persists!
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _dbContext.Books.ToListAsync();
        }
    }
}