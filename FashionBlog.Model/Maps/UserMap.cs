using FashionBlog.Core.Map;
using FashionBlog.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FashionBlog.Model.Maps
{
    public class UserMap : Map<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).IsRequired(true);
            builder.Property(x => x.LastName).IsRequired(true);
            builder.Property(x => x.Title).HasMaxLength(60).IsRequired(true);
            builder.Property(x => x.Image).IsRequired(true);
            builder.Property(x => x.Email).IsRequired(false);
            builder.Property(x => x.Password).IsRequired(true);
            builder.Property(x => x.LastLogin).IsRequired(false);
            builder.Property(x => x.LastIpAddress).IsRequired(false);

            base.Configure(builder);
        }
    }
}
