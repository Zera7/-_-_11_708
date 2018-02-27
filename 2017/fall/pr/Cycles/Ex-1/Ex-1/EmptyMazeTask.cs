namespace Mazes
{
    public static class EmptyMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            MoveToPoint(robot, width - 3, Direction.Right);
            MoveToPoint(robot, height - 3, Direction.Down);
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