using FrontEnd.Data;
using FrontEnd.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FrontEnd
{
    public class RequireLoginMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly AppState _appState;

        public RequireLoginMiddleware(RequestDelegate next, AppState appState)
        {
            _next = next;
            _appState = appState;
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

                _appState.SetIsAdmin(user.IsAdmin());
                _appState.SetIsAttendee(isAttendee);
                _appState.SetUserName(user.Identity.Name);

                if (!isAttendee)
                {
                    _appState.IsAttendee = false;
                    context.Response.Redirect("/Welcome");

                    return;
                }
            }
            else
            {
                _appState.SetIsAdmin(false);
                _appState.SetIsAttendee(false);
                _appState.SetUserName(null);
            }

            await _next(context);
        }
    }
}
