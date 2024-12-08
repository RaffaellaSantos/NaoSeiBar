using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace NSB_API.data.enums
{
    public class EnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                var enumNames = Enum.GetNames(context.Type);
                schema.Enum = enumNames.Select(name => new OpenApiString(name)).ToList<IOpenApiAny>();
            }
        }
    }
}
