internal class NewFile
    {

       static void Main()
       {

           int n = 12;

           int result = Factorial(n);

           Console.WriteLine("The factorial of a no. is : " + result);

       }

       //Tightly coupled 
       static int Factorial(int n)
       { 
          //Helper Method -- Local Function
           int LoopFactorial()
           {
               int result = 1;
               for (int i = 2; i <= n; i++)
               { 
                 result = result * i;
               }
               return result;


           }

           return LoopFactorial(); 


       }
    }