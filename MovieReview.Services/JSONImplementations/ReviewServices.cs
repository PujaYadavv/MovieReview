using MovieReview.Core.Models;
using MovieReview.Core.Interfaces;
using Newtonsoft.Json;

namespace MovieReview.Services.JSONImplementations
{
    public class ReviewServices : IReviewService
    {
        string jsonFilePath = @"C:\Users\Puja.Kumari\Desktop\MovieReviewDB.json";

        private IMovieServices _movieServices;
        public ReviewServices(IMovieServices movieServices)
        {
            _movieServices = movieServices;
        }

        public async Task<List<Review>> GetAllReview(int movieId)
        {
            return await Task.Run(() =>
            {
                string moviesString = File.ReadAllText(jsonFilePath);
                List<Movie> existingMovies = JsonConvert.DeserializeObject<List<Movie>>(moviesString);

                if (existingMovies != null)
                {
                    Movie existingMovie = existingMovies.FirstOrDefault(m => m.Id == movieId);
                    if (existingMovie != null)
                    {
                        return existingMovie.Reviews;
                    }
                }
                return null;
            });

        }
        public async Task<Review> GetReview(int movieId, int id)
        {
            return await Task.Run(() =>
            {
                string moviesString = File.ReadAllText(jsonFilePath);
                List<Movie> existingMovies = JsonConvert.DeserializeObject<List<Movie>>(moviesString);

                if (existingMovies != null)
                {
                    Movie existingMovie = existingMovies.FirstOrDefault(m => m.Id == movieId);
                    if (existingMovie != null)
                    {
                        if (existingMovie.Reviews != null)
                        {
                            Review review = existingMovie.Reviews.FirstOrDefault(r => r.Id == id);
                            if (review != null)
                            {
                                return review;
                            }
                        }
                    }
                }
                return null;
            });
        }

        public async Task<bool> CreateReview(int movieId, Review review)
        {
            return await Task.Run(() =>
            {
                string moviesString = File.ReadAllText(jsonFilePath);
                List<Movie> existingMovies = JsonConvert.DeserializeObject<List<Movie>>(moviesString);

                if (existingMovies != null)
                {
                    Movie existingMovie = existingMovies.FirstOrDefault(m => m.Id == movieId);
                    if (existingMovie != null)
                    {
                        if (existingMovie.Reviews == null)
                        {
                            existingMovie.Reviews = new List<Review>();
                        }
                        existingMovie.Reviews.Add(review);
                    }
                }

                string movieString = JsonConvert.SerializeObject(existingMovies, Formatting.Indented);
                File.WriteAllText(jsonFilePath, movieString);

                return true;
            });
        }
        public async Task<bool> UpdateReview(int movieId, Review review)
        {
            return await Task.Run(() =>
            {
                string moviesString = File.ReadAllText(jsonFilePath);
                List<Movie> existingMovies = JsonConvert.DeserializeObject<List<Movie>>(moviesString);

                if (existingMovies != null)
                {
                    Movie existingMovie = existingMovies.FirstOrDefault(m => m.Id == movieId);
                    if (existingMovie != null)
                    {
                        Review existingReview = existingMovie.Reviews.FirstOrDefault(r => r.Id == review.Id);
                        if (existingReview != null)
                        {
                            existingReview = review;
                        }
                    }
                }

                string movieString = JsonConvert.SerializeObject(existingMovies, Formatting.Indented);
                File.WriteAllText(jsonFilePath, movieString);

                return true;
            });
        }

        public async Task<bool> DeleteReview(int movieId, int id)
        {
            return await Task.Run(() =>
            {
                string moviesString = File.ReadAllText(jsonFilePath);
                List<Movie> existingMovies = JsonConvert.DeserializeObject<List<Movie>>(moviesString);

                if (existingMovies != null)
                {
                    Movie existingMovie = existingMovies.FirstOrDefault(m => m.Id == movieId);
                    if (existingMovie != null)
                    {
                        if (existingMovie.Reviews != null)
                        {
                            existingMovie.Reviews.RemoveAll(r => r.Id == id);
                        }
                    }
                }

                string movieString = JsonConvert.SerializeObject(existingMovies, Formatting.Indented);
                File.WriteAllText(jsonFilePath, movieString);

                return true;
            });
        }
    }
}
