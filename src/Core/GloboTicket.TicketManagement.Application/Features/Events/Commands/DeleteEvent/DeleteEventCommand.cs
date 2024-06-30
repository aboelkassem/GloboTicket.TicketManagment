using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest
    {
        public Guid EventId { get; set; }
    }
}
