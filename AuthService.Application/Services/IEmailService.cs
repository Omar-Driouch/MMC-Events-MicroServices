using AuthService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.Services
{
    public interface IEmailService
    {
        Task<string> SendEmailAsync(EmailDto emailDto);
        Task<string> GenerateVerificationCodeAsync();
    }
}
