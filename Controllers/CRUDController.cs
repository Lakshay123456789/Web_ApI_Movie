using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using testWebAPI.Models;
using testWebAPI.Repository;

namespace testWebAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[Controller]")]
    public class CRUDController : ControllerBase
    {
        private readonly IGenericRepository<Movie> _genericRepository;

        private readonly IWebHostEnvironment _webHostEnvironment;
        public CRUDController(IGenericRepository<Movie> movie, IWebHostEnvironment webHostEnvironment)
        {
            _genericRepository = movie;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            var result = _genericRepository.GetAll();
            if (result.Result != null)
            {
                return Ok(result.Result);
            }
            return NotFound();
        }
        [HttpGet("GetById/{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            var result = _genericRepository.Get(id);
            if (result.Result != null)
            {
                return new JsonResult((Movie)result.Result);
            }
            return NotFound();
        }

        [HttpPost("add")]
        public IActionResult Add(Movie model)
        {
            var movie = new Movie
            {
                Id = model.Id,
                MovieName = model.MovieName,
                MovieDate = model.MovieDate,
                MovieGenre = model.MovieGenre,
                MovieCast = model.MovieCast,
            };
             _genericRepository.Insert(movie);
            return Ok();
        }
    }
}


