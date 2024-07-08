using AutoMapper;
using Blazored.LocalStorage;
using GloboTicket.TicketManagement.Web.Contracts;
using GloboTicket.TicketManagement.Web.Services.Base;
using GloboTicket.TicketManagement.Web.ViewModels;

namespace GloboTicket.TicketManagement.Web.Services
{
    public class OrderDataService : BaseDataService, IOrderDataService
    {
        private readonly IMapper _mapper;

        public OrderDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<PagedOrderForMonthViewModel> GetPagedOrderForMonth(DateTime date, int page, int size)
        {
            var orders = await _client.GetpagedordersformonthAsync(date, page, size);
            var mappedOrders = _mapper.Map<PagedOrderForMonthViewModel>(orders);
            return mappedOrders;
        }
    }
}
