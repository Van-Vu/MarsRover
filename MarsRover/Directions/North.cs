namespace MarsRover.Directions
{
    /// <summary>
    /// The north direction
    /// </summary>
    public class North : Direction
    {
        public override Coodinate MoveForward(Coodinate location)
        {
            location.Y += 1;
            return location;
        }
    }
}
