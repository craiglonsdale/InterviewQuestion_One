using System;
using System.Collections.Generic;
using NUnit.Framework;
using TriangleSolver;

namespace ReadifyInterviewQuestion_2_Tests
{
    /// <summary>
    /// I attempt to have all of my tests behave in a 'Who', 'Then', 'Then' Pattern in method naming scheme as well as behavior.
    /// It makes the method name clear enough that it should avoid the need to overdocumentation in the
    /// test code as well as keep the codes as short as possible
    /// </summary>
    [TestFixture]
    public class Question2_Tests
    {
        /// <summary>
        /// Static test data representing all possible results
        /// </summary>
        private static List<int> EQUILATERAL = new List<int> { 1, 1, 1 };
        private static List<int> ISOSCELES = new List<int> { 1, 2, 2 };
        private static List<int> SCALENE = new List<int> { 1, 2, 3 };
        private static List<int> ERROR = new List<int> { 0, 1, 2 };
        private static List<int> EXCEPTION_SMALL = new List<int> { 1, 2 };
        private static List<int> EXCEPTION_LARGE = new List<int> { 1, 2, 3, 4 };

        [Test, ExpectedException(typeof(ArgumentException))]
        public void TriangleSolver_IncorrectSizeListSmall_Thows()
        {
            TriangleSolverUtilities.SolveTriangleType(EXCEPTION_SMALL);
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void TriangleSolver_IncorrectSizeListLarge_Thows()
        {
            TriangleSolverUtilities.SolveTriangleType(EXCEPTION_LARGE);
        }

        [Test]
        public void TriangleSolver_ZeroLengthSide_ErrorReturn()
        {
            Assert.AreEqual(TriangleType.Error, TriangleSolverUtilities.SolveTriangleType(ERROR));
        }

        [Test]
        public void TriangleSolver_ZeroLengthSideList_ErrorReturn()
        {
            Assert.AreEqual(TriangleType.Error, TriangleSolverUtilities.SolveTriangleType(ERROR[0], ERROR[1], ERROR[2]));
        }

        [Test]
        public void TrinagleSolver_EquilateralSidesList_EquilateralReturn()
        {
            Assert.AreEqual(TriangleType.Equilateral, TriangleSolverUtilities.SolveTriangleType(EQUILATERAL));
        }

        [Test]
        public void TrinagleSolver_EquilateralSides_EquilateralReturn()
        {
            Assert.AreEqual(TriangleType.Equilateral, TriangleSolverUtilities.SolveTriangleType(EQUILATERAL[0], EQUILATERAL[1], EQUILATERAL[2]));
        }

        [Test]
        public void TrinagleSolver_IsoscelesSidesList_IsoscelesReturn()
        {
            Assert.AreEqual(TriangleType.Isosceles, TriangleSolverUtilities.SolveTriangleType(ISOSCELES));
        }

        [Test]
        public void TrinagleSolver_IsoscelesSides_IsoscelesReturn()
        {
            Assert.AreEqual(TriangleType.Isosceles, TriangleSolverUtilities.SolveTriangleType(ISOSCELES[0], ISOSCELES[1], ISOSCELES[2]));
        }

        [Test]
        public void TrinagleSolver_ScaleneSidesList_ScaleneReturn()
        {
            Assert.AreEqual(TriangleType.Scalene, TriangleSolverUtilities.SolveTriangleType(SCALENE));
        }

        [Test]
        public void TrinagleSolver_ScaleneSides_ScaleneReturn()
        {
            Assert.AreEqual(TriangleType.Scalene, TriangleSolverUtilities.SolveTriangleType(SCALENE[0], SCALENE[1], SCALENE[2]));
        }
    }
}
