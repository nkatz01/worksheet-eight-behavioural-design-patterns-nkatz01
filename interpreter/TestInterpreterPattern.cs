using System;
using System.Collections.Generic;

namespace interpreter
{
    public static class TestInterpreterPattern
    {
        public static void Main(string[] args)
        {
            var tokenString = "7 3 - 2 1 + *";
            var stack = new Stack<IExpression>();
            var tokenArray = tokenString.Split(" ");
            foreach (var s in tokenArray)
            {
                if (ExpressionUtils.IsOperator(s))
                {
                    var rightExpression = stack.Pop();
                    var leftExpression = stack.Pop();
                    var op = ExpressionUtils.GetOperator(s, leftExpression, rightExpression);
                    stack.Push(new Number(op.Interpret()));
                }
                else
                {
                    stack.Push(new Number(Int32.Parse(s)));
                }
            }

            Console.WriteLine($"( {tokenString} ) {stack.Pop().Interpret()}");
        }
    }
}