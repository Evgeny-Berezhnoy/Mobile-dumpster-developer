using UnityEngine;

namespace ExtensionCompilation
{
    public static class Vectors
    {

        #region Methods

        public static Vector3 TrimX(this Vector3 vector)
        {

            return new Vector3(vector.x, 0);

        }

        public static Vector2 TrimX(this Vector2 vector)
        {

            return new Vector2(vector.x, 0);

        }

        public static Vector3 TrimY(this Vector3 vector)
        {

            return new Vector3(0, vector.y);

        }

        public static Vector2 TrimY(this Vector2 vector)
        {

            return new Vector2(0, vector.y);

        }

        public static Vector3 TrimZ(this Vector3 vector)
        {

            return new Vector3(0, 0, vector.z);

        }

        public static Vector3 TrimXY(this Vector3 vector)
        {

            return new Vector3(vector.x, vector.y);

        }

        public static Vector3 TrimXZ(this Vector3 vector)
        {

            return new Vector3(vector.x, 0, vector.z);

        }

        public static Vector3 TrimYZ(this Vector3 vector)
        {

            return new Vector3(0, vector.y, vector.z);

        }

        public static Vector3 Change(this Vector3 vector, float? x = null, float? y = null, float? z = null)
        {

            return
                new Vector3(
                    x == null ? vector.x : (float) x, 
                    y == null ? vector.y : (float) y,
                    z == null ? vector.z : (float) z);

        }

        public static Vector2 Change(this Vector2 vector, float? x = null, float? y = null)
        {

            return
                new Vector2(
                    x == null ? vector.x : (float)x,
                    y == null ? vector.y : (float)y);

        }

        #endregion

    }

}
