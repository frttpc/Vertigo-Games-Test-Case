using UnityEngine;

namespace Frttpc.Statics
{
    public static class Extensions
    {
        public static Vector3 XYtoXZ(this Vector2 vec) => new (vec.x, 0, vec.y);

        public static Vector3 RoundToInt(this Vector3 vec) => new (Mathf.RoundToInt(vec.x), Mathf.RoundToInt(vec.y), Mathf.RoundToInt(vec.z));

        public static Vector3 GetBiggestDir(this Vector3 vec)
        {
            Debug.Log(vec);

            Vector3 returnVec;

            if(Mathf.Abs(vec.x) > Mathf.Abs(vec.y))
            {
                if(Mathf.Abs(vec.x) > Mathf.Abs(vec.z))
                {
                    returnVec = Vector3.right * Mathf.Sign(vec.x);
                }
                else
                {
                    returnVec = Vector3.forward * Mathf.Sign(vec.z);
                }
            }
            else if(Mathf.Abs(vec.z) > Mathf.Abs(vec.y))
            {
                returnVec = Vector3.forward * Mathf.Sign(vec.z);
            }
            else
            {
                returnVec = Vector3.up * Mathf.Sign(vec.y);
            }

            Debug.Log(returnVec);

            return returnVec;
        }
    }
}
