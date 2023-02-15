using Microsoft.Build.Construction;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        //find all solutions in folder
        string path = Console.ReadLine();

        List<SolutionFile> solutionFiles = FindAllSolutions(path);

        //find all projects in solution
        foreach(SolutionFile solutionFile in solutionFiles)
        {
            Console.WriteLine("------------------");

            Console.WriteLine($"Found solution {solutionFile}. Projects in this solution:");

            foreach (ProjectInSolution project in solutionFile.ProjectsInOrder)
            {
                //find all methods in project
                Console.WriteLine($"       {project.ProjectName}");
            }

            Console.WriteLine("------------------");
        }
        //check if they are a reference to the given method
    }

    public static List<SolutionFile> FindAllSolutions(string directoryPath)
    {
        List<SolutionFile> solutionFiles = new List<SolutionFile>();

        string[] solutionPaths = Directory.GetFiles(directoryPath, "*.sln", SearchOption.AllDirectories);

        foreach (string solutionPath in solutionPaths)
        { 
            SolutionFile solutionFile = SolutionFile.Parse(solutionPath);

            if (solutionFile == null)
                continue;

            solutionFiles.Add(solutionFile);
        }

        return solutionFiles;
    }
}