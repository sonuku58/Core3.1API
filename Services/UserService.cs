using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StudentAPI.Helper;
using StudentAPI.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StudentAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;
      

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, ApplicationDbContext _context)
        {
            _appSettings = appSettings.Value;
            context = _context;
           
        }

        public UserDetail Authenticate(string username, string password)
        {
            var user = context.UserDetails.SingleOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user.WithoutPassword();
        }

        public IEnumerable<UserDetail> GetAll()
        {
            return context.UserDetails.WithoutPasswords();
        }

       
    }
}
