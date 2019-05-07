using UnityEngine;

namespace Aleman5DLL
{
    public static class Physics
    {
        /// <summary>
        /// Value of the gravity. Actually using 9,81
        /// </summary>
        public const float gravity = 9.81f;

        /// <summary>
        /// Returns the next position based on the speed using MRU
        /// </summary>
        /// <param name="speed">Actual speed of the element</param>
        /// <returns>Next position of the element</returns>
        public static float NextPositionMRU(float speed)
        {
            float newPos = speed * Time.deltaTime;

            return newPos;
        }

        /// <summary>
        /// Returns the next position based on the speed using MRUV
        /// </summary>
        /// <param name="speed">Actual speed of the element</param>
        /// <param name="acceleration">Actual acceleration of the element</param>
        /// <param name="timePassed">Actual time passed from the creation of the element</param>
        /// <returns>Next position of the element</returns>
        public static float NextPositionMRUV(float speed, float acceleration, float timePassed)
        {
            float newPos = speed * Time.deltaTime + 0.5f * acceleration * Mathf.Pow(timePassed, 2.0f) * Time.deltaTime;

            return newPos;
        }

        /// <summary>
        /// Returns the next position based on the speed using Oblique Shot
        /// </summary>
        /// <param name="speed">Actual speed of the element</param>
        /// <param name="timePassed">Actual time passed from the creation of the element</param>
        /// <returns>Next position of the element</returns>
        public static float NextPositionObliqueShot(float speed, float timePassed)
        {
            float newPos = speed * Time.deltaTime - 0.5f * gravity * Mathf.Pow(timePassed, 2.0f) * Time.deltaTime;

            return newPos;
        }

        public static Vector3 MCU(Vector3 pos, float angle, float radio)
        {
            Vector3 a = pos.x * Vector3.right + pos.y * Vector3.up;


            // r→= x⋅i→+y⋅j→= R⋅cos(φ)⋅i→+R⋅sin(φ)⋅j→

            return a;
        }
    }
}
