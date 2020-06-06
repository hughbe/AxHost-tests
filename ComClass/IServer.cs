using System;
using System.Runtime.InteropServices;

namespace ComClass
{
    [ComVisible(true)]
    [Guid("55c37656-d2d4-4fa0-9b5f-d2b2fb57b325")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IServer
    {
        /// <summary>
        /// Compute the value of the constant Pi.
        /// </summary>
        double ComputePi();
    }
}
