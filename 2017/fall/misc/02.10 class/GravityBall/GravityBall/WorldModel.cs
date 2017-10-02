using System;

namespace GravityBalls
{
	public class WorldModel
	{
		public double BallX;
		public double BallY;
		public double BallRadius;
		public double WorldWidth;
		public double WorldHeight;
        public const int WorldGravity = 20;
        public const double WorldResistance = 0.000;
        public const double MaxRepulsionCursorPower = 3;
        public double BallXSpeed = 1000;
        public double BallYSpeed = 1000;

        public int PositionCursorX = 0;
        public int PositionCursorY = 0;



        public void SimulateTimeframe(double dt)
		{
            IntersectionsBall(dt);
            RepulsionBall();
            SetNewSpeedBall();
        }

        private void IntersectionsBall(double dt) {
            if (BallYSpeed > 0)
                BallY = Math.Min(BallY + (WorldGravity + BallYSpeed) * dt, WorldHeight - BallRadius);
            else
                BallY = Math.Max(BallY + (WorldGravity + BallYSpeed) * dt, BallRadius);

            if (BallXSpeed > 0)
                BallX = Math.Min(BallX + BallXSpeed * dt, WorldWidth - BallRadius);
            else
                BallX = Math.Max(BallX + BallXSpeed * dt, BallRadius);
        }

        private void RepulsionBall() {
            if (BallY + BallRadius == WorldHeight && BallYSpeed > 0) BallYSpeed = -BallYSpeed;
            if (BallY - BallRadius == 0 && BallYSpeed < 0) BallYSpeed = -BallYSpeed;

            if (BallX + BallRadius == WorldWidth && BallXSpeed > 0) BallXSpeed = -BallXSpeed;
            if (BallX - BallRadius == 0 && BallXSpeed < 0) BallXSpeed = -BallXSpeed;
        }

        private void SetNewSpeedBall() {
            BallYSpeed *= 1 - WorldResistance;
            BallXSpeed *= 1 - WorldResistance;

            BallYSpeed += WorldGravity;

            int distanceX = PositionCursorX - (int)(BallX);
            int distanceY = PositionCursorY - (int)(BallY);

            int distance = (int)(Math.Sqrt((distanceX * distanceX + distanceY * distanceY)));
            if (distance != 0)
            {
                if (BallY < PositionCursorY)
                    BallYSpeed -= WorldHeight / distance * MaxRepulsionCursorPower;
                else
                    BallYSpeed += WorldHeight / distance * MaxRepulsionCursorPower;

                if (BallX < PositionCursorX)
                    BallXSpeed -= WorldWidth / distance * MaxRepulsionCursorPower;
                else
                    BallXSpeed += WorldWidth / distance * MaxRepulsionCursorPower;
            }
        }
	}
}

