using MovieReview.Core.Interfaces;
using MovieReview.Core.Models;


namespace Moviereview.Repository
{
    public class MovieReviewRepository : IMovieReviewRepository
    {
        public List<Movie> GetAllMovies()
        {
            List<Movie> movies = null;
            using (MovieReviewContext context = new MovieReviewContext())
            {
                movies = context.Movies.ToList();
            }
            return movies;
        }
        public Movie GetMovie(int id)
        {
            Movie movie = null;
            using (MovieReviewContext context = new MovieReviewContext())
            {
                movie = context.Movies.FirstOrDefault(m => m.Id == id);
                if(movie != null)
                {
                    movie.Reviews = context.Reviews.Where(r => r.Id == id).ToList();
                }
            }
            return movie;
        }
        public Movie GetMovieByName(string name)
        {
            Movie movie = null; 
            using(MovieReviewContext context=new MovieReviewContext())
            {
                movie = context.Movies.FirstOrDefault(m => m.MovieName.Equals(name));
            }
            return movie;
        }
        public bool CreateMovie(Movie movie)
        {
            bool result = false;
            using (MovieReviewContext context = new MovieReviewContext())
            {
                context.Movies.Add(movie);
                int noOfRowsUpdated = context.SaveChanges();
                if (noOfRowsUpdated > 0)
                {
                    result = true;
                }
            }
            return result;
        }
        public bool UpdateMovie(Movie movie)
        {
            bool result = false;
            using (MovieReviewContext context = new MovieReviewContext())
            {
                Movie existingMovie = context.Movies.FirstOrDefault(m => m.Id == movie.Id);
                if (existingMovie != null)
                {
                    context.Movies.Update(movie);
                    int noOfRowsUpdated = context.SaveChanges();
                    if (noOfRowsUpdated > 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        public bool DeleteMovie(int id)
        {
            bool result = false;
            using (MovieReviewContext context = new MovieReviewContext())
            {
                Movie existingMovie = context.Movies.FirstOrDefault(m => m.Id == id);
                if (existingMovie != null)
                {
                    context.Movies.Remove(existingMovie);
                    int noOfRowsAffected = context.SaveChanges();
                    if(noOfRowsAffected > 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        public List<Review> GetAllReview(int movieId)
        {
            List<Review> reviews = null;
            using (MovieReviewContext context = new MovieReviewContext())
            {
                reviews = context.Reviews.Where(r => r.MovieId == movieId).ToList();
            }
            return reviews;
        }

        public Review GetReview(int movieId, int id)
        {
            Review review = null;
            using(MovieReviewContext context = new MovieReviewContext())
            {
                Movie existingMovie = context.Movies.FirstOrDefault(m => m.Id == movieId);
                if (existingMovie != null)
                {
                    review = context.Reviews.FirstOrDefault(r => r.Id == id);
                }
            }
            return review;
        }
        public bool CreateReview(int movieId, Review review)
        {
            bool result = false;
            using(MovieReviewContext context = new MovieReviewContext())
            {
                Movie existingMovie = context.Movies.FirstOrDefault(m => m.Id == movieId);
                if (existingMovie != null)
                {
                    review.MovieId = movieId;
                    context.Reviews.Add(review);
                    int noOfRowsAffected = context.SaveChanges();
                    if (noOfRowsAffected > 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        public bool UpdateReview(int movieId, Review review)
        {
            bool result = false;
            using (MovieReviewContext context = new MovieReviewContext())
            {
                Movie existingMovie = context.Movies.FirstOrDefault(m => m.Id == movieId);
                if (existingMovie != null)
                {
                    review.MovieId = movieId;
                    context.Reviews.Update(review);
                    int noOfRowsAffected = context.SaveChanges();
                    if (noOfRowsAffected > 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        public bool DeleteReview(int movieId, int id)
        {
            bool result = false;
            using (MovieReviewContext context = new MovieReviewContext())
            {
                Movie existingMovie = context.Movies.FirstOrDefault(m => m.Id == movieId);
                if (existingMovie != null)
                {
                    Review existingReview = context.Reviews.FirstOrDefault(r => r.Id == id);
                    if(existingReview != null)
                    {
                        context.Reviews.Remove(existingReview);
                        int noOfRowsAffected = context.SaveChanges();
                        if(noOfRowsAffected > 0)
                        {
                            result = true;
                        }
                    }
                }
            }
            return result;
        }

        
    }
}
