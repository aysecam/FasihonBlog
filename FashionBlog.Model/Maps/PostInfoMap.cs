using FashionBlog.Core.Map;
using FashionBlog.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FashionBlog.Model.Maps
{
    public class PostInfoMap : Map<PostInfo>
    {
        public override void Configure(EntityTypeBuilder<PostInfo> builder)
        {
            builder.Property(x => x.PostComment).IsRequired(false).HasMaxLength(250);
            base.Configure(builder);
        }
    }
}
