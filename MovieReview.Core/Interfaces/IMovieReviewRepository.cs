using MovieReview.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Core.Interfaces
{
    public interface IMovieReviewRepository
    {
        List<Movie> GetAllMovies();
        Movie GetMovie(int id);
        Movie GetMovieByName(string name);
        bool CreateMovie(Movie movie);
        bool UpdateMovie(Movie movie);
        bool DeleteMovie(int id);
        List<Review> GetAllReview(int movieId);
        Review GetReview(int movieId, int id);
        bool CreateReview(int movieId, Review review);
        bool UpdateReview(int movieId, Review review);
        bool DeleteReview(int movieId, int id);
    }
}
