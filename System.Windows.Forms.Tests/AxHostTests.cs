// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.InteropServices;
using ComClass;
using Xunit;

namespace System.Windows.Forms.Tests
{
    public class AxHostTests
    {
        [WinFormsFact]
        public void AxHost_HasPropertyPages_InvokeWithHandleISpecifyPropertyPagesWithItems_ReturnsExpected()
        {
            ActivationContext.UsingManifestDo("app.manifest", () =>
            {
                var control = new SubAxHost(typeof(SpecifyPropertyPagesWithItemsClass).GUID.ToString());
                Assert.NotEqual(IntPtr.Zero, control.Handle);
                int invalidatedCallCount = 0;
                control.Invalidated += (sender, e) => invalidatedCallCount++;
                int styleChangedCallCount = 0;
                control.StyleChanged += (sender, e) => styleChangedCallCount++;
                int createdCallCount = 0;
                control.HandleCreated += (sender, e) => createdCallCount++;

                Assert.False(control.HasPropertyPages());
            });
        }

        [WinFormsFact]
        public void AxHost_Handle_Get_Success()
        {
            ActivationContext.UsingManifestDo("app.manifest", () =>
            {
                var control = new SubAxHost(typeof(Server).GUID.ToString());
                Assert.NotEqual(IntPtr.Zero, control.Handle);
                int invalidatedCallCount = 0;
                control.Invalidated += (sender, e) => invalidatedCallCount++;
                int styleChangedCallCount = 0;
                control.StyleChanged += (sender, e) => styleChangedCallCount++;
                int createdCallCount = 0;
                control.HandleCreated += (sender, e) => createdCallCount++;
            });
        }

        [WinFormsFact]
        public void AxHost_Handle_GetEmptyClass_ThrowsCOMException()
        {
            using var control = new SubAxHost(Guid.Empty.ToString());
            Assert.Throws<COMException>(() => control.Handle);
        }

        [WinFormsFact]
        public void AxHost_Handle_GetNotIOleObject_ThrowsInvalidCastException()
        {
            ActivationContext.UsingManifestDo("app.manifest", () =>
            {
                var control = new SubAxHost(typeof(NotIOleObjectClass).GUID.ToString());
                Assert.Throws<InvalidCastException>(() => control.Handle);
                Assert.NotNull(control.GetOcx());
            });
        }

        private class SubAxHost : AxHost
        {
            public SubAxHost(string clsidString) : base(clsidString)
            {
            }

            public SubAxHost(string clsidString, int flags) : base(clsidString, flags)
            {
            }
        }
    }
}
