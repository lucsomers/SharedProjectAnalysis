using ExternalReferenceFinder;
using Microsoft.Build.Construction;

internal class Program
{
    private static void Main(string[] args)
    {
        FindAllSolutionsBase();
    }

    private static void FindAllSolutionsBase()
    {
        //find all solutions in folder
        string path = Console.ReadLine();

        List<SolutionFileData> solutionFiles = FindAllSolutions(path);



        //find all projects in solution
        foreach (SolutionFileData solutionFile in solutionFiles)
        {
            Console.WriteLine("------------------");

            Console.WriteLine($"Found solution {solutionFile.GetSolutionName()} Projects in this solution:");

            foreach (ProjectInSolution project in solutionFile.SolutionFile.ProjectsInOrder)
            {
                //find all methods in project
                //if (project.ProjectName != "Contoso.Common")
                //    continue;
                Console.WriteLine($"       {project.ProjectName}");
            }

            Console.WriteLine("------------------");
        }
    }

    public static List<SolutionFileData> FindAllSolutions(string directoryPath)
    {
        List<SolutionFileData> solutionFiles = new List<SolutionFileData>();

        string[] solutionPaths = Directory.GetFiles(directoryPath, "*.sln", SearchOption.AllDirectories);

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