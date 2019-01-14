using AutoMapper;
using Library.API.Helpers;
using Library.API.Models;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    [Route("api/authors")]
    public class AuthorsController : Controller
    {
        private ILibraryRepository _libraryRepository;
        public AuthorsController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }
        [HttpGet]
        public IActionResult GetAuthors()
        {
          //  throw new Exception("Exception testing");
            var authorsFromRepo = _libraryRepository.GetAuthors();
            var authors = Mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo);
            //var authors = new List<AuthorDto>();
            //foreach (var author in authorsFromRepo)
            //{
            //    authors.Add(new AuthorDto()
            //    {
            //        Id = author.Id,
            //        Name = $"{author.FirstName} {author.LastName}",
            //        Age = author.DateOfBirth.GetCurrentAge(),
            //        Genre = author.Genre
            //    });
            //}
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(Guid id)
        {

            var authorFromRepo = _libraryRepository.GetAuthor(id);
            if(authorFromRepo == null) { return NotFound(); }
            var author = Mapper.Map<Models.AuthorDto>(authorFromRepo);
            return Ok(author);
        }
    }
}
