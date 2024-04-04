using AutoMapper;
using EventBusRabbitMQ.Event;
using Ordering.Application.Commands.OrderCreate;

namespace ESourcing.Order.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<OrderCreateEvent, OrderCreateCommand>().ReverseMap();
        }
    }
}
