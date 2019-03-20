using Microsoft.IdentityModel.Tokens;
using NowVN.Framework.Models;
using NowVN.Framework.BaseRepository;
using NowVN.Framework.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NowVN.Framework.CustomerLogic
{
    public interface ICustomerLogic : IBaseRepository<Customer>
    {
        string Authenticate(string username, string password);
    }

    public class CustomerLogic : BaseRepository<Customer>, ICustomerLogic
    {
        private JwtSecurityTokenProvider jwtTokenProvider;

        public CustomerLogic(JwtSecurityTokenProvider provider, NowVNSimulatorContext dbContext) : base(dbContext)
        {
            this.jwtTokenProvider = provider;
        }

        public string Authenticate(string username, string password)
        {
            var customer = _context.Customer
                                .SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (customer == null)
                return null;

            return jwtTokenProvider.createAccesstoken(customer);

        }
    }
}

