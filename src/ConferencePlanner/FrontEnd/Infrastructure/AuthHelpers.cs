using FrontEnd.Data;
using FrontEnd.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Claims;

namespace FrontEnd.Infrastructure
{
    public static class AuthConstants
    {
        public static readonly string IsAdmin = nameof(IsAdmin);
        public static readonly string IsAttendee = nameof(IsAttendee);
        public static readonly string TrueValue = "true";
    }
}

namespace System.Security.Claims
{
    public static class AuthnHelpers
    {
        public static bool IsAdmin(this ClaimsPrincipal principal) =>
            principal.HasClaim(AuthConstants.IsAdmin, AuthConstants.TrueValue);

        public static void MakeAdmin(this ClaimsPrincipal principal) =>
            principal.Identities.First().MakeAdmin();

        public static void MakeAdmin(this ClaimsIdentity identity) =>
            identity.AddClaim(new Claim(AuthConstants.IsAdmin, AuthConstants.TrueValue));

        public static bool IsAttendee(this ClaimsPrincipal principal) =>
            principal.HasClaim(AuthConstants.IsAttendee, AuthConstants.TrueValue);

        public static void MakeAttendee(this ClaimsPrincipal principal) =>
            principal.Identities.First().MakeAttendee();

        public static void MakeAttendee(this ClaimsIdentity identity) =>
            identity.AddClaim(new Claim(AuthConstants.IsAttendee, AuthConstants.TrueValue));
    }
}

namespace Microsoft.AspNetCore.Identity
{

    //public static class UserHelpers
    //{
    //    public static async Task<bool> IsAttendeeAsync(this UserManager<ApplicationUser> userManager, ApplicationUser user)
    //    {
    //        bool isAttendee = false;
    //        var claim = (await userManager.GetClaimsAsync(user)).Where(a => a.Type == AuthConstants.IsAttendee).FirstOrDefault();

    //        if (claim != null)
    //        {
    //            isAttendee = claim.Value == AuthConstants.TrueValue;
    //        }
    //        return isAttendee;
    //    }

    //    public static async Task MakeAttendeeAsync(this UserManager<ApplicationUser> userManager, ApplicationUser user) =>
    //       await userManager.AddClaimAsync(user, new Claim(AuthConstants.IsAttendee, AuthConstants.TrueValue));
    //}
}