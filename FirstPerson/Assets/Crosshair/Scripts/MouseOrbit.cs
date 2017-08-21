﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Crosshair.Scripts
{
    public class MouseOrbit : MonoBehaviour
    {

        [SerializeField]
        Vector3 cameraOffset;
        [SerializeField]
        float damping;

        public Transform target;
        public float distance = 5.0f;
        public float xSpeed = 120.0f;
        public float ySpeed = 120.0f;

        public float yMinLimit = -20f;
        public float yMaxLimit = 80f;

        public float distanceMin = .5f;
        public float distanceMax = 15f;

        float x = 0.0f;
        float y = 0.0f;


        void Start()
        {
            Vector3 angles = transform.eulerAngles;
            x = angles.y;
            y = angles.x;
        }

        public void Update()
        {

            x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            //Vector3 position = rotation * negDistance + target.position;

            //transform.rotation = rotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, damping * Time.deltaTime);

            //transform.position = position;
        }

        public static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360)
                angle += 360f;
            if (angle > 360)
                angle -= 360f;
            return Mathf.Clamp(angle, min, max);
        }
    }
}
