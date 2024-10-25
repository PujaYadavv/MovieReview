using MovieReview.Core.Models;

namespace MovieReview.Core.Interfaces
{
    public interface IReviewService
    {
        Task<List<Review>> GetAllReview(int movieId);
        Task<Review> GetReview(int movieId, int id);
        Task<bool> CreateReview(int movieId, Review review);
        Task<bool> UpdateReview(int movieId, Review review);
        Task<bool> DeleteReview(int movieId, int id);
    }
}
