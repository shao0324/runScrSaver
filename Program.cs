using System;
using System.Runtime.InteropServices;

class Program
{
    private const uint WM_SYSCOMMAND = 0x0112;
    private const uint SC_SCREENSAVE = 0xF140;

    static void Main(string[] args)
    {
        // 執行螢幕保護程式
        SendMessage(GetConsoleWindow(), WM_SYSCOMMAND, (IntPtr)SC_SCREENSAVE, IntPtr.Zero);
    }

    [DllImport("kernel32.dll")]
    private static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
}