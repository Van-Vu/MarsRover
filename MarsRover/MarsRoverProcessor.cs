using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using MarsRover.Directions;

namespace MarsRover
{
    /// <summary>
    /// Main class to process the rover movement
    /// </summary>
    public class MarsRoverProcessor
    {
        /// <summary>
        /// Entry point for the Mars Rover processor
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string Process(string text)
        {
            var result = new List<string>();

            try
            {
                // Parse file content to a list of string (ignore LineFeed character)
                var fileContent =
                    new List<string>(text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries));

                // Validate general content: plateau, number of lines ...
                ValidatePlateauInformation(fileContent);

                var plateauCoordinate = fileContent[0].Split(' ');
                // Construct the plateau coordinates
                var thePlateau = new Coodinate { X = Convert.ToInt32(plateauCoordinate[0]), Y = Convert.ToInt32(plateauCoordinate[1]) };

                // Process all rovers. If there's an error with a rover, it will be reported in the output then keep processing the next rover
                for (int lineNo = 1; lineNo < fileContent.Count; lineNo += 2)
                {
                    result.Add(ProccessRoverMovement(thePlateau, fileContent, lineNo));
                }
            }
            catch (InputFormatException inputFormatException)
            {
                result.Add(inputFormatException.Message);
            }

            return string.Join(Environment.NewLine, result.ToArray());
        }

        /// <summary>
        /// Walk through each command and change the rover's location and direction accordingly
        /// </summary>
        /// <param name="thePlateau"></param>
        /// <param name="fileContent"></param>
        /// <param name="lineNo"></param>
        /// <returns></returns>
        private string ProccessRoverMovement(Coodinate thePlateau, List<string> fileContent, int lineNo)
        {
            try
            {
                // Ensure all provided information for a rover is correct
                ValidateRoverInformation(fileContent, lineNo);

                // Construct a rover
                var theRover = InitializeRover(fileContent[lineNo]);
                if (theRover == null)
                {
                    throw new InputFormatException("Cannot initialize the rover");
                }
                // Ensure the rover doesn't fall out of plateau
                theRover.ValidateLocation(thePlateau);

                // Get the movement commands
                var roverMovementCommands = fileContent[lineNo + 1].ToCharArray();
                foreach (var movement in roverMovementCommands)
                {
                    switch (movement)
                    {
                        case 'L':
                            theRover.TurnLeft();
                            break;
                        case 'R':
                            theRover.TurnRight();
                            break;
                        case 'M':
                            theRover.MoveForward();
                            break;
                    }
                }

                // Ensure the rover doesn't fall out of plateau
                theRover.ValidateLocation(thePlateau);

                return string.Format("{0} {1} {2}", theRover.CurrentLocation.X, theRover.CurrentLocation.Y, theRover.CurrentDirection.Name);
            }
            catch (RoverLocationException roverLocationException)
            {
                return roverLocationException.Message;
            }
        }

        /// <summary>
        /// Contruct the rover object
        /// All information are already validated, so the construction is straightforward
        /// </summary>
        /// <param name="roverInformation"></param>
        /// <returns></returns>
        private Rover InitializeRover(string roverInformation)
        {
            var roverLocationInput = roverInformation.Split(' ');
            // Extract the initial location
            var roverLocation = new Coodinate { X = Convert.ToInt32(roverLocationInput[0]), Y = Convert.ToInt32(roverLocationInput[1]) };

            var stateFactory = new DirectionFactory();
            var direction = stateFactory.InitializeAllCardinalPoints();

            // Extract the initial direction
            var roverFirstDirection = stateFactory.GetDirection(direction, roverLocationInput[2]);
            if (roverFirstDirection == null) return null;

            return new Rover { CurrentDirection = roverFirstDirection, CurrentLocation = roverLocation };
        }

        /// <summary>
        /// Ensure file format and plateau information provided in the input file is correct
        /// </summary>
        /// <param name="fileContent"></param>
        /// <param name="lineNo"></param>
        private void ValidateRoverInformation(List<string> fileContent, int lineNo)
        {
            var roverLocationInput = fileContent[lineNo].Split(' ');
            if (roverLocationInput.Count() != 3)
            {
                throw new InputFormatException("Incorrect rover deploy location");
            }

            int position;
            if (!int.TryParse(roverLocationInput[0], out position))
            {
                throw new InputFormatException("Incorrect x coordinate");
            }

            if (!int.TryParse(roverLocationInput[1], out position))
            {
                throw new InputFormatException("Incorrect y coordinate");
            }

            var cardinalPoints = "NSWE";
            // Only allow North, West, South, East
            if (cardinalPoints.IndexOf(roverLocationInput[2], StringComparison.InvariantCultureIgnoreCase) == -1)
            {
                throw new InputFormatException("Incorrect direction");
            }

            var roverMovement = fileContent[lineNo + 1].ToCharArray();
            var roverAllowedMovement = "LRM";

            // If there's any character doesn't match the allowed command, throws exception
            var notAllowedCharacters =
                roverMovement.Where(
                    x => roverAllowedMovement.IndexOf(
                        x.ToString(CultureInfo.InvariantCulture), StringComparison.InvariantCultureIgnoreCase) == -1).ToList();
            if (notAllowedCharacters.Count > 0)
            {
                throw new InputFormatException("Incorrect movement command");
            }
        }

        /// <summary>
        /// Ensure rover information provided in the input file is correct
        /// </summary>
        /// <param name="fileContent"></param>
        private void ValidatePlateauInformation(List<string> fileContent)
        {
            if ((fileContent.Count % 2 == 0) || (fileContent.Count <= 1))
            {
                throw new InputFormatException("Wrong input file");
            }
            var plateauCoordinate = fileContent[0].Split(' ');
            if (plateauCoordinate.Count() != 2)
            {
                throw new InputFormatException("Incorrect plateau coordinates");
            }

            int xCordinate;
            if (!int.TryParse(plateauCoordinate[0], out xCordinate))
            {
                throw new InputFormatException("Incorrect plateau x coordinate");
            }

            int yCordinate;
            if (!int.TryParse(plateauCoordinate[1], out yCordinate))
            {
                throw new InputFormatException("Incorrect plateau y coordinate");
            }

            if ((xCordinate < 0) || (yCordinate < 0))
            {
                throw new InputFormatException("Incorrect plateau coordinates");
            }
        }
    }
}
