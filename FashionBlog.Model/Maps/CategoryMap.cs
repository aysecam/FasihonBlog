using FashionBlog.Core.Map;
using FashionBlog.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FashionBlog.Model.Maps
{
    public class CategoryMap : Map<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.CategoryName).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired(true);

            base.Configure(builder);
        }

    }
}
