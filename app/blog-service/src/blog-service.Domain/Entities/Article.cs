using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_service.Domain.Entities
{
    public sealed class Article : Entity
    {
        public string Title { get; set; }
    }
}
