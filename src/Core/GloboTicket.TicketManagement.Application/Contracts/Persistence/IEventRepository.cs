using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Contracts.Persistence;

// Specific Repository
public interface IEventRepository : IAsyncRepository<Event>
{
    Task<bool> IsEventAndDateUnique(string name, DateTime date);
}
