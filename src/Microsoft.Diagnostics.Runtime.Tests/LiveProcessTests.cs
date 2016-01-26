using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Diagnostics.Runtime.Tests
{
    [TestClass]
    public class LiveProcessTests
    {
        [TestMethod]
        public void AttachToProcessTest()
        {
            using (var process = TestTargets.LiveProcess.RunProcess())
            using (DataTarget dt = process.Attach(AttachFlag.Passive))
            {
                Assert.IsFalse(dt.IsMinidump);
            }

            using (var process = TestTargets.LiveProcess.RunProcess())
            using (DataTarget dt = process.Attach(AttachFlag.NonInvasive))
            {
                Assert.IsFalse(dt.IsMinidump);
                Assert.IsNotNull(dt.DebuggerInterface);
            }

            using (var process = TestTargets.LiveProcess.RunProcess())
            using (DataTarget dt = process.Attach(AttachFlag.Invasive))
            {
                Assert.IsFalse(dt.IsMinidump);
                Assert.IsNotNull(dt.DebuggerInterface);
            }
        }
    }
}
