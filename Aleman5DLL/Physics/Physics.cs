﻿using UnityEngine;

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
        /// Returns the next position based on the speed using MRU
        /// </summary>
        /// <param name="speed">Actual speed of the element</param>
        /// <param name="dir">Direction to move the element</param>
        /// <returns>Next position of the element</returns>
        public static Vector3 NextPositionMRU(float speed, Vector3 dir)
        {
            dir *= speed * Time.deltaTime;

            return dir;
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

        public static Vector3 MCU(float angle, float radio)
        {
            Vector3 newPos = radio * Mathf.Cos(angle) * Vector3.right + radio * Mathf.Sin(angle) * Vector3.up;

            return newPos;
        }

        public static float CalculateAngularVelocity(float angleI, float angleF, float timeI, float timeF)
        {
            float angle = angleI - angleF;
            float time = timeI - timeF;
            return angle / time;
        }

        public static void ConstAccelCirc2D(float radius, float acceleration, ref float initialAngularSpeed, float minSpeed, float maxSpeed)
        {
            float currentAngularSpeed = 0f;

            currentAngularSpeed = acceleration * Time.deltaTime + initialAngularSpeed;

            currentAngularSpeed = Mathf.Clamp(currentAngularSpeed, minSpeed, maxSpeed);

            initialAngularSpeed = currentAngularSpeed;
        }
    }
}
