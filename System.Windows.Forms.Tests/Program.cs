// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.InteropServices;
using ComClass;
using Xunit;
using static Interop;
using static Interop.Ole32;

namespace System.Windows.Forms.Tests
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                var o = Activator.CreateInstance(Type.GetTypeFromCLSID(typeof(Server).GUID));
                Console.WriteLine(o.GetType());

                Guid clsid = typeof(Server).GUID;
                Guid iid = new Guid("{00000000-0000-0000-C000-000000000046}");
                HRESULT hr = CoCreateInstance(
                    ref clsid,
                    IntPtr.Zero,
                    Ole32.CLSCTX.INPROC_SERVER,
                    ref iid,
                    out object res);
                Console.WriteLine(res.GetType());

                var control = new SubAxHost(typeof(Server).GUID.ToString());
                Assert.NotEqual(IntPtr.Zero, control.Handle);
                int invalidatedCallCount = 0;
                control.Invalidated += (sender, e) => invalidatedCallCount++;
                int styleChangedCallCount = 0;
                control.StyleChanged += (sender, e) => styleChangedCallCount++;
                int createdCallCount = 0;
                control.HandleCreated += (sender, e) => createdCallCount++;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("Please Love Me");
        }

        private class SubAxHost : AxHost
        {
            public SubAxHost(string clsidString) : base(clsidString)
            {
            }
        }
    }

    // The following classes are typically defined in a PIA, but for this example
    // are being defined here to simplify the scenario.
    namespace Activation
    {
        /// <summary>
        /// Managed definition of CoClass
        /// </summary>
        [ComImport]
        [CoClass(typeof(ServerClass))]
        [Guid("55c37656-d2d4-4fa0-9b5f-d2b2fb57b325")] // By TlbImp convention, set this to the GUID of the parent interface
        internal interface Server : IServer
        {
        }

        /// <summary>
        /// Managed activation for CoClass
        /// </summary>
        [ComImport]
        [Guid("0c0af4a2-d038-4b82-b2c9-ded4d9435659")]
        internal class ServerClass
        {
        }
    }
}
