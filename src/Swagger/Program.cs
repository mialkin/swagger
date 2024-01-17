using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddRouting(options => options.LowercaseUrls = true);

services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.DescribeAllParametersInCamelCase();
    options.IncludeXmlComments(GetXmlCommentsFilePath());

    string GetXmlCommentsFilePath()
    {
        var basePath = AppContext.BaseDirectory;
        var fileName = typeof(Program).GetTypeInfo().Assembly.GetName().Name + ".xml";
        // Don't forget to check "Generate XML documentation" checkbox in project's properties
        return Path.Combine(basePath, fileName);
    }
});

var application = builder.Build();

application.UseSwagger();
application.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

application.MapControllers();
application.UseRouting();

application.Run();