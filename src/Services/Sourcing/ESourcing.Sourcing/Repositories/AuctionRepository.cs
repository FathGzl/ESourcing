using ESourcing.Sourcing.Entities;
using ESourcing.Sourcing.Repositories.Interfaces;
using ESourcing.Sourcing.Data.Interface;
using MongoDB.Driver;

namespace ESourcing.Sourcing.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly ISourcingContext _context;

        public AuctionRepository(ISourcingContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Auction auction)
        {
            await _context.Auctions.InsertOneAsync(auction);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            FilterDefinition<Auction> filter = Builders<Auction>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _context.Auctions.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Auction> GetAuctionAsync(string id)
        {
            return await _context.Auctions.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Auction> GetAuctionByNameAsync(string name)
        {
            FilterDefinition<Auction> filter = Builders<Auction>.Filter.Eq(m => m.Name, name);

            return await _context.Auctions.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Auction>> GetAuctionsAsync()
        {
            return await _context.Auctions.Find(a => true).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Auction auction)
        {
            var updateResult = await _context.Auctions.ReplaceOneAsync(a => a.Id.Equals(auction.Id), auction);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}