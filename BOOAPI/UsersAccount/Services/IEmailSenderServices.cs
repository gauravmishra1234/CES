using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersAccount.Services
{
    public interface IEmailSenderServices
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
