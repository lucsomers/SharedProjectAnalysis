﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.IO;
using System.Linq;
using static System.Console;

namespace HelloSyntaxTree
{
    class Program
    {
        // </Snippet1>

        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string filetext = File.ReadAllText(path);

            // <Snippet2>
            SyntaxTree tree = CSharpSyntaxTree.ParseText(filetext);
            CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
            // </Snippet2>

            // <Snippet3>
            WriteLine($"The tree is a {root.Kind()} node.");
            WriteLine($"The tree has {root.Members.Count} elements in it.");
            WriteLine($"The tree has {root.Usings.Count} using statements. They are:");
            foreach (UsingDirectiveSyntax element in root.Usings)
                WriteLine($"\t{element.Name}");
            // </Snippet3>

            // <Snippet4>
            MemberDeclarationSyntax firstMember = root.Members[0];
            WriteLine($"The first member is a {firstMember.Kind()}.");
            MemberDeclarationSyntax namespaceDeclaration = firstMember as NamespaceDeclarationSyntax;

            if (namespaceDeclaration == null)
                Console.WriteLine("No namespace declaration detected");
            else
                Console.WriteLine($"Declared namespace is {namespaceDeclaration}");

            // </Snippet4>

            // <Snippet5>
            WriteLine($"There are {root.Members.Count} members declared in this namespace.");
            WriteLine($"The first member is a {root.Members[0].Kind()}.");
            // </Snippet5>

            // <Snippet6>
            var programDeclaration = (ClassDeclarationSyntax)root.Members[0];
            WriteLine($"There are {programDeclaration.Members.Count} members declared in the {programDeclaration.Identifier} class.");
            WriteLine($"The first member is a {programDeclaration.Members[0].Kind()}.");
            var mainDeclaration = (MethodDeclarationSyntax)programDeclaration.Members[0];
            // </Snippet6>

            // <Snippet7>
            WriteLine($"The return type of the {mainDeclaration.Identifier} method is {mainDeclaration.ReturnType}.");
            WriteLine($"The method has {mainDeclaration.ParameterList.Parameters.Count} parameters.");
            foreach (ParameterSyntax item in mainDeclaration.ParameterList.Parameters)
                WriteLine($"The type of the {item.Identifier} parameter is {item.Type}.");
            WriteLine($"The body text of the {mainDeclaration.Identifier} method follows:");
            WriteLine(mainDeclaration.Body.ToFullString());

            var argsParameter = mainDeclaration.ParameterList.Parameters[0];
            // </Snippet7>

            // <Snippet8>
            var firstParameters = from methodDeclaration in root.DescendantNodes()
                                                    .OfType<MethodDeclarationSyntax>()
                                  where methodDeclaration.Identifier.ValueText == "Main"
                                  select methodDeclaration.ParameterList.Parameters.First();

            var argsParameter2 = firstParameters.Single();

            WriteLine(argsParameter == argsParameter2);
            // </Snippet8>
        }
    }
}