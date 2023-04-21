using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Repositories;
using Go2Climb.API.Persistence.Contexts;
using Go2Climb.API.Reviews.Domain.Models;
using Go2Climb.API.Reviews.Domain.Repositories;
using Go2Climb.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Go2Climb.API.Reviews.Persistence.Repositories
{
    public class AgencyReviewsRepository : BaseRepository, IAgencyReviewRepository
    {
        public AgencyReviewsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<AgencyReview>> ListAsync()
        {
            return await _context.AgencyReviews.ToListAsync();
        }

        public async Task<IEnumerable<AgencyReview>> ListByAgencyId(int agencyId)
        {
            return await _context.AgencyReviews.Where(p => p.AgencyId == agencyId).Include(x => x.Customer).ToListAsync();
        }

        public async Task<IEnumerable<AgencyReview>> ListByCustomerId(int customerId)
        {
            return await _context.AgencyReviews.Where(p => p.CustomerId == customerId).ToListAsync();
        }

        public async Task<AgencyReview> FindByIdAsync(int id)
        {
            return await _context.AgencyReviews
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(AgencyReview agencyReview)
        {
            await _context.AgencyReviews.AddAsync(agencyReview);
            Console.WriteLine("aqui");
        }
        
        public void Remove(AgencyReview agencyReview)
        {
            _context.AgencyReviews.Remove(agencyReview);
        }

        Task<IEnumerable<AgencyReview>> IAgencyReviewRepository.ListAsync()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<AgencyReview>> IAgencyReviewRepository.ListByAgencyId(int agencyId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<AgencyReview>> IAgencyReviewRepository.ListByCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(AgencyReview agencyReview)
        {
            throw new NotImplementedException();
        }

        Task<AgencyReview> IAgencyReviewRepository.FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(AgencyReview agencyReview)
        {
            throw new NotImplementedException();
        }
    }
}