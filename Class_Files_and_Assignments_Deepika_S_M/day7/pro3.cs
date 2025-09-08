// class MultiCastDelegate
// {

//     // Delegate Declaration for add operations and Print 
//     // parameterized Delegates responsible for method invocation at runtime
//     public delegate int Operations(int a, int b);

//     public delegate void PrintDelegate(int result);

//     public static void Main(string[] args)
//     {

//         //Assign Methods to delegates
//         //Member functions are encapsulated using delegate
//         Operations Add = AddNumbers;
//         Operations Subtract = SubtractNumbers;



//         /*int a ;
//         // a =30;
//         ABC a1 = new ABC();
//         AddDelegate ad = AddNumbers;*/


//         // calling/using delegate
//         int sumResult = Add(10, 30);
//         int diffResult = Subtract(10, 30);

//         //Multi cast Delegate
//         PrintDelegate print = PrintResult; // adding first page as printResult method
//         print += PrintResultCalci; // adding second page as printresultcalci method

//         Console.WriteLine("Sum of two numbers :");
//         print(sumResult);
//         Console.WriteLine("Difference of two numbers :");
//         print(diffResult);
//        // Console.WriteLine("Enter your choice 1. for Addition and 2. for subtraction");
//       //  int choice = int.Parse(Console.ReadLine());

        
       

//     }


//     private static int AddNumbers(int x, int y)
//     { return x + y; }

//     private static int SubtractNumbers(int x, int y)
//     { return x - y; }

//     private static void PrintResult(int result)
//     {
//         Console.WriteLine("The result of addition is :" + result);
//     }

//     private static void PrintResultCalci(int result)
//     {
//         result = result * 10;
//         Console.WriteLine("after applying bonus :" + result);
//     }
// }

