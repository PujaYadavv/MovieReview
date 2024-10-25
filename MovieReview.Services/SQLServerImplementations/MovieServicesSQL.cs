using MovieReview.Core.Models;
using MovieReview.Core.Interfaces;
using Moviereview.Repository;

namespace MovieReview.Services.SQLServerImplementations
{
    public class MovieServicesSQL : IMovieServices
    {
        private IMovieReviewRepository _repository;

        public MovieServicesSQL(IMovieReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            return await Task.Run(() =>
            {
                return _repository.GetAllMovies();
            });
        }
        public async Task<Movie> GetMovie(int id)
        {
            return await Task.Run(() =>
            {
                return _repository.GetMovie(id);
            });
        }
        public async Task<Movie> GetMovieByName(string name)
        {
            return await Task.Run(() =>
            {
                return _repository.GetMovieByName(name);
            });
        }
        public async Task<bool> CreateMovie(Movie movie)
        {

            return await Task.Run(() =>
            {
                return _repository.CreateMovie(movie);
            });
        }
        public async Task<bool> UpdateMovie(Movie movie)
        {

            return await Task.Run(() =>
            {
                return _repository.UpdateMovie(movie);
            });
        }

        public async Task<bool> DeleteMovie(int id)
        {

            return await Task.Run(() =>
            {
                return _repository.DeleteMovie(id);
            });
        }

       

       

       
    }
}
