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
        public static string FillInPathPrompt()
        {
            Console.WriteLine(Prompts.GiveValidPath);

            string answer = Console.ReadLine();

            while (IsValidPath(answer) == false)
            {
                Console.WriteLine(Prompts.NotAValidPath);

                answer = Console.ReadLine();
            }

            return answer;
        }

        private static bool IsValidPath(string answer)
        {
            if (string.IsNullOrEmpty(answer))
                return false;

            if (File.Exists(answer))
                return true;

            return false;
        }
    }
}
