using System;
using System.Collections.Generic;
using System.Text;

namespace FashionBlog.Core.Entity
{
    public interface IEntity<T>
    {
        T ID { get; set; }

    }
}
