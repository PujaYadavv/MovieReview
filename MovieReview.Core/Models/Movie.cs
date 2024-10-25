using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Core.Models
{
    public class Movie
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? Id { get; set; } = null;
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
