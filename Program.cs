using System;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("user32.dll")]
    private static extern void SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool LockWorkStation();

    private const uint WM_SYSCOMMAND = 0x0112;
    private const uint SC_SCREENSAVE = 0xF140;

    static void Main(string[] args)
    {
        // 鎖定螢幕
        LockWorkStation();
        
        // 執行螢幕保護程式
        SendMessage(GetConsoleWindow(), WM_SYSCOMMAND, (IntPtr)SC_SCREENSAVE, IntPtr.Zero);
    }

    [DllImport("kernel32.dll")]
    private static extern IntPtr GetConsoleWindow();
}