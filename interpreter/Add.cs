using System.Linq.Expressions;

namespace interpreter
{
    public class Add : IExpression
    {
        private IExpression leftExpression;
        private IExpression rightExpression;

        public int Interpret() => leftExpression.Interpret() + rightExpression.Interpret();
    }
}