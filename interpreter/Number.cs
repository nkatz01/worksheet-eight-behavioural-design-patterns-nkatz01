namespace interpreter
{
    public class Number : IExpression
    {
        private  int Num;
        internal Number(int n)
        {
            Num = n;
        }


        public int Interpret()
        {
            return Num ;
        }
    }
}