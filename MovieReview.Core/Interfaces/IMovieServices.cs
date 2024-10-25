using MovieReview.Core.Models;

namespace MovieReview.Core.Interfaces
{
    public interface IMovieServices
    {
        Task<List<Movie>> GetAllMovies();
        Task<Movie> GetMovie(int id);
        Task<Movie> GetMovieByName(string name);
        Task<bool> CreateMovie(Movie movie);
        Task<bool> UpdateMovie(Movie movie);
        Task<bool> DeleteMovie(int id);
    }
}
