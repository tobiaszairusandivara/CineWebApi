using CineWebApi.Data.Models;

namespace CineWebApi.Data.Repositories
{
    public interface IPeliculaRepository
    {
        List<Pelicula> GetAll();
        bool Create(Pelicula oPelicula);
        bool Delete(int id);
    }
}
