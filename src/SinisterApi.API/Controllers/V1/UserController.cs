using Application.DTO.User;
using Domain.Core.Infrastructure.Exceptions;
using Infrastruture.CrossCutting.Identity.Interfaces;
using Infrastruture.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SinisterApi.API.Controllers.V1.Base;

namespace SinisterApi.API.Controllers.V1
{
    public class UserController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(
            IUser user, 
            ILogger<UserController> logger, 
            UserManager<ApplicationUser> userManager) : base(user,logger) =>
            this.userManager = userManager;

        [HttpPost("GetUser")]
        public async Task<ActionResult> GetUserAsync(GetUserDto model)
        {
            var request = new { model?.Id, model?.Login, model?.Email };
            try
            {
                ApplicationUser existentUser = null;
                if (!string.IsNullOrWhiteSpace(model.Id))
                {
                    existentUser = await userManager.FindByIdAsync(model.Id);
                }
                if (existentUser == null && !string.IsNullOrWhiteSpace(model.Login))
                {
                    existentUser = await userManager.FindByNameAsync(model.Login);
                }
                if (existentUser == null && !string.IsNullOrWhiteSpace(model.Email))
                {
                    existentUser = await userManager.FindByEmailAsync(model.Email);
                }
                if (existentUser == null) base.ReturnNotFound();

                if (existentUser.LockoutEnabled)
                {
                    if (DateTime.MaxValue.Date.Equals(existentUser.LockoutEnd?.Date))
                    {
                        throw new BusinessException($"Usuário inativado.");
                    }
                    else
                    {
                        throw new BusinessException($"Usuário bloqueado até {existentUser.LockoutEnd}.");
                    }
                }

                return base.ReturnSuccess(new { existentUser.Id, existentUser.UserName, existentUser.Email });

            }
            catch (Exception exception)
            {
                throw;
            }
        }

        [HttpPost("SaveUser")]
        public async Task<ActionResult> SaveUserAsync(SaveUserDto model)
        {            
            try
            {
                var existentUser = await userManager.FindByNameAsync(model.Login);
                if (existentUser != null)
                {
                    throw new BusinessException($"Já existe outro usuário cadastrado com o login '{model.Login}'.");
                }

                var user = new ApplicationUser
                {
                    UserName = model.Login,
                    Email = model.Email,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        throw new Exception(error.Description);
                    }
                }

                var createdUser = await userManager.FindByNameAsync(model.Login);
                if (createdUser == null)
                {
                    throw new Exception("Falha na criação do usuário.");
                }

                return base.ReturnSuccess(createdUser.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("UpdateUser")]
        public async Task<ActionResult> UpdateUserAsync(UpdateUserDto model)
        {            
            try
            {
                var existentUser = await userManager.FindByIdAsync(model.Id);
                if (existentUser == null)
                {
                    throw new BusinessException($"Usuário com identificador '{model.Id}' não localizado.");
                }

                existentUser.UserName = model.Login;
                existentUser.Email = model.Email;               

                var user = new ApplicationUser
                {
                    UserName = model.Login,
                    Email = model.Email,
                    EmailConfirmed = true
                };

                var result = await userManager.UpdateAsync(existentUser);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        throw new Exception(error.Description);
                    }
                }

                return base.ReturnSuccess();

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("UpdatePasswordUser")]
        public async Task<ActionResult> UpdatePasswordAsync(UpdatePasswordUserDto model)
        {
            var request = new
            {
                model.Id,
                OldPassword = string.IsNullOrWhiteSpace(model.OldPassword) ? "não informada" : new string('*', model.OldPassword.Length),
                NewPassword = string.IsNullOrWhiteSpace(model.NewPassword) ? "não informada" : new string('*', model.NewPassword.Length)
            };
            try
            {
                var existentUser = await userManager.FindByIdAsync(model.Id);
                if (existentUser == null)
                {
                    throw new BusinessException($"Usuário com identificador '{model.Id}' não localizado.");
                }

                var result = await userManager.ChangePasswordAsync(existentUser, model.OldPassword, model.NewPassword);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        throw new Exception(error.Description);
                    }
                }

                return base.ReturnSuccess();

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("UpdateStatusUser")]
        public async Task<ActionResult> UpdateStatusUserAsync(UpdateStatusUserDto model)
        {
            var request = new { model.Id };
            try
            {
                var existentUser = await userManager.FindByIdAsync(model.Id);
                if (existentUser == null)
                {
                    throw new BusinessException($"Usuário com identificador '{model.Id}' não localizado.");
                }

                var result = await userManager.SetLockoutEnabledAsync(existentUser, true);
                if (result.Succeeded)
                {
                    result = await userManager.SetLockoutEndDateAsync(existentUser, DateTime.MaxValue.Date);
                }
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        throw new Exception(error.Description);
                    }
                }

                return base.ReturnSuccess();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
