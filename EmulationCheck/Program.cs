using System.Diagnostics;
using System.Runtime.InteropServices;

[DllImport("kernel32.dll", SetLastError = true)]
static extern bool IsWow64Process2(
    IntPtr processHandle,
    out ushort processMachine,
    out ushort nativeMachine
);

if (!IsWow64Process2(Process.GetCurrentProcess().Handle, out ushort processMachine, out ushort nativeMachine))
    throw new System.ComponentModel.Win32Exception();

if (processMachine == (ushort)Architecture.Unknown)
{
    Console.WriteLine($"64 Bit on {(Architecture)nativeMachine}");
}
else
{
    Console.WriteLine($"32-bit (WOW64) on {(Architecture)nativeMachine}");
}