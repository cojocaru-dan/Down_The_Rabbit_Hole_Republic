namespace Codecool.DownTheRabbitHoleRepublic;

class Program
{
    private static readonly string WorkDir = AppDomain.CurrentDomain.BaseDirectory;

    public static void Main(string[] args)
    {
        SplitRepublic();
        SplitAlice();

        Console.ReadKey();
    }

    private static void SplitRepublic()
    {
        using var reader = new StreamReader("Resources//the-republic.txt");
        string path = "the-republic//";
        try
        {
            string fileText = reader.ReadToEnd();
            string[] chapters = fileText.Split("# CHAPTER", StringSplitOptions.RemoveEmptyEntries)[1..];

            foreach (var chapter in chapters)
            {
                string chapterName = chapter[..chapter.IndexOf(".")];
                string chapterFileName = path + $"the-republic - {chapterName}.txt";

                using StreamWriter writer = new StreamWriter(chapterFileName);
                writer.Write(chapter);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void SplitAlice()
    {
        using var reader = new StreamReader("Resources\\alice-in-wonderland.txt");
        try
        {
            string fileText = reader.ReadToEnd();
            string[] chapters = fileText.Split("#chapter", StringSplitOptions.RemoveEmptyEntries)[1..];

            string outputDirectory = "alice-in-wonderland";
            Directory.CreateDirectory(outputDirectory);

            foreach (var chapter in chapters)
            {
                string chapterName = chapter[..chapter.IndexOf(".")];
                string chapterFileName = Path.Combine(outputDirectory, $"alice-in-wonderland - {chapterName}.txt");

                using StreamWriter writer = new StreamWriter(chapterFileName);
                writer.Write(chapter);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }

}
