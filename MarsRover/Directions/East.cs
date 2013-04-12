namespace MarsRover.Directions
{
    /// <summary>
    /// The east direction
    /// </summary>
    public class East : Direction
    {
        public override Coodinate MoveForward(Coodinate location)
        {
            location.X += 1;
            return location;
        }
    }
}
