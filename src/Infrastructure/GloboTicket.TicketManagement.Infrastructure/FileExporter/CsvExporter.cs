using CsvHelper;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using System.Globalization;

namespace GloboTicket.TicketManagement.Infrastructure.FileExporter
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventsExportDto> eventExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.CurrentCulture);
                csvWriter.WriteRecords(eventExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
