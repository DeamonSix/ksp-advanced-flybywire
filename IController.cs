﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPAdvancedFlyByWire
{

    public abstract class IController
    {

        public delegate void ButtonPressedCallback(int button, FlightCtrlState state);
        public delegate void ButtonReleasedCallback(int button, FlightCtrlState state);

        public ButtonPressedCallback buttonPressedCallback = null;
        public ButtonReleasedCallback buttonReleasedCallback = null;

        public Curve analogInputEvaluationCurve = new Curve();

        public abstract void Update(FlightCtrlState state);

        public abstract int GetButtonsCount();

        public abstract string GetButtonName(int id);

        public abstract int GetAxesCount();

        public abstract string GetAxisName(int id);

        public abstract bool GetButtonState(int button);

        public abstract float GetAnalogInputState(int analogInput);

        public int GetButtonsMask()
        {
            int mask = 0;

            for (int i = 0; i < 15; i++)
            {
                if (GetButtonState(i))
                {
                    mask |= 1 << i;
                }
            }

            return mask;
        }

    }

}
