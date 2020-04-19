using System.Linq.Expressions;

namespace interpreter
{
    public class Add : IExpression
    {
        private IExpression leftExpression;
        private IExpression rightExpression;

        public Add(IExpression L_exp, IExpression R_exp)
        {
            leftExpression = L_exp;
            rightExpression = R_exp;
        }
        public int Interpret() => leftExpression.Interpret() + rightExpression.Interpret();
    }
}