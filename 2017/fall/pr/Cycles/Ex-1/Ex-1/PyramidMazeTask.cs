namespace Mazes
{
	public static class PyramidMazeTask
	{
        public static void MoveOut(Robot robot, int width, int height)
        {
            do
            {
                MoveToPoint(robot, width - 3, Direction.Right);
                width -= 2;

                MoveToPoint(robot, 2, Direction.Up);

                MoveToPoint(robot, width - 3, Direction.Left);
                width -= 2;

                if (!robot.Finished)
                    MoveToPoint(robot, 2, Direction.Up);
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