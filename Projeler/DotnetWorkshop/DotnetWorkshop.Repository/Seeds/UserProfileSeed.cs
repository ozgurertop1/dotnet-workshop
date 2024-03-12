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
    internal class UserProfileSeed : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasData(
                new UserProfile { Id = 1, FirstName = "test1", LastName = "test test 1", UserId = 1 },
                new UserProfile { Id = 2, FirstName = "test1", LastName = "test test 2", UserId = 2 },
                new UserProfile { Id = 3, FirstName = "test2", LastName = "test test 3", UserId = 3 }
                );
        }
    }
}
