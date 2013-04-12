using MarsRover.Directions;

namespace MarsRover
{
    public class Rover
    {
        public Direction CurrentDirection { get; set; }

        public Coodinate CurrentLocation { get; set; }

        public void TurnLeft()
        {
            CurrentDirection = CurrentDirection.TurnLeft();
        }

        public void TurnRight()
        {
            CurrentDirection = CurrentDirection.TurnRight();
        }

        public void MoveForward()
        {
            CurrentLocation = CurrentDirection.MoveForward(CurrentLocation);
        }

        /// <summary>
        /// Ensure the rover's location doesn't fall out of the plateau
        /// </summary>
        /// <param name="plateauCoordinate"></param>
        public void ValidateLocation(Coodinate plateauCoordinate)
        {
            if ((plateauCoordinate.X < CurrentLocation.X) || (CurrentLocation.X < 0)
                || (plateauCoordinate.Y < CurrentLocation.Y) || (plateauCoordinate.Y < 0))
            {
                throw new RoverLocationException("Rover location is out of the plateau");
            }
        }
    }
}
