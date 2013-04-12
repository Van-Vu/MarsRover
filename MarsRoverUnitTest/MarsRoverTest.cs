using MarsRover;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverUnitTest
{
    [TestClass]
    public class MarsRoverTest
    {
        private MarsRoverProcessor marsRoverProcessor;

        [TestInitialize]
        public void Initialize()
        {
            marsRoverProcessor = new MarsRoverProcessor();    
        }

        [TestMethod]
        public void RoverMoveSuccessful()
        {
            // Arrange
            var input = "5 5\r\n1 2 N\r\nLMLMLMLMM\r\n3 3 E\r\nMMRMMRMRRM";
            var expected = "1 3 N\r\n5 1 E";

            // Action
            var output = marsRoverProcessor.Process(input);

            // Assert
            Assert.AreEqual(expected,output);
        }

        [TestMethod]
        public void RoverTurnLeftExpectDirectionChangeLeft()
        {
            // Arrange
            var input = "5 5\r\n1 2 N\r\nL";
            var expected = "1 2 W";

            // Action
            var output = marsRoverProcessor.Process(input);

            // Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void RoverTurnRightExpectDirectionChangeRight()
        {
            // Arrange
            var input = "5 5\r\n1 2 N\r\nR";
            var expected = "1 2 E";

            // Action
            var output = marsRoverProcessor.Process(input);

            // Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void RoverMoveForwardExpectLocationForward()
        {
            // Arrange
            var input = "5 5\r\n1 2 N\r\nM";
            var expected = "1 3 N";

            // Action
            var output = marsRoverProcessor.Process(input);

            // Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void RoverTurnLeftThenTurnRightExpectSameLocationAndDirection()
        {
            // Arrange
            var input = "5 5\r\n1 2 N\r\nLR";
            var expected = "1 2 N";

            // Action
            var output = marsRoverProcessor.Process(input);

            // Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void RoverMoveOutOfThePlatateauExpectErrorMessage()
        {
            // Arrange
            var input = "2 2\r\n1 1 N\r\nMM";
            var expected = "Rover location is out of the plateau";

            // Action
            var output = marsRoverProcessor.Process(input);

            // Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestWithInputIncorrectNumberOfLineExpectErrorMessage()
        {
            // Arrange
            var input = "5 5";
            var expected = "Wrong input file";

            // Action
            var output = marsRoverProcessor.Process(input);

            // Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestWithIncorrectPlateauCoordinatesExpectErrorMessage()
        {
            // Arrange
            var input = "5 5 Test\r\n1 2 N\r\nLMLMLMLMM";
            var expected = "Incorrect plateau coordinates";

            // Action
            var output = marsRoverProcessor.Process(input);

            // Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestWithIncorrectPlateauXCoordinateExpectErrorMessage()
        {
            // Arrange
            var input = "Test 5\r\n1 2 N\r\nLMLMLMLMM";
            var expected = "Incorrect plateau x coordinate";

            // Action
            var output = marsRoverProcessor.Process(input);

            // Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestWithIncorrectPlateauYCoordinateExpectErrorMessage()
        {
            // Arrange
            var input = "5 Test\r\n1 2 N\r\nLMLMLMLMM";
            var expected = "Incorrect plateau y coordinate";

            // Action
            var output = marsRoverProcessor.Process(input);

            // Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestWithNegativePlateauCoordinateExpectErrorMessage()
        {
            // Arrange
            var input = "-5 -1\r\n1 2 N\r\nLMLMLMLMM";
            var expected = "Incorrect plateau coordinates";

            // Action
            var output = marsRoverProcessor.Process(input);

            // Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestWithIncorrectRoverDeployLocationExpectErrorMessage()
        {
            // Arrange
            var input = "5 5\r\n1 2 N Test\r\nLMLMLMLMM";
            var expected = "Incorrect rover deploy location";

            // Action
            var output = marsRoverProcessor.Process(input);

            // Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestWithIncorrectRoverXCoordinateExpectErrorMessage()
        {
            // Arrange
            var input = "5 5\r\nTest 2 N\r\nLMLMLMLMM";
            var expected = "Incorrect x coordinate";

            // Action
            var output = marsRoverProcessor.Process(input);

            // Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestWithIncorrectRoverYCoordinateExpectErrorMessage()
        {
            // Arrange
            var input = "5 5\r\n1 Test N\r\nLMLMLMLMM";
            var expected = "Incorrect y coordinate";

            // Action
            var output = marsRoverProcessor.Process(input);

            // Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestWithIncorrectRoverInitDirectionExpectErrorMessage()
        {
            // Arrange
            var input = "5 5\r\n1 2 WrongDirection\r\nLMLMLMLMM\r\n3 3 E\r\nMMRMMRMRRM";
            var expected = "Incorrect direction";

            // Action
            var output = marsRoverProcessor.Process(input);

            // Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestWithIncorrectRoverMovementCommandExpectErrorMessage()
        {
            // Arrange
            var input = "5 5\r\n1 2 N\r\nWrongCommand";
            var expected = "Incorrect movement command";

            // Action
            var output = marsRoverProcessor.Process(input);

            // Assert
            Assert.AreEqual(expected, output);
        }
    }
}
