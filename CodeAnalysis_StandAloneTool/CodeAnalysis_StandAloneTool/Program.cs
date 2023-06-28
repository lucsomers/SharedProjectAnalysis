﻿using CodeAnalysis_StandAloneTool.Scripts;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Scripts.PromptShower;
using System.Collections.Generic;

namespace HelloSyntaxTree
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                string path = PromptShower.FillInClassFilePathPrompt();

                SyntaxTree tree = SyntaxTreeGetter.GetSyntaxTreeFromFile(path);

                List<MethodDeclarationSyntax> methods = new List<MethodDeclarationSyntax>();

                int selectedAnswerIndex = MethodSelector.SelectMethod(tree, methods);



                keepGoing = ProgramRepeater.CheckForRepeat(keepGoing);
            }
        }


    }
}