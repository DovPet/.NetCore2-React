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
    [Route("/api/actors")]
    public class ActorController : Controller
    {
         private readonly IMapper mapper;
         private readonly AmidusDbContext context;
         private readonly IActorRepository repository;
         private readonly IUnitOfWork unitOfWork;

    public ActorController(AmidusDbContext context, IMapper mapper,IActorRepository repository,IUnitOfWork unitOfWork)
    {
      this.mapper = mapper;
      this.context = context;
      this.repository = repository;
      this.unitOfWork = unitOfWork;

    }

    [HttpPost]
    public async Task<IActionResult> CreateActor([FromBody] ActorResource actorResource)
    {
        if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var actor = mapper.Map<ActorResource, Actor>(actorResource);

      repository.Add(actor);
      await unitOfWork.CompleteAsync();

      actor = await repository.GetActor(actor.Id);

      var result = mapper.Map<Actor,ActorResource>(actor);

      return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateActor(int id, [FromBody] ActorResource actorResource)
    {
        if (!ModelState.IsValid)
        return BadRequest(ModelState);

     var actor = await repository.GetActor(id);

      if (actor == null)
        return NotFound();

      mapper.Map<ActorResource, Actor>(actorResource, actor);
      await unitOfWork.CompleteAsync();

      actor = await repository.GetActor(actor.Id);
      var result = mapper.Map<Actor, ActorResource>(actor);

      return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActor(int id)
    {
      var actor = await repository.GetActor(id);

      if (actor == null)
        return NotFound();
      repository.Remove(actor);
      await unitOfWork.CompleteAsync();

      return Ok(id);
    }
    [HttpGet]
    public async Task<IEnumerable<ActorResource>> GetActors()
    {
        var actors = await repository.GetActors();

        return mapper.Map<IEnumerable<Actor>,IEnumerable<ActorResource>>(actors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetActor(int id)
    {
      var actor = await repository.GetActor(id);

      if (actor == null)
        return NotFound();

      var actorResource = mapper.Map<Actor, ActorResource>(actor);

      return Ok(actorResource);
    }
    }
}