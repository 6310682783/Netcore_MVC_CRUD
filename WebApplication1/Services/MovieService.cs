using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAll();
        Task<Movie> GetById(int id);
        Task<bool> Add(Movie movie);
        Task<bool> Update(Movie movie);
        Task<bool> Delete(int id);
    }
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public async Task<bool> Add(Movie movie)
        {
            var result = await movieRepository.Add(movie);
            return result>1;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await movieRepository.Delete(id);
            return result > 0;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            var result = await movieRepository.GetAll();
            return result;
        }

        public async Task<Movie> GetById(int id)
        {
            var result = await movieRepository.GetById(id);
            return result;
        }

        public async Task<bool> Update(Movie movie)
        {
            var model = await movieRepository.GetById(movie.id);
            model.title = movie?.title;
            model.url = movie?.url;
            model.description = movie?.description;
            model.video = movie?.video;
            var result = await movieRepository.Update(model);
            return (result > 0);
        }
    }
}
