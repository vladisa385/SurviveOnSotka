using System;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CQRSOperation;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.Reviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.Reviews
{
    public class ReviewQuery : Query<ReviewResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ReviewQuery(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        protected override async Task<ReviewResponse> QueryItem(Guid reviewId)
        {
            var response = await _context.Reviews
                 .ProjectTo<ReviewResponse>(_mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync(p => p.Id == reviewId);
            return response;
        }
    }
}
