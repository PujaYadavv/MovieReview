using MovieReview.Core.Models;
using MovieReview.Core.Interfaces;
using Newtonsoft.Json;

namespace MovieReview.Services
{
    public class MovieServices : IMovieServices
    {
        string jsonFilePath = @"C:\Users\Puja.Kumari\Desktop\MovieReviewDB.json";

        public async Task<List<Movie>> GetAllMovies()
        {
            return await Task.Run(() =>
            {
                //Special error handling
                try
                {
                    string moviesString = File.ReadAllText(jsonFilePath);
                    List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(moviesString);
                    return movies;
                }
                catch (Exception ex)
                {

                }
                return null;
            });
        }

        public async Task<Movie> GetMovie(int id)
        {
            return await Task.Run(() =>
            {
                string moviesString = File.ReadAllText(jsonFilePath);
                List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(moviesString);
                Movie movie = movies.FirstOrDefault(m => m.Id == id);
                return movie;
            });
        }
        public async Task<Movie> GetMovieByName(string name)
        {
            return await Task.Run(() =>
            {
                string moviesString = File.ReadAllText(jsonFilePath);
                List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(moviesString);
                Movie movie = movies.FirstOrDefault(m => m.Equals(name));
                return movie;
            });
            
        }

        public async Task<bool> CreateMovie(Movie movie)
        {
            return await Task.Run(() =>
            {
                string moviesString = File.ReadAllText(jsonFilePath);
                List<Movie> existingMovies = JsonConvert.DeserializeObject<List<Movie>>(moviesString);

                if (existingMovies == null)
                {
                    existingMovies = new List<Movie>();
                }
                //Movie mov = existingMovies.FirstOrDefault(m => m.Id == movie.Id);
                //if(mov == null)
                //{
                //    existingMovies.Add(movie);
                //    string movieString = JsonConvert.SerializeObject(existingMovies, Formatting.Indented);
                //    File.WriteAllText(jsonFilePath, movieString);
                //}
                //else
                //{
                //    Console.WriteLine("move id already exist");
                //}

                existingMovies.Add(movie);

                string movieString = JsonConvert.SerializeObject(existingMovies, Formatting.Indented);
                File.WriteAllText(jsonFilePath, movieString);
                return true;
            });
        }

        public async Task<bool> UpdateMovie(Movie movie)
        {
            return await Task.Run(() =>
            {
                string moviesString = File.ReadAllText(jsonFilePath);
                List<Movie> existingMovies = JsonConvert.DeserializeObject<List<Movie>>(moviesString);

                if (existingMovies != null)
                {
                    int existingMovieIndex = existingMovies.FindIndex(m => m.Id == movie.Id);
                    if (existingMovieIndex > -1)
                    {
                        existingMovies[existingMovieIndex] = movie;
                    }
                }

                string movieString = JsonConvert.SerializeObject(existingMovies, Formatting.Indented);
                File.WriteAllText(jsonFilePath, movieString);
                return true;
            });
        }

        public async Task<bool> DeleteMovie(int id)
        {
            return await Task.Run(() =>
            {
                throw new Exception("simply throwing");

                string moviesString = File.ReadAllText(jsonFilePath);
                List<Movie> existingMovies = JsonConvert.DeserializeObject<List<Movie>>(moviesString);

                if (existingMovies != null)
                {
                    //Movie existingMovie = existingMovies.FirstOrDefault(m => m.Id == id);
                    //if (existingMovie != null)
                    //{
                    //    existingMovies.Remove(existingMovie);
                    //}
                    existingMovies.RemoveAll(m => m.Id == id);
                }

                string movieString = JsonConvert.SerializeObject(existingMovies, Formatting.Indented);
                File.WriteAllText(jsonFilePath, movieString);

                return true;
            });
        }
    }

    
}
