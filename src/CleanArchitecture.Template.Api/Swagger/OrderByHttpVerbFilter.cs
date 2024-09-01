using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CleanArchitecture.Template.Api.Swagger
{
    public class OrderByHttpVerbFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = swaggerDoc.Paths
                .OrderBy(path => GetOrder(path.Value.Operations.Keys.First()))
                .ThenBy(path => path.Key)
                .ToList();

            var orderedPaths = new OpenApiPaths();

            foreach (var path in paths)
            {
                orderedPaths.Add(path.Key, path.Value);
            }

            swaggerDoc.Paths = orderedPaths;
        }

        private int GetOrder(OperationType operationType)
        {
            return operationType switch
            {
                OperationType.Get => 1,
                OperationType.Post => 2,
                OperationType.Put => 3,
                OperationType.Delete => 4,
                OperationType.Patch => 5,
                OperationType.Options => 6,
                OperationType.Head => 7,
                OperationType.Trace => 8,
                _ => 9
            };
        }
    }
}