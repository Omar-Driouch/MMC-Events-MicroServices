using AuthService.Application.Contracts;
using AuthService.Application.DTOs;
using AuthService.Infrastracture.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthService.Domain.Entities;

namespace AuthService.Infrastracture.Repositories
{
    public class UserRepo : IUser
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IConfiguration configuration;
        public UserRepo(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            this.applicationDbContext = applicationDbContext;
            this.configuration = configuration;
        }
        public async Task<LoginResponse> LoginUserAsync(LoginUserDTO loginUserDTO)
        {
            var getUser = await FindUserByEmail(loginUserDTO.Email!);
            if (getUser == null) return new LoginResponse(false, "User not found,Sorry!");

            bool checkpassword = BCrypt.Net.BCrypt.Verify(loginUserDTO.Password, getUser.Password!);
            if (checkpassword)
                return new LoginResponse(true, "Login Successfully", GenerateJWTToken(getUser));
            else
                return new LoginResponse(false, "Invalid Credentials");

        }

        private string GenerateJWTToken(ApplicationUser user)
        {
            var securtyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securtyKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Email,user.Email),

            };
            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issur"],
                audience: configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDTO)
        {
            var getUser = await FindUserByEmail(registerUserDTO.Email);
            if (getUser != null)
                return new RegistrationResponse(false, "The Email is already taken");
            applicationDbContext.Users.Add(new ApplicationUser()
            {
                Name = registerUserDTO.Name,
                Email = registerUserDTO.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerUserDTO.Password)
            });
            await applicationDbContext.SaveChangesAsync();
            return new RegistrationResponse(true, "Registration Cmpleted");

        }

        private async Task<ApplicationUser> FindUserByEmail(string email) =>
            await applicationDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<RoleResponse> AssignedRoleAsync(UserRoleDTO userRoleDTO)
        {
            var userResult = await FindUserByEmail(userRoleDTO.Email);
            if (userResult != null)
            {
                var roleResult = await applicationDbContext.Roles.FirstOrDefaultAsync(r => r.RoleName == userRoleDTO.roleName);
                if (roleResult == null)
                {
                    // Role doesn't exist, so create a new role
                    var newRole = new Role() 
                    {
                        RoleName = userRoleDTO.roleName
                    };
                    var addNewRole = await applicationDbContext.Roles.AddAsync(newRole);
                        await applicationDbContext.SaveChangesAsync();
                    roleResult = addNewRole.Entity; // Update roleResult with the newly added role
                }

                // Create a new user role
                var newUserRole = new UserRole()
                {
                    RoleId = roleResult.Id,
                    ApplicationUserId = userResult.Id
                };

                // Add the new user role to the context
                var addUserRoleResult = await applicationDbContext.UsersRoles.AddAsync(newUserRole);

                // Save changes and check if the operation was successful
                var saveResult = await applicationDbContext.SaveChangesAsync();
                if (saveResult > 0)
                {
                    return new RoleResponse(true, "Role assigned successfully");
                }
            }
            return new RoleResponse(false, "Role assignment failed");
        }

        public async Task<string> VerifiedUserAsync(string email)
        {
            var user=await applicationDbContext.Users.FirstOrDefaultAsync(u=>u.Email==email);
            if (user == null) return "user not found";
            user.isEmailVerified = true;
            user.VerifiedAt = DateTime.Now;
            
            var result = await applicationDbContext.SaveChangesAsync();
            return "Email verified successfully";
        }
    }
}
