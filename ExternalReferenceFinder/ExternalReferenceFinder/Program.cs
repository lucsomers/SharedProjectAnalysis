using ExternalReferenceFinder;
using Microsoft.Build.Construction;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;

internal class Program
{
    private static void Main(string[] args)
    {
        FindAllSolutionsBase();
        FindAllClassFiles();
    }

    private static void FindAllClassFiles()
    {
        string[] solutionPaths = Directory.GetFiles("D:\\GithubRepos\\SharedProjectAnalysis", "*.cs", SearchOption.AllDirectories);

        foreach (string path in solutionPaths)
        {
            string[] array = File.ReadAllLines(path);

            Console.WriteLine("--------------------- New file started ---------------------");

            foreach (string s in array)
            {
                Console.WriteLine(s);
            }
        }
    }

    private static void FindAllSolutionsBase()
    {
        List<SolutionFileData> data = FindAllFilesWithExtension("D:\\GithubRepos\\SharedProjectAnalysis", "*.sln");

        foreach (SolutionFileData solutionFile in data)
        {
            string[] array = File.ReadAllLines(solutionFile.SolutionPath);

            Console.WriteLine("--------------------- New file started ---------------------");

            foreach (string s in array)
            {
                Console.WriteLine(s);
            }
        }
    }

    public static List<SolutionFileData> FindAllFilesWithExtension(string directoryPath, string extension)
    {
        List<SolutionFileData> solutionFiles = new List<SolutionFileData>();

        string[] solutionPaths = Directory.GetFiles(directoryPath, extension, SearchOption.AllDirectories);

        foreach (string solutionPath in solutionPaths)
        {
            SolutionFile solutionFile = SolutionFile.Parse(solutionPath);

            if (solutionFile == null)
                continue;

            solutionFiles.Add(new SolutionFileData(solutionFile, solutionPath));
        }

        return solutionFiles;
    }
}