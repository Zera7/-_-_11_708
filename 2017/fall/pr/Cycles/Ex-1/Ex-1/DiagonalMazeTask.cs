namespace Mazes
{
	public static class DiagonalMazeTask
	{
        public static void MoveOut(Robot robot, int width, int height)
        {
            int buffer = width;
            width = (width - 3) / (height - 3);
            height = (height - 3) / (buffer - 3);
            if (width == 0) width = 1;
            if (height == 0) height = 1;
            DiagonalMove(robot, width, height);
        }

        public static void DiagonalMove(Robot robot, int width, int height) {
            do
            {
                if (width > height)
                {
                    MoveToPoint(robot, width, Direction.Right);
                    if (!robot.Finished) MoveToPoint(robot, height, Direction.Down);
                }
                else
                {
                    MoveToPoint(robot, height, Direction.Down);
                    if (!robot.Finished) MoveToPoint(robot, width, Direction.Right);
                }
            } while (!robot.Finished);
        } 

        public static void MoveToPoint(Robot robot, int length, Direction direction)
        {
            for (int i = 0; i < length; i++)
            {
                robot.MoveTo(direction);
            }
        }
    }
}