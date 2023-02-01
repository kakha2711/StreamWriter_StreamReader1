using static G12_20221006.FileHelper;

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

/* shemdegi leqciis tema.
 * Stream readeris darchenili nawili.
 * konkretuli magaliti Dispose ze.
 * shedzlebisda gvarad daviwyot exceptionebi.
 */

string path = @"D:\G12.txt";
//RenumberingLines(path);

Console.WriteLine(WordCount(path));

//Print(OpenFile(path));

//Console.WriteLine();

//Print(GetCharactersFrequency(path), 5);

//Console.WriteLine("\n");

Console.WriteLine($"Characters count: {GetCharactersCount(path)}");