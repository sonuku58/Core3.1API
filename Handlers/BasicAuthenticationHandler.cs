using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudentAPI.Model;
using StudentAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace StudentAPI.Handlers
{
    //public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    //{
    //    private readonly IUserService userService;

    //   // private readonly ApplicationDbContext context;
    //    public BasicAuthenticationHandler(
    //        IOptionsMonitor<AuthenticationSchemeOptions> options,
    //        ILoggerFactory logger ,
    //        UrlEncoder encoder,
    //        ISystemClock clock,
    //        IUserService _userService) :base(options,logger,encoder,clock)
    //    {
    //        userService = _userService;
    //    }


        //protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        //{

        //    if(!Request.Headers.ContainsKey("Authorization"))
        //    {
        //        return  AuthenticateResult.Fail("Authorization header was not found");
        //    }

        //    try
        //    {
        //        var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
        //        var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
        //        string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
        //        string userName = credentials[0];
        //        string password = credentials[1];
        //        User user = userService.Authenticate(userName, password);
        //       // User user = context.Users.Where(user => user.UserName == userName && user.Password == password).FirstOrDefault();
        //        if(user==null)
        //            return AuthenticateResult.Fail("Invalid UserName or password");
        //        else
        //        {
        //            var claims = new[] { new Claim(ClaimTypes.Name, user.UserName) };
        //            var identity = new ClaimsIdentity(claims, Scheme.Name);
        //            var principle = new ClaimsPrincipal(identity);
        //            var ticket = new AuthenticationTicket(principle,Scheme.Name);

        //            return AuthenticateResult.Success(ticket);

        //        }
                
        //    }
        //    catch(Exception)
        //    {
        //        return AuthenticateResult.Fail("Error");

        //    }
        //}
   // }
}
