﻿using DAL.Infrastructure;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;


namespace AspNetIdentity.Providers
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        ApplicationUser user;

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            var _applicationDbContext = new ApplicationDbContext();

            var userRolesId = from role in user.Roles select role.RoleId;
            var roles = from role in _applicationDbContext.Roles.OrderBy(r => r.Name)
                        where userRolesId.Contains(role.Id)
                        select role.Name;

            context.AdditionalResponseParameters.Add("roles", String.Join(";", String.Join(";", roles.ToList())));

            return Task.FromResult(0);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            user = await userManager.FindAsync(context.UserName, context.Password);

            var _applicationDbContext = new ApplicationDbContext();

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect."+context.UserName+" - "+context.Password );
                return;
            }

            if (!user.EmailConfirmed)
            {
                context.SetError("invalid_grant", "User did not confirm email.");
                return;
            }

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, "JWT");

            oAuthIdentity.AddClaims(ExtendedClaimsProvider.GetClaims(user));

            oAuthIdentity.AddClaims(RolesFromClaims.CreateRolesBasedOnClaims(oAuthIdentity));

            var ticket = new AuthenticationTicket(oAuthIdentity, null);

            context.Validated(ticket);

        }
    }
}