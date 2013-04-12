namespace MarsRover.Directions
{
    public class DirectionFactory
    {
        /// <summary>
        /// Good place for IoC
        /// </summary>
        /// <returns></returns>
        public Direction InitializeAllCardinalPoints()
        {
            var north = new North { Name = "N" };
            var south = new South { Name = "S" };
            var west = new West { Name = "W" };
            var east = new East { Name = "E" };

            north.Left = west;
            north.Right = east;

            south.Left = east;
            south.Right = west;

            return north;
        }

        /// <summary>
        /// Recursive until getting the expected direction
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="directionCharacter"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public Direction GetDirection(Direction direction, string directionCharacter, int count = 0)
        {
            if (count == 4) return null;

            if (direction.Name == directionCharacter)
            {
                return direction;
            }
            else
            {
                return this.GetDirection(direction.Left, directionCharacter, count + 1);
            }
        }
    }
}
