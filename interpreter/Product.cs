namespace interpreter
{
    public class Product : IExpression
    {
        private IExpression leftExpression;
        private IExpression rightExpression;

        public Product(IExpression L_exp, IExpression R_exp)
        {
            leftExpression = L_exp;
            rightExpression = R_exp;
        }
        public int Interpret() => leftExpression.Interpret() * rightExpression.Interpret();
    }
}