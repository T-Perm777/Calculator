class Program
{
    static void Main()
    {
        var Functions = new Functions();
        Dictionary<string, Func<object>> functionList = new();
        functionList["sqrt"] = () => Functions.sqrt();
        functionList["add"] = () => Functions.add();
        functionList["sub"] = () => Functions.sub();
        functionList["mul"] = () => Functions.mul();
        functionList["div"] = () => Functions.div();
        functionList["quadratic"] = () => Functions.quadratic();

        bool moreCalculations = true;
        while (moreCalculations)
        {
            Console.WriteLine("Here are your calculation options: ");
            foreach (string key in functionList.Keys)
            {
                Console.WriteLine(key);
            }
            Console.WriteLine("What's your choice?");
            string userChoice = Console.ReadLine();
            if (functionList.ContainsKey(userChoice))
            {
                var result = functionList[userChoice]();
                if (result is double val)
                {
                    Console.WriteLine($"The results is {val}");
                }
                else if (result is List<double> list)
                {
                    Console.WriteLine($"The result(s) is/are {String.Join(", ", list)}");
                }
                else
                {
                    Console.WriteLine($"{userChoice} isn't an option.");
                }
            }
            Console.WriteLine("Would you like to calculate more? [Y/n]");
            try
            {
                moreCalculations = Console.ReadLine().ToLower() == "n" ? false : true;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"You can't enter that! Exception: {ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an error: {ex}");
            }
        }
    }
}
class Functions
{
    public double sqrt()
    {
        Console.WriteLine("Enter a non-negative number:");
        double num = Convert.ToDouble(Console.ReadLine());
        if (num < 0)
        {
            Console.WriteLine("no.");
            return double.NaN;
        }
        if (num == 0)
        {
            return 0;
        }
        if (num == 1)
        {
            return 1;
        }
        double guess = num / 2;
        double result = new();
        double diff = new();
        double tolerance = 0.0000000001;
        while (diff > tolerance)
        {
            result = 0.5 * (guess + (num / guess));
            diff = result - guess;
            diff = diff < 0 ? -diff : diff;
            guess = result;
            
        }
        return result;
    }
    public double add()
    {
        Console.WriteLine("Enter numbers when prompted. Type = to calculate.");
        List<double> numbersToAdd = new List<double>();
    	string userInput = "0.0";
    	while (userInput != "_")
    	{
    		if (double.TryParse(userInput, out double num))
    		{
    			numbersToAdd.Add(num);
    		}
    		else
    		{
    			Console.WriteLine("Please enter either a number or an underscore");
    		}
    		Console.WriteLine("Enter a number or an underscore");
    		userInput = Console.ReadLine();
    	}
        double sum = 0;
        foreach (double num in numbersToAdd)
        {
            sum += num;
        }
        return sum;
    }
    public double sub()
    {
        List<double> numbersToSubtract = new List<double>();
        string userInput = "0.0";
        while (userInput != "_")
        {
            if (double.TryParse(userInput, out double num))
            {
                numbersToSubtract.Add(num);
            }
            else
            {
                Console.WriteLine("Please enter either a number or an underscore");
            }
            Console.WriteLine("Enter a number or an underscore");
            userInput = Console.ReadLine();
        }
        double difference = 0;
        foreach (double num in numbersToSubtract)
        {
            difference -= num;
        }
        return difference;
    }
    public double mul()
    {
        List<double> numbersToMultiply = new List<double>();
        string userInput = "1.0";
        while (userInput != "_")
        {
            if (double.TryParse(userInput, out double num))
            {
                numbersToMultiply.Add(num);
            }
            else
            {
                Console.WriteLine("Please enter a number or an underscore");
            }
            Console.WriteLine("Enter a number or an underscore");
            userInput = Console.ReadLine();
        }
        double product = 1;
        foreach (double num in numbersToMultiply)
        {
            product *= num;
        }
        return product;
    }
    public double div()
    {
        List<double> numbersToDivide = new List<double>();
        string userInput = "1.0";
        while (userInput != "_")
        {
            if (double.TryParse(userInput, out double num))
            {
                numbersToDivide.Add(num);
            }
            else
            {
                Console.WriteLine("Please enter a number or an underscore");
            }
            Console.WriteLine("Enter a number or an underscore");
            userInput = Console.ReadLine();
        }
        double quotient = 1;
        foreach (double num in numbersToDivide)
        {
            quotient /= num;
        }
        return quotient;

    }
    public List<double> quadratic()
    {
        var internalFunctions = new InternalFunctions();
        Console.WriteLine("Format: ax² + bx + c");
        double a = new();
        double b = new();
        double c = new();
        Console.WriteLine("Enter a:");
        a = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter b:");
        b = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter c:");
        c = Convert.ToDouble(Console.ReadLine());
        double xPositive = new();
        double xNegative = new();
        double Discriminant = ((b * b) - (4 * a * c));
        List<double> xValues = new();
        if (((b * b) - (4 * a * c)) < 0)
        {
            Console.WriteLine("Function returns a nonreal value.");
            Console.WriteLine("the dev was too lazy to code in ⅈ");
            xValues.Add(double.NaN);
            return xValues;
        }
        xPositive = (-b + internalFunctions.sqrtInternal(Discriminant)) / (2 * a);
        xNegative = (-b - internalFunctions.sqrtInternal(Discriminant)) / (2 * a);
        if (xPositive == xNegative)
        {
            Console.WriteLine("There is one x value:");
            xValues.Add(xPositive);
            return xValues;
        }
        else
        {
            Console.WriteLine("There are two x values:");
            xValues.Add(xPositive);
            xValues.Add(xNegative);
            return xValues;
        }
    }
}
class InternalFunctions
{
    public double sqrtInternal(double num)
    {
        if (num == 0)
        {
            return 0;
        }
        if (num == 1)
        {
            return 1;
        }
        double guess = num / 2;
        double result = new();
        double diff = new();
        double tolerance = 0.0000000001;
        while (diff > tolerance)
        {
            result = 0.5 * (guess + (num / guess));
            diff = result - guess;
            diff = diff < 0 ? -diff : diff;
            guess = result;
        }
        return result;
    }
}
