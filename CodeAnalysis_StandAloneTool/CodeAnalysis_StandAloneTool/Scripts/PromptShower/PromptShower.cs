using CodeAnalysis_StandAloneTool.Scripts;
using System;
using System.IO;

namespace Scripts.PromptShower
{
    public static class PromptShower
    {
        /// <summary>
        /// Shows a prompt that asks for a valid file path.
        /// </summary>
        /// <returns>the filled in path if it is correct</returns>
        public static string FillInClassFilePathPrompt()
        {
            return FillInPathPrompt(Prompts.GiveValidPath, Prompts.NotAValidPath);
        }

        public static string FillInRepositoryPathPrompt()
        {
            return FillInPathPrompt(Prompts.GiveValidRepoPath, Prompts.NotValidRepoPath);
        }

        private static string FillInPathPrompt(string validPathMessage, string NotValidPathMessage)
        {
            Console.WriteLine(validPathMessage);

            string answer = Console.ReadLine();

            while (IsValidPath(answer) == false)
            {
                Console.WriteLine(NotValidPathMessage);

                answer = Console.ReadLine();
            }

            return answer;
        }

        private static bool IsValidPath(string answer)
        {
            if (string.IsNullOrEmpty(answer))
                return false;

            if (File.Exists(answer) || Directory.Exists(answer))
                return true;

            return false;
        }
    }
}
