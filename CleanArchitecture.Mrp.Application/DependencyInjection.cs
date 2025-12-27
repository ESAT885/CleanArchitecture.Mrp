using CleanArchitecture.Mrp.Application.Abstractions.Repositories;
using CleanArchitecture.Mrp.Application.Behaviors;
using CleanArchitecture.Mrp.Application.Features.Auth.Commands.Login;
using CleanArchitecture.Mrp.Application.Mapping;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Mrp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(
                    typeof(LoginCommandHandler).Assembly
                );
            });
            services.AddValidatorsFromAssemblyContaining<LoginCommandValidator>();
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
            
            return services;
        }
    }
}
