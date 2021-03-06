﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.Reviews;
using System.Linq;
using SurviveOnSotka.DataAccess.BaseOperation;

namespace SurviveOnSotka.DataAccess.DbImplementation.Reviews
{
    public class ReviewsListQuery : ListQuery<ReviewResponse, ReviewFilter>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ReviewsListQuery(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override IQueryable<ReviewResponse> ApplyFilter(IQueryable<ReviewResponse> query, ReviewFilter filter)
        {
            if (filter.Id != null)
                query = query.Where(p => p.Id == filter.Id);
            if (filter.Text != null)
                query = query.Where(p => p.Text.Contains(filter.Text));
            if (filter.Rate != null)
            {
                if (filter.Rate.From != null)
                    query = query.Where(p => p.Rate >= filter.Rate.From);

                if (filter.Rate.To != null)
                    query = query.Where(p => p.Rate <= filter.Rate.To);
            }
            if (filter.DateCreated != null)
                query = query.Where(p => p.DateCreated >= filter.DateCreated);
            if (filter.UserId != null)
                query = query.Where(p => p.User.Id == filter.UserId);
            if (filter.RecipeId != null)
                query = query.Where(p => p.RecipeId == filter.RecipeId);
            if (filter.DisLikes != null)
            {
                if (filter.DisLikes.From != null)
                    query = query.Where(p => p.DisLikes >= filter.DisLikes.From);

                if (filter.DisLikes.To != null)
                    query = query.Where(p => p.DisLikes <= filter.DisLikes.To);
            }
            if (filter.Likes != null)
            {
                if (filter.Likes.From != null)
                    query = query.Where(p => p.Likes >= filter.Likes.From);

                if (filter.Likes.To != null)
                    query = query.Where(p => p.Likes <= filter.Likes.To);
            }
            return query;
        }

        protected override IQueryable<ReviewResponse> GetQuery() =>
            _context.Reviews
                .Include("Ingredients")
                .ProjectTo<ReviewResponse>(_mapper.ConfigurationProvider);
    }
}