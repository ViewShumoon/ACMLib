using ACMLib.Framework.Models;
using System;

namespace ACMLib.Framework.Attribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SolutionTypeAttribute : System.Attribute
    {
        public DataStructureType DataStructureType { get;set; }
        public AlgorithmType AlgorithmType { get; set; }

        public SolutionTypeAttribute(DataStructureType dataStructure = DataStructureType.未指定, AlgorithmType algorithmType = AlgorithmType.未指定)
        {
            DataStructureType = dataStructure;
            AlgorithmType = algorithmType;
        }
    }
}
