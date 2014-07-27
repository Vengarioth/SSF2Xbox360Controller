using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SSF2Xbox360Controller
{
    class Binding
    {
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;

        [DllImport("user32", EntryPoint = "PostMessage")]
        public static extern int PostMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private Keys targetKey;
        private bool state = false; 
        private IntPtr handle;

        public Binding(Keys targetKey, IntPtr handle)
        {
            this.targetKey = targetKey;
            this.handle = handle;
        }

        public void Update(bool newState)
        {
            if (newState && !state)
            {
                state = true;
                PostMessage(handle, WM_KEYDOWN, (int)targetKey, 0);
            }
            if (!newState && state)
            {
                state = false;
                PostMessage(handle, WM_KEYUP, (int)targetKey, 0);
            }
        }
    }
}
