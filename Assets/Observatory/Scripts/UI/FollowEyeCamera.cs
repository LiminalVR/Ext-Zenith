using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Liminal.Platform.UI.Behaviours
{
    public class FollowEyeCamera : MonoBehaviour
    {
        private float mTimeoutRemaining;
        private bool mCameraOutOfRange;
        private float mAngleThresholdCurrent;
        private float mAngleThresholdTarget;

        private Vector3 mRotationTarget;
        private Vector3 mRotationCurrent;
        private Vector3 mRotationVelocity;

        [Tooltip("The camera to follow. If no value is supplied, the camera assigned to Camera.main will be used.")]
        [SerializeField]
        private Camera m_Camera = null;
        [Tooltip("Determines if the object should align directly to the camera when enabled. This will have the object appear in fron the camera on enable, rather than in its current position.")]
        [SerializeField]
        private bool m_AlignOnEnable = true;
        [SerializeField]
        private bool m_KeepHeight = true;
        [Tooltip("The distance the object should be from the camera, in world space.")]
        [SerializeField]
        private float m_Distance = 5f;
        [Tooltip("The angle threshold between the camera and the object around the Y axis after which the object will begin to follow the camera. Inside of this angle, the object will not follow the camera.")]
        [SerializeField]
        private float m_AngleThreshold = 5f;
        [Tooltip("The duration the object must be outside the angle threshold before it will begin moving.")]
        [SerializeField]
        private float m_Timeout = 0.5f;
        [Tooltip("The desired time the object will take to reach the camera.")]
        [SerializeField]
        private float m_SmoothTime = 1.5f;

        #region Properties

        public Camera Camera
        {
            get
            {
                if (m_Camera == null)
                {
                    m_Camera = Camera.main;
                }

                return m_Camera;
            }

            set
            {
                m_Camera = value;
            }
        }

        #endregion

        #region MonoBehaviour

        private void OnEnable()
        {
            if (m_Camera == null)
            {
                m_Camera = Camera.main;
            }

            if (m_AlignOnEnable)
            {
                AlignToCameraImmediately();
            }
            else
            {
                mRotationTarget = CameraForwardXZ();
                mRotationCurrent = DirToCameraXZ();
                mRotationVelocity = Vector3.zero;

                mCameraOutOfRange = false;
                mTimeoutRemaining = m_Timeout;
                mAngleThresholdCurrent =
                mAngleThresholdTarget = m_AngleThreshold;
            }
        }

        private void LateUpdate()
        {
            var camForward = CameraForwardXZ();
            var dirToCam = DirToCameraXZ();

            if (mCameraOutOfRange)
            {
                mRotationTarget = camForward * m_Distance;
            }

            var dot = Vector3.Dot(camForward, dirToCam);
            var acos = Mathf.Acos(dot) * Mathf.Rad2Deg;
            if (acos > mAngleThresholdCurrent)
            {
                // Angle to target is outside of threshold 
                // Countdown timeout until out-of-range state is triggered
                mTimeoutRemaining -= Time.unscaledDeltaTime;
                if (mTimeoutRemaining <= 0)
                {
                    mCameraOutOfRange = true;
                }
            }
            else
            {
                // Back in range, reset timeout and out-of-range state
                mTimeoutRemaining = m_Timeout;
                mCameraOutOfRange = false;
            }

            // Smooth rotation toward target
            mRotationCurrent = Vector3.SmoothDamp(mRotationCurrent, mRotationTarget, ref mRotationVelocity, m_SmoothTime, float.MaxValue, Time.smoothDeltaTime);
            mRotationCurrent.Normalize();
            UpdateTransform();

            // Lerp angle threshold up towards target
            mAngleThresholdCurrent = Mathf.Lerp(mAngleThresholdCurrent, mAngleThresholdTarget, Time.unscaledDeltaTime * 6f);
            if (Mathf.Approximately(mAngleThresholdCurrent, mAngleThresholdTarget))
                mAngleThresholdCurrent = mAngleThresholdTarget;
        }

        private void OnValidate()
        {
            m_AngleThreshold = Mathf.Max(m_AngleThreshold, 0);
            m_Timeout = Mathf.Max(m_Timeout, 0);
            m_SmoothTime = Mathf.Max(m_SmoothTime, 0);

            mAngleThresholdCurrent =
            mAngleThresholdTarget = m_AngleThreshold;
        }

        #endregion

        private void UpdateTransform()
        {
            if (Camera != null)
            {
                var pos = Camera.transform.position + (mRotationCurrent * m_Distance);

                if (m_KeepHeight)
                {
                    pos.y = transform.position.y;
                }

                transform.position = pos;
                transform.rotation = Quaternion.LookRotation(mRotationCurrent);
            }
        }

        private void AlignToCameraImmediately()
        {
            mRotationTarget =
            mRotationCurrent = CameraForwardXZ();
            mRotationVelocity = Vector3.zero;

            mCameraOutOfRange = true;   // Start out of range incase the user is actively turning their head
            mTimeoutRemaining = 0;
            mAngleThresholdCurrent = 0;
            mAngleThresholdTarget = m_AngleThreshold;

            UpdateTransform();
        }

        private Vector3 CameraForwardXZ()
        {
            if (Camera == null)
            {
                return Vector3.zero;
            }

            var dir = Camera.transform.forward;
            dir.y = 0;
            dir.Normalize();

            return dir;
        }

        private Vector3 DirToCameraXZ()
        {
            if (Camera == null)
            {
                return Vector3.zero;
            }

            var dir = (transform.position - Camera.transform.position);
            dir.y = 0;
            dir.Normalize();

            return dir;
        }
    }
}