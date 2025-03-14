using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordlessAuthApp.Dtos
{
    public class PasswordlessAuthDto
    {
        public string Email { get; set; }
        public DateTime CreationTime { get; private set; }
        public DateTime ExpireTime { get; private set; }

        public PasswordlessAuthDto(string email)
        {
            Email = email;
            CreationTime = DateTime.UtcNow;
            ExpireTime = CreationTime.AddMinutes(15);
        }
    }
}
