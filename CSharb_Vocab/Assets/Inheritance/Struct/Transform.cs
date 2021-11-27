namespace Majin.Main
{
    public sealed class Transform
    {
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Scale;

        public Transform()
        {
            Position = Vector3.Zero;
            Rotation = Vector3.Zero;
            Scale = Vector3.One;
        }
    }


    public struct Vector3
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3(float x = 0, float y = 0, float z = 0)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Vector3 Zero { get { return new Vector3(); } }
        public static Vector3 One { get { return new Vector3(); } }

    }
}

