using Autofac.Extensions.DependencyInjection;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Api.Infrastructure.Middleware;
using Api.Infrastructure.Services.Contracts;
using Api.Infrastructure.Services;
using Domain;
using Api.Authorization;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Repositories;
using Application.Common;
using Application.User;
using Application.LoginApplication.Interfaces;
using Application.LoginApplication.Services;
using Application.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddMemoryCache();

/// DbContext Config
#region DbContext

builder.Services.AddDbContext<MakmonDbContext>(options =>
{
    options.UseSqlServer("name=ConnectionStrings:KardinoConnection", sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    });
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
}, ServiceLifetime.Scoped);

builder.Services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Add detection services container and device resolver service.
builder.Services.AddDetection();

builder.Services.AddScoped<CustomAuthorizeFilter>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(CustomAuthorizeFilter));
});
/// MediatR Dependecy Injection
#region MediatR
builder.Services.AddMediatR(typeof(CustomAuthorizeFilter).GetTypeInfo().Assembly);

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidateCommandBehavior<,>));
builder.Services.AddScoped(typeof(IRequestPostProcessor<,>), typeof(CommitCommandPostProcessor<,>));

builder.Services.AddAutoMapper(typeof(UserMapper).GetTypeInfo().Assembly);

//builder.Services.AddTransient(typeof(IPipelineBehavior<FoodCreateCommand, OperationResult<FoodCreateCommandResult>>), typeof(CreateFoodUniqueNameValidator));
#endregion

/// Dev Team Dependecy Injection ............
#region Dependecy Injection
builder.Services.AddTransient(typeof(IAnonymousRequestCheckService), typeof(AnonymousRequestCheckService));
builder.Services.AddTransient(typeof(IAuthentication), typeof(AuthenticationService));
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IUriService>(o =>
{
    var accessor = o.GetRequiredService<IHttpContextAccessor>();
    var request = accessor.HttpContext.Request;
    var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
    return new UriService(uri);
});
#endregion


string allowSpecificOrigins = "_allowSpecificOrigins";

builder.Services.AddCors(options =>
{

    options.AddPolicy(allowSpecificOrigins,
    builder =>

    {
        builder.AllowAnyOrigin()
               .SetIsOriginAllowed(x => true)
               .SetPreflightMaxAge(TimeSpan.FromSeconds(90000))
               .AllowAnyHeader()
               .AllowAnyMethod();
        ;
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}


//app.UseCors(builder =>
//{
//    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
//    builder.AllowAnyMethod();
//    builder.AllowAnyHeader();
//});
app.UseCors(allowSpecificOrigins);
app.UseSwagger();
//app.UseSwaggerUI();
app.UseSwaggerUI(c =>
{
    //c.SwaggerEndpoint("/SimulaFrete/swagger/v1/swagger.json", "Web API V1");
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API V1");

    //if (app.Environment.IsDevelopment())
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API V1");
    //}
    //else
    //{
    //    To deploy on IIS
    //    c.SwaggerEndpoint("/SimulaFrete/swagger/v1/swagger.json", "Web API V1");
    //}
});

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
    RequestPath = new PathString("/Resources")
});
app.UseDeveloperExceptionPage();

//app.UseRouting();

// custome middlewares (UseResponse=>UseJwt=>UseUserAuthorization)
app.UseResponse();
app.UseErrorHandler();
app.UseAnonymous();
app.UseJwt();
app.UseUserAuthorization();
//app.UseAuthorization();

app.UseDetection();
app.UseRouting();

app.MapControllers();

app.Run();