using MovieReview.Core.Models;
using MovieReview.Core.Interfaces;

namespace MovieReview.Services.SQLServerImplementations
{
    public class ReviewServicesSQL : IReviewService
    {
        private IMovieReviewRepository _repository;

        public ReviewServicesSQL(IMovieReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateReview(int movieId, Review review)
        {
            return await Task.Run(() =>
            {
                return _repository.CreateReview(movieId, review);
            });
        }

        public async Task<bool> DeleteReview(int movieId, int id)
        {
            return await Task.Run(() =>
            {
                return _repository.DeleteReview(movieId, id);
            });
        }

        public async Task<List<Review>> GetAllReview(int movieId)
        {
            return await Task.Run(() =>
            {
                return _repository.GetAllReview(movieId);
            });
        }

        public async Task<Review> GetReview(int movieId, int id)
        {
            return await Task.Run(() =>
            {
                return _repository.GetReview(movieId, id);
            });
        }

        public async Task<bool> UpdateReview(int movieId, Review review)
        {
            return await Task.Run(() =>
            {
                return _repository.UpdateReview(movieId, review);
            });
        }
    }
}
