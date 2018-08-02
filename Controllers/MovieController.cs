using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using amidus.Controllers.Resources;
using amidus.Core;
using amidus.Core.Models;
using amidus.Persistence;

namespace amidus.Controllers
{
    [Route("/api/movies")]
    public class MovieController : Controller
    {
         private readonly IMapper mapper;
         private readonly AmidusDbContext context;
         private readonly IMovieRepository repository;
         private readonly IUnitOfWork unitOfWork;

    public MovieController(AmidusDbContext context, IMapper mapper,IMovieRepository repository,IUnitOfWork unitOfWork)
    {
      this.mapper = mapper;
      this.context = context;
      this.repository = repository;
      this.unitOfWork = unitOfWork;

    }

    [HttpPost]
    public async Task<IActionResult> CreateMovie([FromBody] SaveMovieResource movieResource)
    {
    if (!ModelState.IsValid)
    return BadRequest(ModelState);

      var movie = mapper.Map<SaveMovieResource, Movie>(movieResource);

      repository.Add(movie);
      await unitOfWork.CompleteAsync();

      movie = await repository.GetMovie(movie.Id);

      var result = mapper.Map<Movie,MovieResource>(movie);

      return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMovie(int id, [FromBody] SaveMovieResource movieResource)
    {
        if (!ModelState.IsValid)
        return BadRequest(ModelState);

     var movie = await repository.GetMovie(id);

      if (movie == null)
        return NotFound();

      mapper.Map<SaveMovieResource, Movie>(movieResource, movie);
      await unitOfWork.CompleteAsync();

      movie = await repository.GetMovie(movie.Id);
      var result = mapper.Map<Movie, MovieResource>(movie);

      return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteMovie(int id)
    {
      var movie = await repository.GetMovie(id);

      if (movie == null)
        return NotFound();
      repository.Remove(movie);
      await unitOfWork.CompleteAsync();

      return Ok(id);
    }
    [HttpGet]
    public async Task<IEnumerable<MovieResource>> GetMovies()
    {
        var movies = await repository.GetMovies();

        return mapper.Map<IEnumerable<Movie>,IEnumerable<MovieResource>>(movies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovie(int id)
    {
      var movie = await repository.GetMovie(id);

      if (movie == null)
        return NotFound();

      var movieResource = mapper.Map<Movie, MovieResource>(movie);

      return Ok(movieResource);
      }
    }
}