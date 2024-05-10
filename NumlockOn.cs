using System;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace NumlockOn
{
    internal static class Program
    {
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        const int KEYEVENTF_EXTENDEDKEY = 0x1;
        const int KEYEVENTF_KEYUP = 0x2;
        const int NUMLOCK = 0x90;

        [STAThread]
        static void Main()
        {
            if (!Keyboard.IsKeyToggled(Key.NumLock))
            {
                keybd_event(NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                keybd_event(NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
            }
        }
    }
}
