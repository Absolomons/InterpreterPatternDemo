
namespace Interpreter
{
    /// <summary>
    /// Interpreter Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            // year to be translated to roman numerals, not meant for years above 4 digits
            string year = "1934";

            Context context = new Context(year);

            List<Expression> tree = new List<Expression>();
            if (context.Input.Length >= 4)
            {
                tree.Add(new ThousandExpression());
            }
            if (context.Input.Length >= 3)
            {
                tree.Add(new HundredExpression());
            }
            if (context.Input.Length >= 2)
            {
                tree.Add(new TenExpression());
            }
            tree.Add(new OneExpression());
            


            // Interpret
            foreach (Expression exp in tree)
            {
                exp.Interpret(context);
            }

            Console.WriteLine(year + " = " + context.Output);

            Console.ReadKey();
        }
    }

    public class Context
    {
        string input;
        string? output;
        public Context(string input)
        {
            this.input = input;
        }

        public string Input
        {
            get { return input; }
            set { input = value; }
        }

        public string?Output
        {
            get { return output; }
            set { output = value; }
        }
    }

    public abstract class Expression
    {
        public void Interpret(Context context)
        {
            if (context.Input.Length == 0)
            {
                return;
            }
            string temp = context.Input;
            temp = temp.Substring(0, 1);

            if (temp == "9")
            {
                context.Output += Nine();
                context.Input = context.Input.Substring(1);
            } 
            else if (temp == "8")
            {
                context.Output += Eight();
                context.Input = context.Input.Substring(1);
            }
            else if (temp == "7")
            {
                context.Output += Seven();
                context.Input = context.Input.Substring(1);
            }
            else if (temp == "6")
            {
                context.Output += Six();
                context.Input = context.Input.Substring(1);
            }
            else if (temp == "5")
            {
                context.Output += Five();
                context.Input = context.Input.Substring(1);
            }
            else if (temp == "4")
            {
                context.Output += Four();
                context.Input = context.Input.Substring(1);
            }
            else if (temp == "3")
            {
                context.Output += Three();
                context.Input = context.Input.Substring(1);
            }
            else if (temp == "2")
            {
                context.Output += Two();
                context.Input = context.Input.Substring(1);
            }
            else if (temp == "1")
            {
                context.Output += One();
                context.Input = context.Input.Substring(1);
            }
            else if (temp == "0")
            {
                context.Output += Zero();
                context.Input = context.Input.Substring(1);
            }
        }
        public abstract string Zero();
        public abstract string One();
        public abstract string Two();
        public abstract string Three();
        public abstract string Four();
        public abstract string Five();
        public abstract string Six();
        public abstract string Seven();
        public abstract string Eight();
        public abstract string Nine();
    }
    // Translates thousands to roman numerals
    public class ThousandExpression : Expression
    {
        public override string Zero() { return " "; }
        public override string One() { return "M"; }
        public override string Two() { return "MM"; }
        public override string Three() { return "MMM"; }
        public override string Four() { return "MMMM"; }
        public override string Five() { return "MMMMM"; }
        public override string Six() { return "MMMMMM"; }
        public override string Seven() { return "MMMMMMM"; }
        public override string Eight() { return "MMMMMMMM"; }
        public override string Nine() { return "MMMMMMMMM"; }
    }
    // Translates hunreds to roman numerals
    public class HundredExpression : Expression
    {
        public override string Zero() { return " "; }
        public override string One() { return "C"; }
        public override string Two() { return "CC"; }
        public override string Three() { return "CCC"; }
        public override string Four() { return "CD"; }
        public override string Five() { return "D"; }
        public override string Six() { return "DC"; }
        public override string Seven() { return "DCC"; }
        public override string Eight() { return "CCM"; }
        public override string Nine() { return "CM"; }
    }
    // Translates tens to roman numerals
    public class TenExpression : Expression
    {
        public override string Zero() { return " "; }
        public override string One() { return "X"; }
        public override string Two() { return "XX"; }
        public override string Three() { return "XXX"; }
        public override string Four() { return "XL"; }
        public override string Five() { return "L"; }
        public override string Six() { return "LX"; }
        public override string Seven() { return "LXX"; }
        public override string Eight() { return "LXXX"; }
        public override string Nine() { return "XC"; }
    }
    // Translates ones to roman numerals
    public class OneExpression : Expression
    {
        public override string Zero() { return "0"; }
        public override string One() { return "I"; }
        public override string Two() { return "II"; }
        public override string Three() { return "III"; }
        public override string Four() { return "IV"; }
        public override string Five() { return "V"; }
        public override string Six() { return "VI"; }
        public override string Seven() { return "VII"; }
        public override string Eight() { return "IIX"; }
        public override string Nine() { return "IX"; }
    }
}

