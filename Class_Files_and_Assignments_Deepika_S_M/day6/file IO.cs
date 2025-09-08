// using System;
// using System.IO;
// using System.Text;

// class P2
// {
//     static void Main()
//     {
//         string path = "file1.txt";
//         string message = "File data related to C#";

//         // Writing data using FileStream
//         using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
//         {
//             byte[] data = Encoding.UTF8.GetBytes(message);
//             fs.Write(data, 0, data.Length);
//         }

//         Console.WriteLine("Data written to file successfully.");
//     }
// }
