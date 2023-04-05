using Microsoft.AspNetCore.Authentication.Cookies;

namespace SistemaContas.Presentation.Configuration
{
    //Configuração de politicas de autenticação
    public class SecurityConfiguration
    {
        public static void Add(WebApplicationBuilder builder)
        {
            //Politica de autenticação
            builder.Services.Configure<CookiePolicyOptions>(
                options => { options.MinimumSameSitePolicy = SameSiteMode.None; }
                );

            //permissões no usuario
            builder.Services.AddAuthentication
                (CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

        }

        public static void Use(WebApplication app)
        {
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
