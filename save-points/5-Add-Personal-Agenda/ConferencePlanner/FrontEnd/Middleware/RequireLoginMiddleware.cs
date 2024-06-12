using FrontEnd.Data;
using FrontEnd.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FrontEnd
{
    public class RequireLoginMiddleware
    {
        private readonly RequestDelegate _next;

        public RequireLoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var endpoint = context.GetEndpoint();

            // If the user is authenticated but not a known attendee *and* we've not marked this page
            // to skip attendee welcome, then redirect to the Welcome page
            if (context.User.Identity.IsAuthenticated &&
                endpoint?.Metadata.GetMetadata<SkipWelcomeAttribute>() == null)
            {
                var user = context.User;

                var isAttendee = user.IsAttendee();

                if (!isAttendee)
                {
                    context.Response.Redirect("/Welcome");

                    return;
                }
            }

            await _next(context);
        }
    }
}
