using Microsoft.AspNetCore.Identity;
using SinisterApi.Identity.Context;
using SinisterApi.Identity.Models;

namespace SinisterApi.Identity
{
    public class IdentityInitializer
    {
        private readonly IdentityDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public IdentityInitializer(
            IdentityDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (_context.Database.EnsureCreated())
            {
                if (!_roleManager.RoleExistsAsync(Roles.ROLE_API_BROKER).Result)
                {
                    var resultado = _roleManager.CreateAsync(
                        new IdentityRole(Roles.ROLE_API_BROKER)).Result;
                    if (!resultado.Succeeded)
                    {
                        throw new Exception($"Erro durante a criação da role {Roles.ROLE_API_BROKER}.");
                    }
                }

                CreateUser(
                    new ApplicationUser()
                    {
                        UserName = "dionisio",
                        Email = "dionisio.rafael@gmail.com",
                        EmailConfirmed = true
                    }, "Anaof$L7p^qw", Roles.ROLE_API_BROKER);

                CreateUser(
                    new ApplicationUser()
                    {
                        UserName = "leandro",
                        Email = "lando.augusto20@gmail.com",
                        EmailConfirmed = true
                    }, "Gz*jVeJk8&$@", Roles.ROLE_API_BROKER);                
            }
        }

        private void CreateUser(
            ApplicationUser user,
            string password,
            string initialRole = null)
        {
            if (_userManager.FindByNameAsync(user.UserName).Result == null)
            {
                var resultado = _userManager
                    .CreateAsync(user, password).Result;

                if (resultado.Succeeded &&
                    !String.IsNullOrWhiteSpace(initialRole))
                {
                    _userManager.AddToRoleAsync(user, initialRole).Wait();
                }
            }
        }
    }
}
