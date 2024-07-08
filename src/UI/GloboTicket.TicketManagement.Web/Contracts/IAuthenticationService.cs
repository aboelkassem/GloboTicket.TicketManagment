using GloboTicket.TicketManagement.Web.Services.Base;

namespace GloboTicket.TicketManagement.Web.Contracts
{
    public interface IAuthenticationService
    {
        Task<ApiResponse> Login(string email, string password);
        Task<ApiResponse> Register(string email, string password);
        Task Logout();
    }
}
