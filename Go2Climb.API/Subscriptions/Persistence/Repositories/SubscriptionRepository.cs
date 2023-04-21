using Go2Climb.API.Persistence.Contexts;
using Go2Climb.API.Shared.Persistence.Repositories;
using Go2Climb.API.Subscriptions.Domain.Models;
using Go2Climb.API.Subscriptions.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Go2Climb.API.Subscriptions.Persistence.Repositories
{
    public class SubscriptionRepository : BaseRepository, ISubscriptionRepository
    {
        public SubscriptionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Subscription>> ListAsync()
        {
            return await _context.Subscriptions.ToListAsync();
        }

        public async Task<IEnumerable<Subscription>> ListById(int id)
        {
            return await _context.Subscriptions.Where(p => p.Id == id).ToListAsync();
        }

        public async Task AddAsync(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);
        }

        public void Update(Subscription subscription)
        {
            _context.Subscriptions.Update(subscription);
        }

        public void Remove(Subscription subscription)
        {
            _context.Subscriptions.Remove(subscription);
        }

        public async Task<Subscription> FindById(int id)
        {
            return await _context.Subscriptions.FindAsync(id);
        }
    }
}