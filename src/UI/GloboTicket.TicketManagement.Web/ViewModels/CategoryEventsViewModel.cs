namespace GloboTicket.TicketManagement.Web.ViewModels
{
    public class CategoryEventsViewModel
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<EventNestedViewModel>? Events { get; set; }
    }
}
