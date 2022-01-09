using ApiAspNetCoreServer.DataModel;
using ApiAspNetCoreServer.DataModel.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAspNetCoreServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly LibraryContext _libraryContext;

        public BooksController(ILogger<BooksController> logger, 
            LibraryContext libraryContext)
        {
            _logger = logger;
            _libraryContext = libraryContext;
        }

        [HttpGet]
        public IEnumerable<BookDto> Get()
        {
            return _libraryContext.Books
                .Include(x=> x.Languages)
                .Include(x => x.Authors)
                .Select(x=> new BookDto() { 
                Id = x.Id,
                Annotation = x.Annotation,
                Cost = x.Cost,
                CreateAt = x.CreateAt,
                Year = x.Year,
                Name = x.Name,
                Isbn = x.Isbn,
                IsArchive = x.IsArchive,
                CurrencyType = x.CurrencyType.Name,
                Genre = x.Genre.Name,
                Authors = x.Authors.Select(y=> new AuthorDto() { 
                    Id = y.Id,
                    FirstName = y.FirstName,
                    LastName = y.LastName,
                    Birthday = y.Birthday,
                    Gender = y.Gender                    
                }).ToList(),
                Languages = x.Languages.Select(y=> new LanguageDto() { 
                    Name = y.Name,
                    Id = y.Id                
                }).ToList()
            
            });
        }

        [HttpPost]
        public int Post(BookDto dto)
        {
            var currencyType = _libraryContext.CurrencyTypes.FirstOrDefault(x => x.LetterCode.ToLower().Trim() == dto.CurrencyType.ToLower().Trim());
            if (currencyType == null)
                throw new Exception("CurrencyType not found");

            var genre = _libraryContext.Genres.FirstOrDefault(x => x.Name.ToLower().Trim() == dto.Genre.ToLower().Trim());
            if (currencyType == null)
                throw new Exception("Genre not found");

            var languageNames = dto.Languages.Where(x => !x.Id.HasValue).Select(x => x.Name).ToList();
            var languages = _libraryContext.Languages.Where(x => languageNames.Contains(x.Name)).ToList();
            var authors = new List<Author>();

            foreach (var authorDto in dto.Authors)
            {
                var author = _libraryContext.Authors.FirstOrDefault(x=> x.LastName == authorDto.LastName && x.FirstName == authorDto.FirstName && x.Birthday == authorDto.Birthday);
                if (author == null)
                    throw new Exception("Author not found");

                authors.Add(author);
            }

            var book = new Book() { 
                Annotation = dto.Annotation,
                Cost = dto.Cost,
                CreateAt = DateTime.Now,
                Isbn = dto.Isbn,
                IsArchive = dto.IsArchive,
                Name = dto.Name,
                Year = dto.Year,
                CurrencyType = currencyType,
                CurrencyTypeId = currencyType.Id,
                Genre = genre,
                GenreId = genre.Id,
                Languages = languages,                
                Authors = authors
            };

            _libraryContext.Add(book);
            _libraryContext.SaveChanges();

            return book.Id;
        }

        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public void Delete(int id)
        {
            var book = _libraryContext.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
                throw new Exception("Book not found");          

            _libraryContext.Remove(book);
            _libraryContext.SaveChanges();
        }
    }
}
