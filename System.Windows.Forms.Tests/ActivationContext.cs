// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.InteropServices;
using static Interop.Kernel32;

namespace System.Windows.Forms.Tests
{
    /// <remarks>
    /// Code from http://www.atalasoft.com/blogs/spikemclarty/february-2012/dynamically-testing-an-activex-control-from-c-and
    /// </remarks>
    public class ActivationContext
    {
        public unsafe static void UsingManifestDo(string manifest, Action action)
        {
            fixed (char* lpSource = manifest)
            {
                var context = new ACTCTXW
                {
                    cbSize = (uint)sizeof(ACTCTXW),
                    lpSource = lpSource
                };

                IntPtr hActCtx = CreateActCtxW(ref context);
                if (hActCtx == (IntPtr)(-1))
                {
                    throw Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error());
                }

                try
                {
                    IntPtr cookie = IntPtr.Zero;
                    if (ActivateActCtx(hActCtx, out cookie).IsFalse())
                    {
                        throw Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error());
                    }
                    try
                    {
                        action();
                    }
                    finally
                    {
                        DeactivateActCtx(0, cookie);
                    }
                }
                finally
                {
                    ReleaseActCtx(hActCtx);
                }
            }
        }
    }
}
