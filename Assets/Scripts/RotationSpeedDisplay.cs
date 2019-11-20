using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Text))]
    class RotationSpeedDisplay : MonoBehaviour
    {
        public Camera TargetCamera;
        const string Display = "X: {0} \nY: {1} \nZ: {2}";
        private Text m_text;
        private CameraNodAndShakeDetect Detect;

        void Start()
        {
            Detect = TargetCamera.GetComponent<CameraNodAndShakeDetect>();
            m_text = GetComponent<Text>();
        }

        void Update()
        {
            float[] AxisSpeeds = Detect.GetAxisSpeeds();
            m_text.text = string.Format(Display, AxisSpeeds[0], AxisSpeeds[1], AxisSpeeds[2]);
        }
    }
}
