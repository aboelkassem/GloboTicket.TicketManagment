using GloboTicket.TicketManagement.Web.ViewModels;

namespace GloboTicket.TicketManagement.Web.Contracts
{
    public interface IOrderDataService
    {
        Task<PagedOrderForMonthViewModel> GetPagedOrderForMonth(DateTime date, int page, int size);
    }
}
