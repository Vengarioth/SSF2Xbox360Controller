﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SSF2Xbox360Controller.XInput
{
    [StructLayout(LayoutKind.Explicit)]
    public struct  XInputBatteryInformation
    {
        [MarshalAs(UnmanagedType.I1)]
        [FieldOffset(0)]
        public byte BatteryType;

        [MarshalAs(UnmanagedType.I1)]
        [FieldOffset(1)]
        public byte BatteryLevel;

        public override string ToString()
        {
            return string.Format("{0} {1}", (BatteryTypes)BatteryType, (BatteryLevel)BatteryLevel);
        }
    }
}
