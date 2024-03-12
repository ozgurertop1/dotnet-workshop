using DotnetWorkshop.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetWorkshop.Repository.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = 1, UserName = "test1", eMail = "test1@gmail.com", Password = "123123", TeamId = 1 },
                new User { Id = 2, UserName = "test2", eMail = "test2@gmail.com", Password = "1231234", TeamId = 2 },
                new User { Id = 3, UserName = "test3", eMail = "test3@gmail.com", Password = "1231235", TeamId = 3 }
                );
        }
    }
}
