﻿using ESourcing.Sourcing.Entities;

namespace ESourcing.Sourcing.Repositories.Interfaces
{
    public interface IBidRepository
    {
        Task SendBidAsync(Bid bid);
        Task<List<Bid>> GetBidsByAuctionIdAsync(string id);
        Task<List<Bid>> GetAllBidsByAuctionIdAsync(string id);
        Task<Bid> GetWinnerBidAsync(string id);
    }
}
