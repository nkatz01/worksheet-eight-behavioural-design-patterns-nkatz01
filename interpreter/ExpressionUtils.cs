namespace interpreter
{
    public sealed class ExpressionUtils
    {
        public static bool IsOperator(string s)
        {
            return s == "+" || s == "-" || s == "*";
        }

        public static IExpression GetOperator(string s, IExpression left, IExpression right)
        {
            if (s == "+")  
             return     new Add(left, right);  

            else if (s == "-")  
                return   new Subtract(left, right);  
            else  
                return   new Product(left, right);
             

            }


                 
        }
    }
