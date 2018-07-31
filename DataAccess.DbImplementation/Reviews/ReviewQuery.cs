using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Reviews;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Reviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.Reviews
{
    public class ReviewQuery : IReviewQuery
    {
        private readonly AppDbContext _context;

        public ReviewQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ReviewResponse> RunAsync(Guid reviewId)
        {
            ReviewResponse response = await _context.Reviews
                .ProjectTo<ReviewResponse>()
                .FirstOrDefaultAsync(p => p.Id == reviewId);
            return response;
        }
    }
}
