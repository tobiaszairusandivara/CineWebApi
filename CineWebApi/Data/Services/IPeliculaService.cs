using CineWebApi.Data.Models;

namespace CineWebApi.Data.Services
{
    public interface IPeliculaService
    {
        List<Pelicula> RecupEstrenos();
        bool AgregarPelicula(Pelicula oPelicula);
        bool SacarDeEstreno(int id);
    }
}
