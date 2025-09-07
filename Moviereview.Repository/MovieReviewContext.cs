using Microsoft.EntityFrameworkCore;
using MovieReview.Core.Models;

namespace Moviereview.Repository
{
    public class MovieReviewContext: DbContext
    {
        public MovieReviewContext()
        {
            Database.EnsureCreated();
            base.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(@"Server=127.0.0.1,1433; Database=MovieReviewDB; User=sa; Password=HAL@VSCPassword123; TrustServerCertificate=True;", options => options.CommandTimeout(300));
            optionsBuilder.UseSqlServer(@"Server = localhost,1433; Database = MyAppDB; User Id = sa; Password = Puja@9113446100; TrustServerCertificate = True;", options => options.CommandTimeout(300));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
