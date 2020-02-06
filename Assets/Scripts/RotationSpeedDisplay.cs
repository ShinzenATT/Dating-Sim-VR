using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Text))]
    class RotationSpeedDisplay : MonoBehaviour
    {
        const string Display = "X: {0} \nY: {1} \nZ: {2} \nShake: {3}\nNod: {4}\nDiagonal Shake: {5}";
        private Text m_text;
        private CameraNodAndShakeDetect Detect;
        private int FrameCount = 0;

        void Start()
        {

            Detect = InstanceVariables.NodAndShakeDetectComponent;
            m_text = GetComponent<Text>();
        }

        void Update()
        {
            if (FrameCount++ % 5 == 0)
            {
                FrameCount %= 5;
                float[] AxisSpeeds = Detect.RotationSpeedXYZ;
                m_text.text = string.Format(Display, AxisSpeeds[0].ToString("#0.0##"), AxisSpeeds[1].ToString("#0.0##"), 
                    AxisSpeeds[2].ToString("#0.0##"), Detect.IsShaking, Detect.IsNodding, Detect.IsTiltShaking);
            }
        }
    }
}
