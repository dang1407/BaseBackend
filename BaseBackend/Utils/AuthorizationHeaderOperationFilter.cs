using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BaseBackend
{
    public class AuthorizationHeaderOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var bearerScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            };

            // Tìm tất cả các security requirement có chứa 'Bearer'
            var securityRequirement = operation.Security.FirstOrDefault(sr =>
                sr.ContainsKey(bearerScheme));

            if (securityRequirement != null)
            {
                operation.Security.Clear();
                operation.Security.Add(new OpenApiSecurityRequirement
            {
                { bearerScheme, new List<string>() }
            });

                var parameter = operation.Parameters.FirstOrDefault(p => p.Name == "Authorization");
                if (parameter != null)
                {
                    parameter.Description = "Access Token";
                }
            }
        }
    }
}
