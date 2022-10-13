using Application.Features.Auths.Rules;
using Application.Features.OperationClaims.Rules;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.ProgrammingTechnologies.Rules;
using Application.Features.SocialMedia.GitHubProfile.Rules;
using Application.Services.AuthService;
using Application.Services.UserService;

using FluentValidation;
using Kodlama.io.Application.Pipelines.Validation;
using Kodlama.io.Core.Application.Pipelines.Authorization;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IUserService, UserManager>();

            services.AddScoped<ProgrammingLanguagesBusinessRules>();
            services.AddScoped<ProgrammingTechnologiesBusinessRules>();
            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<GitHubBusinessRules>();
            services.AddScoped<OperationClaimBusinessRules>();






            return services;

        }
    }
}
