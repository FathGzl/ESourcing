﻿using Esourcing.Sourcing.Entities;
using MongoDB.Driver;

namespace ESourcing.Sourcing.Data.Interface
{
    public interface ISourcingContext
    {
        public interface ISourcingContext
        {
            IMongoCollection<Auction> Auctions { get; }
            IMongoCollection<Bid> Bids { get; }
        }
    }
}