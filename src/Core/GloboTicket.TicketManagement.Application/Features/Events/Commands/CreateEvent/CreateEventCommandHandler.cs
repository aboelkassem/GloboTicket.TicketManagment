using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Models.Mail;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler(
        IMapper _mapper, 
        IEventRepository _eventRepository, 
        IEmailService _emailService
        ) : IRequestHandler<CreateEventCommand, Guid>
    {
        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @event = _mapper.Map<Event>(request);

            @event = await _eventRepository.AddAsync(@event);

            // sending email
            var emailReq = new Email()
            {
                To = "test@test.com",
                Body = $"A new event was created: {request}",
                Subject = "A new event was created",
            };

            try
            {
                await _emailService.SendEmailAsync(emailReq);
            }
            catch (Exception ex)
            {
                // just log it
                // this shouldn't stop the api from doing else
            }

            return @event.EventId;
        }
    }

}
