using System;
using System.Linq.Expressions;
using NJsonApiCore.Utils;

namespace NJsonApiCore.Conventions.Impl
{
    internal class CamelCaseLinkNameConvention : ILinkNameConvention
    {
        public virtual string GetLinkNameFromExpression<TResource, TLinkedResource>(Expression<Func<TResource, TLinkedResource>> propertyExpression)
        {
            var pi = propertyExpression.GetPropertyInfo();
            var name = CamelCaseUtil.ToCamelCase(pi.Name);
            return name;
        }
    }
}
