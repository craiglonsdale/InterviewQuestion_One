using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TriangleSolver;

namespace ReadifyInterviewQuestion_2
{
    class ReadifyInterviewQuestionTwo
    {
        private static List<int> sm_isosceles = new List<int> { 1, 2, 2};
        private static List<int> sm_scalene = new List<int>{1, 2, 3};
        private static List<int> sm_equilateral = new List<int> { 1, 1, 1 };
        private static List<int> sm_error = new List<int> { 0, 1, 3 };
        
        static void Main(string[] args)
        {
            Console.Out.WriteLine("Sides: {0} are {1}", String.Join(", ", sm_isosceles), TriangleSolverUtilities.SolveTriangleType(sm_isosceles));
            Console.Out.WriteLine("Sides: {0} are {1}", String.Join(", ", sm_scalene), TriangleSolverUtilities.SolveTriangleType(sm_scalene));
            Console.Out.WriteLine("Sides: {0} are {1}", String.Join(", ", sm_equilateral), TriangleSolverUtilities.SolveTriangleType(sm_equilateral));
            Console.Out.WriteLine("Sides: {0} are {1}", String.Join(", ", sm_error), TriangleSolverUtilities.SolveTriangleType(sm_error));
            Console.Read();
        }
    }
}
