namespace G12_20221006;

internal static class FileHelper
{
    public static List<string> OpenFile(string inputFilePath)
    {
        ValidateInputFile(inputFilePath);
        List<string> files = new List<string>();
        
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                
                while (!reader.EndOfStream)
                {
                    files.Add(reader.ReadLine());
                }
                
            }
       
        return files;
    }

    public static void RenumberingLines(string inputFilePath)
    {
        List<string> files = new List<string>();

        files = OpenFile(inputFilePath);

        string name = "";

        int count = 0;

        for (int i = 0; i < files.Count; i++)
        {
            name = files[i];
            name = $"{i + 1}. " + name;
            files[i] = name;
            count += files[i].Length;
        }
        WriterLine(files, inputFilePath);
    }

    private static void WriterLine(List<string> files, string outputFilePath)
    {
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            for (int i = 0; i < files.Count; i++)
            {
                writer.WriteLine(files[i]);
            }
        }
    }

    public static int GetCharactersCount(string inputFilePath)
    {
        int symbolCount = 0;
        foreach (var character in GetCharactersFrequency(inputFilePath))
        {
            symbolCount += character.Value;
        }
        return symbolCount;
    }

    public static Dictionary<char, int> GetCharactersFrequency(string inputFilePath)
    {
        Dictionary<char, int> frequency = new Dictionary<char, int>();
        List<string> _files = OpenFile(inputFilePath);

        for (int i = 0; i < _files.Count; i++)
        {
            string line = _files[i];
            if (line == null)
                continue;

            for (int k = 3; k < line.Length; k++)
            {
                if (
                    line[k] > 47 && line[k] < 58 ||
                    line[k] > 64 && line[k] < 91 ||
                    line[k] > 96 && line[k] < 123
                    )
                {
                    if (frequency.ContainsKey(line[k]))
                        frequency[line[k]]++;
                    else
                    {
                        frequency.Add(line[k], 1);
                    }
                }
            }
        }
        return frequency;
    }

    public static string WordCount(string inputFilePath)
    {
        List<string> file=new List<string>();

        int wordCount = 0;
        int index = 0;

        foreach (var item in OpenFile(inputFilePath))
        {
            string name = "";

            for (int i = 0; i < item.Length; i++)
            {
                var tt = item[i];

                if (
                    item[i] > 47 && item[i] < 58 ||
                    item[i] > 64 && item[i] < 91 ||
                    item[i] > 96 && item[i] < 123
                    )

                    name += item[i];

                if (item[i] == ' ' || item.Length-1 == i)
                {
                    if (!string.IsNullOrEmpty(name))
                    {
                        file.Add(name);
                        wordCount++;
                        name = "";
                    }

                    continue;
                }
            }
        }

        return $"This file is {wordCount} word!";
    }

    private static void ValidateInputFile(string inputFilePath)
    {
        if (inputFilePath == null)
        {
            throw new ArgumentNullException(nameof(inputFilePath));
        }

        if (!File.Exists(inputFilePath))
        {
            throw new FileNotFoundException($"File {inputFilePath} not found");
        }
    }

    public static void Print<T>(List<T> name)
    {
        foreach (var item in name)
        {
            Console.WriteLine(item);
        }
    }

    public static void Print<T1, T2>(Dictionary<T1, T2> name, int number)
    {
        int index = 0;
        foreach (var item in name)
        {
            if (index % number == 0)
                Console.WriteLine();

            Console.Write($"{item.Key} - {item.Value} ");
            index++;
        }
    }
}