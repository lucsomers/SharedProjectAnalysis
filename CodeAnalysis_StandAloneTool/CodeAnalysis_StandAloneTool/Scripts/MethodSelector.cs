using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace CodeAnalysis_StandAloneTool.Scripts
{
    internal static class MethodSelector
    {
        public static int SelectMethod(SyntaxTree tree, List<MethodDeclarationSyntax> methods)
        {
            IEnumerable<SyntaxNode> members = tree.GetRoot().DescendantNodes().OfType<MemberDeclarationSyntax>();

            PrintAllMethods(members, methods);

            WriteLine();
            WriteLine($"Give the index number of the method you want to check.");

            string answer = ReadLine();
            int selectedIndex = SelectIndexFromMethods(methods, answer);

            return selectedIndex;
        }

        private static int SelectIndexFromMethods(List<MethodDeclarationSyntax> methods, string answer)
        {
            while (AnswerIsValid(answer, methods.Count) == false)
            {
                WriteLine($"Number is not valid give a valid number to pick a method.");
                answer = ReadLine();
            }

            return int.Parse(answer);
        }

        private static void PrintAllMethods(IEnumerable<SyntaxNode> members, List<MethodDeclarationSyntax> methods)
        {
            WriteLine();
            WriteLine("Methods in this class file:");

            foreach (MemberDeclarationSyntax member in members)
            {
                MethodDeclarationSyntax method = member as MethodDeclarationSyntax;

                if (method != null)
                {
                    methods.Add(method);
                    WriteLine($"{methods.Count} - Method: {method.Identifier}");
                }
            }

            WriteLine();
        }

        private static bool AnswerIsValid(string answer, int methodListCount)
        {
            if (int.TryParse(answer, out int answerIndex))
            {
                if (answerIndex <= methodListCount && answerIndex > 0)
                    return true;
            }

            return false;
        }
    }
}
