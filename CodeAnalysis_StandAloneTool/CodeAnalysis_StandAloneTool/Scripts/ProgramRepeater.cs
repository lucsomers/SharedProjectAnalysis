using System;

namespace CodeAnalysis_StandAloneTool.Scripts
{
    internal class ProgramRepeater
    {
        public static bool CheckForRepeat(bool keepGoing)
        {
            string answer = "";

            while (answer != "Y" && answer != "N")
            {
                Console.WriteLine();
                Console.WriteLine("Do you want to read another file? (Y)/(N)");

                answer = Console.ReadLine();

                if (answer == "N")
                {
                    keepGoing = false;
                    continue;
                }

                if (answer == "Y")
                    continue;

                Console.WriteLine("InvalidAnswer");
            }

            return keepGoing;
        }
    }
}
