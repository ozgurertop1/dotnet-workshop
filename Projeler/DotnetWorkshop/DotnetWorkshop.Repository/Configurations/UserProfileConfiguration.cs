﻿using DotnetWorkshop.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetWorkshop.Repository.Configurations
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        

        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            //Fluent Api Ayarlamaları

            //Primary Key Tanımlaması
            builder.HasKey(x => x.Id);

            //Primary Key otomatik olarak 1'er 1'er artsın
            builder.Property(x => x.Id)
                .UseIdentityColumn();

            //firstname max uzunluğu 50
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);

            //LastName max uzunluğu 250
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(250);

            //UserId max uzunluğu 250
            builder.Property(x => x.UserId).IsRequired().HasMaxLength(250);
        }
    }
}
