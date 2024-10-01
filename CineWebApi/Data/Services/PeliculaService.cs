using CineWebApi.Data.Models;
using CineWebApi.Data.Repositories;

namespace CineWebApi.Data.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaRepository _repository;

        public PeliculaService(IPeliculaRepository repository)
        {
            _repository = repository;
        }

        public bool AgregarPelicula(Pelicula oPelicula)
        {
            return _repository.Create(oPelicula);
        }

        public List<Pelicula> RecupEstrenos()
        {
            return _repository.GetAll();
        }

        public bool SacarDeEstreno(int id)
        {
            return _repository.Delete(id);
        }
    }
}
