namespace interpreter
{
    public class Product : IExpression
    {
        private IExpression leftExpression;
        private IExpression rightExpression;

        public int Interpret() => leftExpression.Interpret() * rightExpression.Interpret();
    }
}