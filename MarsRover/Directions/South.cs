namespace MarsRover.Directions
{
    /// <summary>
    /// The south direction
    /// </summary>
    public class South : Direction
    {
        public override Coodinate MoveForward(Coodinate location)
        {
            location.Y -= 1;
            return location;
        }
    }
}
