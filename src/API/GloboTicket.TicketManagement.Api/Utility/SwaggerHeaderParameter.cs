using NSwag;
using NSwag.Generation.AspNetCore;

namespace GloboTicket.TicketManagement.Api.Utility;

internal static class SwaggerHeaderParameter
{
    public static void AddHeaders(this AspNetCoreOpenApiDocumentGeneratorSettings settings)
    {
        //settings.AddSecurity("Authentication", Enumerable.Empty<string>(), new OpenApiSecurityScheme
        //{
        //    Name = "Authorization",
        //    In = OpenApiSecurityApiKeyLocation.Header,
        //    Type = OpenApiSecuritySchemeType.ApiKey,
        //    Description = "Copy this into the value field: Bearer {token}"
        //});

        //settings.AddSecurity("Device Authentication", Enumerable.Empty<string>(), new OpenApiSecurityScheme
        //{
        //    Name = "APIKey",
        //    In = OpenApiSecurityApiKeyLocation.Header,
        //    Type = OpenApiSecuritySchemeType.ApiKey,
        //    Description = "This api key is provided by the device authentication endpoint"
        //});
    }
}