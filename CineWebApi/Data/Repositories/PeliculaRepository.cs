using CineWebApi.Data.Models;

namespace CineWebApi.Data.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly CineDbContext _context;

        public PeliculaRepository(CineDbContext context)
        {
            _context = context;
        }

        public bool Create(Pelicula oPelicula)
        {
            _context.Peliculas.Add(oPelicula);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var pelExists = _context.Peliculas.Find(id);
            if(pelExists != null)
            {
                pelExists.Estreno = false;
                _context.Peliculas.Update(pelExists);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public List<Pelicula> GetAll()
        {
            return _context.Peliculas
                .Where(x => x.Estreno == true)
                .ToList();
        }
    }
}
