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
using NowVN.Framework.ViewModels;

namespace NowVN.Framework.CustomerLogic
{
    public interface ICustomerLogic : IBaseRepository<Customer>
    {
        string Authenticate(string username, string password);
        Customer CreateCustomer(UserRegisterdViewModel userRegisterd);
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
                                .SingleOrDefault(x => x.Username == username);

            if(customer == null || !PasswordManipulation.VerifyPasswordHash(password, customer.PasswordHash, customer.PasswordSalt))
            {
                throw new NowVNException("Credentials are not valid");
            }

            return jwtTokenProvider.createAccesstoken(customer);

        }

        public Customer CreateCustomer(UserRegisterdViewModel userRegisterd)
        {
            Customer customer = userRegisterd.ToEntity<UserRegisterdViewModel, Customer>(userRegisterd);

            byte[] passwordSalt, passwordHash;

            PasswordManipulation.CreatePasswordHash(userRegisterd.Password, out passwordHash, out passwordSalt);

            customer.PasswordHash = passwordHash;
            customer.PasswordSalt = passwordSalt;

            customer.Id = Guid.NewGuid().ToString();

            this.Add(customer);

            return customer;
        }
    }
}

