using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace core.Specifications
{
    public interface ISpecification<T>
    {
        public Expression< Func<T, bool> > Criteria { get;  }

        public List<Expression<Func<T, Object>>> Includes { get; }

        public Expression< Func<T, Object> > OrderBy { get;  }

        public Expression< Func<T, Object> > OrderByDescending { get;  }

        int Take { get; }

        int Skip { get; }

        bool IsPagingEnabled { get; }
    }
}