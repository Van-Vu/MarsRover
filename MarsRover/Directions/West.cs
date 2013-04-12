namespace MarsRover.Directions
{
    /// <summary>
    /// The west direction
    /// </summary>
    public class West : Direction
    {
        public override Coodinate MoveForward(Coodinate location)
        {
            location.X -= 1;
            return location;
        }
    }
}
