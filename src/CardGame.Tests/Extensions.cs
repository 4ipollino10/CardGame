using System.Linq.Expressions;
using System.Reflection;

namespace CardGame.Tests;

public static class Extensions
{
    public static void SetProperty<TEntity, T>(this TEntity entity, Expression<Func<TEntity, T>> propExpr, T value)
    {
        var expr = (MemberExpression)propExpr.Body;
        var prop = (PropertyInfo)expr.Member;
        prop.SetValue(entity, value, null);
    }
}