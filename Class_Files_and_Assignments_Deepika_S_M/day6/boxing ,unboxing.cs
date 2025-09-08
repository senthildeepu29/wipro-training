// class Non -Generic;

// // boxing/unboxing
// // boxing :- When we convert a value type(like int ) into an object type(reference type)

// int num 
// value1 = 10;
// object boxedvalue = num;  // boxing

// Unboxing  :-  when we extract the value type from an object

// int valuetype = (int)boxedvalue;  // unboxing

// These operations are expensive in performance :- then there will be a memory overhead  ,
//   This one is non type-safe because by mistaken wrong casting can be done which may cause a run time errors

//   List<Student> list = new List<Student>();

//   for(int i=0 ; i<5 ; i++)
//   {
//     Student s = new Student(3434,"df");
//      list.Add(s);
//   }

//   List<int> numbers = new List<int>();
//   numbers.Add(10);  // No boxing
//   int result = numbers[0]; // No Unboxing
 
//  // Non-Generic
//   List numbers = new List();
//   numbers.Add(10);  // No boxing
//   int result = numbers[0]; // No Unboxing

//   c# provides some wrapper classes 

//   Wrapper class is a class that wraps value types to provide some extra functionalities
//   System.Object which is the universal 

//   System.Int32 -- wraps -- value type which is int  -- Gene