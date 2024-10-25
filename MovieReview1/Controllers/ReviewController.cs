  using Microsoft.AspNetCore.Mvc;
using MovieReview.Core.Models;
using MovieReview.Core.Interfaces;

namespace MovieReview.Server.Controllers
{
    [Route("api/v1/movies/{movieId}/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private IReviewService _reviewservices;
        public ReviewController(IReviewService reviewservices)
        {
            _reviewservices = reviewservices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReview(int movieId)
        {
            List<Review> review = await _reviewservices.GetAllReview(movieId);
            if (review != null)
            {
                return Ok(review);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview(int movieId, int id)
        {
            Review review = await _reviewservices.GetReview(movieId, id);
            if (review != null)
            {
                return Ok(review);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(int movieId, Review review)
        {
            bool result = await _reviewservices.CreateReview(movieId, review);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview(int movieId, Review review)
        {
            bool result = await _reviewservices.UpdateReview(movieId, review);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int movieId, int id)
        {
            bool result = await _reviewservices.DeleteReview(movieId, id);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
