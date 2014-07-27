using SSF2Xbox360Controller.XInput;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSF2Xbox360Controller
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        static void Main(string[] args)
        {
            var controller = XboxController.RetrieveController(0);

            IntPtr handle;
            handle = FindWindow(null, "Adobe Flash Player 11");

            if (handle == IntPtr.Zero)
            {
                MessageBox.Show("Window not found.");
                return;
            }

            var A = new Binding(Keys.P, handle);
            var B = new Binding(Keys.O, handle);
            var Up = new Binding(Keys.W, handle);
            var Left = new Binding(Keys.A, handle);
            var Right = new Binding(Keys.D, handle);
            var Down = new Binding(Keys.S, handle);
            var I = new Binding(Keys.I, handle);
            var U = new Binding(Keys.U, handle);

            SetForegroundWindow(handle);
            XboxController.StartPolling();
            while(true)
            {
                // ------------------ A ------------------
                A.Update(controller.IsAPressed);

                // ------------------ B ------------------
                B.Update(controller.IsBPressed);

                // ------------------ Up ------------------
                Up.Update(controller.IsDPadUpPressed);

                // ------------------ Left ------------------
                Left.Update(controller.IsDPadLeftPressed);

                // ------------------ Right ------------------
                Right.Update(controller.IsDPadRightPressed);

                // ------------------ Down ------------------
                Down.Update(controller.IsDPadDownPressed);

                // ------------------ Down ------------------
                I.Update(controller.IsRightShoulderPressed || controller.IsLeftShoulderPressed);

                // ------------------ Down ------------------
                U.Update(controller.IsXPressed);
            }
            XboxController.StopPolling();
        }

    }
}
