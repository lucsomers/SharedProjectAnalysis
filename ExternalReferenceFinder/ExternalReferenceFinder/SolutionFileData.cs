using Microsoft.Build.Construction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalReferenceFinder
{
    internal class SolutionFileData
    {
        private SolutionFile solutionFile;
        private string solutionName;
        private string solutionPath;

        public SolutionFileData(SolutionFile solutionFile, string solutionPath)
        {
            this.solutionFile = solutionFile;
            this.solutionPath = solutionPath;
            this.solutionName = "";
        }

        public string GetSolutionName()
        {
            if (solutionName != "")
                return solutionName;

            string[] split = solutionPath.Split('\\');

            solutionName = split[^1];

            return solutionName;
        }

        public SolutionFile SolutionFile { get => solutionFile; set => solutionFile = value; }
        public string SolutionPath { get => solutionPath; set => solutionPath = value; }
    }
}
