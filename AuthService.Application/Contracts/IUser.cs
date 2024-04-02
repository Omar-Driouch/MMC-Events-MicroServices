using AuthService.Application.DTOs;
using AuthService.Domain.Entities;

namespace AuthService.Application.Contracts
{
    public interface IUser
    {
        Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDTO);
        Task<LoginResponse> LoginUserAsync(LoginUserDTO loginUserDTO);
        Task<RoleResponse> AssignedRoleAsync(UserRoleDTO userRoleDTO );
        Task<string> VerifiedUserAsync(string email);

    }
}
