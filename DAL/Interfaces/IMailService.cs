using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Email.Service
{
    public interface IMailService
    {
        Task<string> SendWelcomeEmailAsync(WelcomeRequest request);
    }
}
