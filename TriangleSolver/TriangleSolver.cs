using System;
using System.Collections.Generic;
using System.Linq;

namespace TriangleSolver
{
    /// <summary>
    /// Different type of triangle available
    /// </summary>
    public enum TriangleType
    {
        Scalene = 0,
        Isosceles = 1,
        Equilateral = 2,
        Error = 3
    }
    
    /// <summary>
    /// Untility class containing methods to help solve details related to triangles.
    /// </summary>
    public static class TriangleSolverUtilities
    {
        /// <summary>
        /// Method that determines what type of triangle you have defined based off of it's 3 sides.
        /// </summary>
        /// <param name="firstSide">Triangle's first side</param>
        /// <param name="secondSide">Triangle's second side</param>
        /// <param name="thirdSide">Triangle's third side</param>
        /// <returns>The type of triangle that has been defined</returns>
        public static TriangleType SolveTriangleType(int firstSide, int secondSide, int thirdSide)
        {
            return SolveTriangleType(new List<int> { firstSide, secondSide, thirdSide });
        }

        /// <summary>
        /// Method that determines what type of triangle you have defined based off of it's 3 sides.
        /// </summary>
        /// <param name="sides">Collection of values representing a triangle (3 sides)</param>
        /// <returns>The type of triangle that has been defined</returns>
        public static TriangleType SolveTriangleType(IEnumerable<int> sides)
        {
            if (3 != sides.Count())
            {
                throw new ArgumentException("Incorrect number of values");
            }

            //Triangles can't have a 0-length side
            if (sides.Contains(0))
            {
                return TriangleType.Error;
            }

            var sideLengthGroup = sides.GroupBy(x => x);

            if (3 == sideLengthGroup.Count()) //There are 0 sides that have the same length
            {
                return TriangleType.Scalene;
            }
            else if (2 == sideLengthGroup.Count()) //There are 2 sides that are the same
            {
                return TriangleType.Isosceles;
            }

            //If we get to here there are 3 values that are the same.
            return TriangleType.Equilateral;
        }
    }
}
