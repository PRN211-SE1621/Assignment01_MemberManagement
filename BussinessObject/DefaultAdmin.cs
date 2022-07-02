using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

namespace BussinessObject
{
    public class DefaultAdmin : MemberObject
    {
        public DefaultAdmin()
        {
            const string DEFAULT_INFO = "default";
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            this.Email = config["AdminAccount:Email"];
            this.Password = config["AdminAccount:Password"];
            this.City = DEFAULT_INFO;
            this.MemberID = 0;
            this.MemberName = DEFAULT_INFO;
            this.Country = DEFAULT_INFO;
            this.Role = Roles.ADMIN;
        }
    }
}
