using Microsoft.EntityFrameworkCore;
using PaperFineryApp_Domain.Model;
using PaperFineryApp_Infrastructure.Persistence;
using PaperFineryApp_Infrastructure.Repository.Abstraction;

namespace PaperFineryApp_Infrastructure.Repository.Implementation
{
    public class ReviewRepository : CommandRepository<Review>, IReviewRepository
    {
        private readonly DbSet<Review> reviews;
        public ReviewRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            reviews = appDbContext.Reviews;
        }

        /// <summary>
        /// Checks for reviews where the username passed in the parameter
        /// is same as the username in the AppUser property in the Review
        /// </summary>
        /// <param name="userName"></param>
        /// <return name="Review"> review made by app user</returns>
       
        //Returns  all reviews
        public IQueryable<Review> GetAllReviews() => reviews; 
    }
}
