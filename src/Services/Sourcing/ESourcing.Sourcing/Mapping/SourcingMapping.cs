using AutoMapper;
using ESourcing.Sourcing.Entities;
using EventBusRabbitMQ.Event;

namespace ESourcing.Sourcing.Mapping
{
    public class SourcingMapping : Profile
    {
        public SourcingMapping()
        {
            CreateMap<OrderCreateEvent, Bid>().ReverseMap();
        }
    }
}
