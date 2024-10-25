using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Core.Models
{
    public class Review
    {
        public int? Id { get; set; }
        public int MovieId { get; set; } 
        public string ReviewBy { get; set; }
        public string ReviewDescription { get; set; }
    }
}
