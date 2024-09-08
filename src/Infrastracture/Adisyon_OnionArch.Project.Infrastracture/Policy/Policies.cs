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
                // "AdminOnly" adında bir policy tanımlıyoruz
                options.AddPolicy("AdminCanManageCategory", policy =>
                {
                    policy.RequireClaim("IsAdmin", "true");
                    policy.RequireClaim("CreateCategory", "true");
                    policy.RequireClaim("UpdateCategory", "true");
                    policy.RequireClaim("DeleteCategory", "true");
                });
            });
        }
    }
}
