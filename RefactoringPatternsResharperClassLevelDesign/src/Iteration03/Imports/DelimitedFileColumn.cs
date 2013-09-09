using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Iteration03.Imports
{
    public class DelimitedFileColumn
    {
        private readonly PropertyInfo _property;

        public DelimitedFileColumn(LambdaExpression memberExpr)
        {
            _property = (PropertyInfo) FindProperty(memberExpr);
        }

        public Type PropertyType { get { return _property.PropertyType; } }

        public void SetProperty(object instance, object propertyValue)
        {
            _property.SetValue(instance, propertyValue);
        }

        private static MemberInfo FindProperty(LambdaExpression lambdaExpression)
        {
            Expression expressionToCheck = lambdaExpression;

            bool done = false;

            while (!done)
            {
                switch (expressionToCheck.NodeType)
                {
                    case ExpressionType.Convert:
                        expressionToCheck = ((UnaryExpression)expressionToCheck).Operand;
                        break;
                    case ExpressionType.Lambda:
                        expressionToCheck = ((LambdaExpression)expressionToCheck).Body;
                        break;
                    case ExpressionType.MemberAccess:
                        var memberExpression = ((MemberExpression)expressionToCheck);

                        if (memberExpression.Expression.NodeType != ExpressionType.Parameter &&
                            memberExpression.Expression.NodeType != ExpressionType.Convert)
                        {
                            throw new ArgumentException(string.Format("Expression '{0}' must resolve to top-level member.", lambdaExpression), "lambdaExpression");
                        }

                        MemberInfo member = memberExpression.Member;

                        return member;
                    default:
                        done = true;
                        break;
                }
            }

            return null;
        }
    }
}