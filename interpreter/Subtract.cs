using System.Linq.Expressions;

namespace interpreter
{
    public class Subtract : IExpression
    {
        public Subtract(IExpression L_exp, IExpression R_exp)
        {
            leftExpression = L_exp;
            rightExpression = R_exp;
        }

        private IExpression leftExpression;
        private IExpression rightExpression;

        public int Interpret() => leftExpression.Interpret() - rightExpression.Interpret();
    }
}