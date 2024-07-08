using GloboTicket.TicketManagement.Web.Services;
using GloboTicket.TicketManagement.Web.Services.Base;
using GloboTicket.TicketManagement.Web.ViewModels;

namespace GloboTicket.TicketManagement.Web.Contracts
{
    public interface ICategoryDataService
    {
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<List<CategoryEventsViewModel>> GetAllCategoriesWithEvents(bool includeHistory);
        Task<ApiResponse<CategoryDto>> CreateCategory(CategoryViewModel categoryViewModel);
    }
}
