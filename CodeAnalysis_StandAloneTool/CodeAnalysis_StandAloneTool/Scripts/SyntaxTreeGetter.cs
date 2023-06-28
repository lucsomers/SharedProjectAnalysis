using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.IO;
using static System.Console;

namespace CodeAnalysis_StandAloneTool.Scripts
{
    internal static class SyntaxTreeGetter
    {
        public static SyntaxTree GetSyntaxTreeFromFile(string path)
        {
            string filetext = File.ReadAllText(path);

            SyntaxTree tree = CSharpSyntaxTree.ParseText(filetext);
            CompilationUnitSyntax root = tree.GetCompilationUnitRoot();

            WriteLine($"The tree is a {root.Kind()} node.");
            WriteLine($"The tree has {root.Usings.Count} using statements. They are:");

            foreach (UsingDirectiveSyntax element in root.Usings)
                WriteLine($"\t{element.Name}");

            return tree;
        }
    }
}
