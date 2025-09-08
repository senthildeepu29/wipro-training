// using System;
// using System.Collections.Generic;
// class CollectionsProg
// {
//     static void Main()
//     {
//         Console.WriteLine("Enter no. of students: ");
//         int a = Convert.ToInt32(Console.ReadLine());
//         List<string> StudentsId = new List<string>();

//         int average = 0;
//         Dictionary<string, int> stddetail = new Dictionary<string, int>();
//         List<int> avgmarks = new List<int>();
//         for (int i = 0; i < a; i++)
//         {
//             Console.WriteLine("Enter Student id " + (i + 1) + ": ");
//             StudentsId.Add(Console.ReadLine());

//             Console.Write("Number of Subjects: ");
//             int totsub = Convert.ToInt32(Console.ReadLine());

//             for (int j = 1; j <= totsub; j++)
//             {
//                 Console.Write($"Enter Student subject {j}: ");
//                 string subject = Console.ReadLine();
//                 Console.Write("Enter marks: ");
//                 int marks = Convert.ToInt32(Console.ReadLine());

//                 stddetail.Add(subject, marks);
//                 average += marks;
//             }
//             avgmarks.Add(average / totsub);
//         }
//     }
// }