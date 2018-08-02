using AutoMapper;
using System.Linq;
using amidus.Controllers.Resources;
using amidus.Core.Models;


namespace amidus.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Genre, GenreResource>();
            CreateMap<Actor, ActorResource>().ForMember(vr => vr.FullName, opt => opt.MapFrom(v => v.FirstName +" " +v.LastName));
            
            CreateMap<Movie, MovieResource>()
              .ForMember(mr => mr.Genre, opt => opt.MapFrom(ge => new GenreResource{
                Id = ge.GenreId, Name = ge.Genre.Name, Description = ge.Genre.Description
              }))
              .ForMember(mr => mr.Actors, opt => opt.MapFrom(a => a.Actors.Select(ma=> new ActorResource{
                Id = ma.Actor.Id, FullName = ma.Actor.FirstName + " "+ ma.Actor.LastName, Description = ma.Actor.Description
              })));
            CreateMap<Movie, SaveMovieResource>()
              .ForMember(vr => vr.Genre, opt => opt.MapFrom(v => new GenreResource { Name = v.Genre.Name, Id = v.GenreId, Description = v.Genre.Description } ))
              .ForMember(vr => vr.Actors, opt => opt.MapFrom(v => v.Actors.Select(ma => ma.ActorId)));
            
            // API Resource to Domain
            CreateMap<GenreResource, Genre>();
            CreateMap<ActorResource, Actor>().ForMember(v => v.Id, opt => opt.Ignore());
            CreateMap<SaveMovieResource, Movie>().ForMember(v => v.Id, opt => opt.Ignore()).ForMember(v => v.Genre, opt => opt.Ignore()).ForMember(v => v.Actors, opt => opt.Ignore())
            .AfterMap((vr, v) => {
                // Remove unselected features
                var removedActors = v.Actors.Where(f => !vr.Actors.Contains(f.ActorId)).ToList();
                foreach (var f in removedActors)
                  v.Actors.Remove(f);

                // Add new features
                var addedActors = vr.Actors.Where(id => !v.Actors.Any(f => f.ActorId == id)).Select(id => new MovieActors { ActorId = id }).ToList();   
                foreach (var f in addedActors)
                    v.Actors.Add(f);
            });
            CreateMap<MovieResource, Movie>().ForMember(v => v.Id, opt => opt.Ignore()).ForMember(v => v.Genre, opt => opt.Ignore()).ForMember(v => v.Actors, opt => opt.Ignore());
           
        }
    }
}