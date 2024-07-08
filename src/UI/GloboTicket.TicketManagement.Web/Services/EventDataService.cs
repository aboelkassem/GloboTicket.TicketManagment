using AutoMapper;
using Blazored.LocalStorage;
using GloboTicket.TicketManagement.Web.Contracts;
using GloboTicket.TicketManagement.Web.Services.Base;
using GloboTicket.TicketManagement.Web.ViewModels;

namespace GloboTicket.TicketManagement.Web.Services
{
    public class EventDataService: BaseDataService, IEventDataService
    {
        
        private readonly IMapper _mapper;

        public EventDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<EventListViewModel>> GetAllEvents()
        {
            var allEvents = await _client.ApiEventsGetAsync();
            var mappedEvents = _mapper.Map<ICollection<EventListViewModel>>(allEvents);
            return mappedEvents.ToList();
        }

        public async Task<EventDetailViewModel> GetEventById(Guid id)
        {
            var selectedEvent = await _client.ApiEventsGetAsync(id);
            var mappedEvent = _mapper.Map<EventDetailViewModel>(selectedEvent);
            return mappedEvent;
        }

        public async Task<ApiResponse<Guid>> CreateEvent(EventDetailViewModel eventDetailViewModel)
        {
            try
            {
                CreateEventCommand createEventCommand = _mapper.Map<CreateEventCommand>(eventDetailViewModel);
                var newId = await _client.ApiEventsPostAsync(createEventCommand);
                return new ApiResponse<Guid>() { Data = newId, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> UpdateEvent(EventDetailViewModel eventDetailViewModel)
        {
            try
            {
                UpdateEventCommand updateEventCommand = _mapper.Map<UpdateEventCommand>(eventDetailViewModel);
                await _client.ApiEventsPutAsync(updateEventCommand);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> DeleteEvent(Guid id)
        {
            try
            {
                await _client.ApiEventsDeleteAsync(id);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
