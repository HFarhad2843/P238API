using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P238MovieAPi.Data;
using P238MovieAPi.DTOs.MovieDTOs;
using P238MovieAPi.Entities;

namespace P238MovieAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        private int Id;
        private string Name;

        public string Description { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime UpdateDate { get; private set; }

        private int GenreId;
        private double Price;

        public double CostPrice { get; private set; }

        public MoviesController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var movies = await appDbContext.Movies.ToListAsync();
            List<MovieGetDto> movieDtos = new List<MovieGetDto>();

            movieDtos = movies.Select(m => new MovieGetDto()
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                GenreId = m.GenreId,
                Price = m.Price
            }).ToList();
            foreach (var movie in movies)
            {
                MovieGetDto dto = new MovieGetDto();
                {
                    Id = movie.Id;
                    Name = movie.Name;
                    Description = movie.Description;
                    GenreId = movie.GenreId;
                    Price = movie.Price;
                };
                movieDtos.Add(dto);
            }
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await appDbContext.Movies.FindAsync(id);
            if (movie == null) return NotFound();
            MovieGetDto movieGetDto = new MovieGetDto()
            {
                Id = movie.Id,
                Name = movie.Name,
                Description = movie.Description,
                GenreId = movie.GenreId,
                Price = movie.Price

            };
            return Ok(movie);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create( MovieCreateDto dto) 
        {
            Movie movie = new Movie();
            {
                Name = dto.Name;
                Description = dto.Description;
                GenreId = dto.GenreId;
                Price = dto.Price;
                CostPrice = dto.CostPrice;
                IsDeleted = dto.IsDeleted;
                CreateDate = DateTime.Now;
                UpdateDate = DateTime.Now;

            }
            await this.appDbContext.AddAsync(movie);
            await this.appDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
