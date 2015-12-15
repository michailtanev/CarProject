﻿//Snezhina
namespace CarMarket.Domain
{
    using Domain;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {
        public virtual ICollection<Car> Cars { get; set; } //in case we want to see all cars from one seller; virtual for lazy loading
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

}
