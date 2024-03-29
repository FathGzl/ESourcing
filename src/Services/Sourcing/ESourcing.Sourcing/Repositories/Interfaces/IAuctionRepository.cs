using ESourcing.Sourcing.Entities;

namespace ESourcing.Sourcing.Repositories.Interfaces
{
    public interface IAuctionRepository
    {
        Task<IEnumerable<Auction>> GetAuctionsAsync();
        Task<Auction> GetAuctionAsync(string id);
        Task<Auction> GetAuctionByNameAsync(string name);
        Task CreateAsync(Auction auction);
        Task<bool> UpdateAsync(Auction auction);
        Task<bool> DeleteAsync(string id);
    }
}