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
    [Route("/api/genres")]
    public class GenreController : Controller
    {
         private readonly IMapper mapper;
         private readonly AmidusDbContext context;
         private readonly IGenreRepository repository;
         private readonly IUnitOfWork unitOfWork;

    public GenreController(AmidusDbContext context, IMapper mapper,IGenreRepository repository,IUnitOfWork unitOfWork)
    {
      this.mapper = mapper;
      this.context = context;
      this.repository = repository;
      this.unitOfWork = unitOfWork;

    }

    [HttpPost]
    public async Task<IActionResult> CreateGenre([FromBody] GenreResource genreResource)
    {
        if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var genre = mapper.Map<GenreResource, Genre>(genreResource);

      repository.Add(genre);
      await unitOfWork.CompleteAsync();

      genre = await repository.GetGenre(genre.Id);

      var result = mapper.Map<Genre,GenreResource>(genre);

      return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGenre(int id, [FromBody] GenreResource genreResource)
    {
        if (!ModelState.IsValid)
        return BadRequest(ModelState);

     var genre = await repository.GetGenre(id);

      if (genre == null)
        return NotFound();

      mapper.Map<GenreResource, Genre>(genreResource, genre);
      await unitOfWork.CompleteAsync();

      genre = await repository.GetGenre(genre.Id);
      var result = mapper.Map<Genre, GenreResource>(genre);

      return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGenre(int id)
    {
      var genre = await repository.GetGenre(id);

      if (genre == null)
        return NotFound();
      repository.Remove(genre);
      await unitOfWork.CompleteAsync();

      return Ok(id);
    }
    [HttpGet]
    public async Task<IEnumerable<GenreResource>> GetGenres()
    {
        var genres = await repository.GetGenres();

        return mapper.Map<IEnumerable<Genre>,IEnumerable<GenreResource>>(genres);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGenre(int id)
    {
      var genre = await repository.GetGenre(id);

      if (genre == null)
        return NotFound();

      var genreResource = mapper.Map<Genre, GenreResource>(genre);

      return Ok(genreResource);
    }
    }
}