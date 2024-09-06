using Microsoft.Extensions.DependencyInjection;

namespace Adisyon_OnionArch.Project.Infrastracture.Policy
{
    public static class Policies 
    {
        public static void ConfigurePoliciesForRoleClaims(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                // "AdminOnly" adında bir policy tanımlıyoruz
                options.AddPolicy("AdminOnly", policy =>
                {
                    policy.RequireClaim("IsAdmin", "true");
                    policy.RequireClaim("CanChangeTitle", "true");
                }); 
                
                //// "UserOnly" adında bir policy tanımlıyoruz
                //options.AddPolicy("UserOnly", policy =>
                //    policy.RequireRole("user"));

            });
        }
    }
}
