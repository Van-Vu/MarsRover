namespace MarsRover.Directions
{
    public abstract class Direction
    {
        public string Name;

        private Direction left;
        public Direction Left
        {
            get
            {
                return this.left;
            }
            set
            {
                this.left = value;
                if (value.Right == null) value.Right = this;
            }
        }

        private Direction right;
        public Direction Right
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
                if (value.Left == null) value.Left = this;
            }
        }

        public Direction TurnLeft()
        {
            return Left;
        }

        public Direction TurnRight()
        {
            return Right;
        }

        public abstract Coodinate MoveForward(Coodinate location);
    }
}
