// using System;

// namespace School
// {
//     // Interface 1
//     public interface ICurricularActivities
//     {
//         void Stream();
//     }

//     // Interface 2
//     public interface INonCurricularActivities
//     {
//         void Activities();
//     }

//     // Base class
//     public class Person
//     {
//         public string Name { get; set; }

//         public void Display()
//         {
//             Console.WriteLine("Student Name: " + Name);
//         }
//     }

//     // Student class implementing both interfaces
//     public class Student : Person, ICurricularActivities, INonCurricularActivities
//     {
//         public int RollNumber { get; set; }

//         public void Study()
//         {
//             Console.WriteLine("Studying hard...");
//         }

//         public void Stream()
//         {
//             Console.WriteLine("Taken Science Stream");
//         }

//         public void Activities()
//         {
//             Console.WriteLine("Sports - BasketBall");
//         }

//         // Entry point
//         public static void Main()
//         {
//             Student s = new Student();

//             Console.WriteLine("Enter the name of student:");
//             string sname = Console.ReadLine();
//             s.Name = sname;

//             s.Study();
//             s.Display();
//             s.Stream();
//             s.Activities();
//         }
//     }
// }
