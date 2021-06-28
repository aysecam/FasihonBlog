using FashionBlog.Core.Map;
using FashionBlog.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FashionBlog.Model.Maps
{
    public class PostMap : Map<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.PostDetail).IsRequired(true);
            builder.Property(x => x.Tags).IsRequired(false);
            builder.Property(x => x.ImagePath).IsRequired(false);

            base.Configure(builder);
        }
    }
}
