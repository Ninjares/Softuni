namespace ExpressionTreesDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Diagnostics;

    public static class DynamicExtensions
    {
        public static ExposedObject Exposed(this object obj)
            => new ExposedObject(obj);
    }

    public class New<T>
        where T : class
    {
        public static Func<T> Instance
            = Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile();
    }

    public class Program
    {
        public static void Main()
        {
            
            var cat = new Cat("Some Cat");

            dynamic exposedCat = cat.Exposed();

            var value = exposedCat.SomeProperty;

            Console.WriteLine(value);
        }

        private static void ParseExpression(Expression expression, string level)
        {
            level += "-";

            if (expression.NodeType == ExpressionType.Lambda)
            {
                Console.WriteLine($"{level}Extracting lambda...");
                var lambdaExpression = (LambdaExpression)expression;

                Console.WriteLine($"{level}Extracting parameters...");

                foreach (var parameter in lambdaExpression.Parameters)
                {
                    ParseExpression(parameter, level);
                }

                var body = lambdaExpression.Body;

                Console.WriteLine($"{level}Extracting body...");
                ParseExpression(body, level);
            }
            else if (expression.NodeType == ExpressionType.Constant)
            {
                Console.WriteLine($"{level}Extracting constant...");
                var constantExpression = (ConstantExpression)expression;
                var value = constantExpression.Value;

                Console.WriteLine($"{level}Constant: {value}");
            }
            else if (expression.NodeType == ExpressionType.Convert)
            {
                Console.WriteLine($"{level}Converting...");
                var unaryExpression = (UnaryExpression)expression;
                ParseExpression(unaryExpression.Operand, level);
            }
            else if (expression.NodeType == ExpressionType.Call)
            {
                Console.WriteLine($"{level}Extracting method...");
                var methodExpression = (MethodCallExpression)expression;

                Console.WriteLine($"{level}Method Name: {methodExpression.Method.Name}");

                if (methodExpression.Object == null)
                {
                    Console.WriteLine($"{level}Method is static");
                }
                else
                {
                    ParseExpression(methodExpression.Object, level);
                }

                Console.WriteLine($"{level}Extracting method arguments...");
                foreach (var argument in methodExpression.Arguments)
                {
                    ParseExpression(argument, level);
                }
            }
            else if (expression.NodeType == ExpressionType.Parameter)
            {
                Console.WriteLine($"{level}Extracting parameter...");
                var parameterExpression = (ParameterExpression)expression;

                Console.WriteLine($"{level}Parameter: {parameterExpression.Name} - {parameterExpression.Type.Name}");
            }
            else if (expression.NodeType == ExpressionType.MemberAccess)
            {
                Console.WriteLine($"{level}Extracting member...");
                var memberExpression = (MemberExpression)expression;

                if (memberExpression.Member is PropertyInfo property)
                {
                    Console.WriteLine($"{level}Property: {property.Name} - {property.PropertyType.Name}");
                }

                if (memberExpression.Member is FieldInfo field)
                {
                    // instance of the closure class
                    var classInstance = (ConstantExpression)memberExpression.Expression;
                    var variableValue = field.GetValue(classInstance.Value);

                    Console.WriteLine($"{level}Variable: {variableValue}");
                }

                ParseExpression(memberExpression.Expression, level);
            }
            else if (expression.NodeType == ExpressionType.Add)
            {
                Console.WriteLine($"{level}Extracting binary operation...");
                var binaryExpression = (BinaryExpression)expression;

                ParseExpression(binaryExpression.Left, level);
                ParseExpression(binaryExpression.Right, level);
            }
            else if (expression.NodeType == ExpressionType.New)
            {
                Console.WriteLine($"{level}Extracting object creation...");
                var newExpression = (NewExpression)expression;

                Console.WriteLine($"{level}Constructor: {newExpression.Constructor.DeclaringType.Name}");
                Console.WriteLine($"{level}Extracting constructor arguments...");
                
                foreach (var argument in newExpression.Arguments)
                {
                    ParseExpression(argument, level);
                }
            }
            else if (expression.NodeType == ExpressionType.MemberInit)
            {
                Console.WriteLine($"{level}Extracting object creation with members...");

                var memberInitExpression = (MemberInitExpression)expression;

                ParseExpression(memberInitExpression.NewExpression, level);

                foreach (var memberBinding in memberInitExpression.Bindings)
                {
                    Console.WriteLine($"{level}Extracting member...");
                    Console.WriteLine($"{level}Member: {memberBinding.Member.Name}");

                    var memberAssignment = (MemberAssignment)memberBinding;

                    ParseExpression(memberAssignment.Expression, level);
                }
            }
            else
            {
                // TODO: Variable
                // TODO: Extract not supported expression by compilation
            }
        }
    }
}
