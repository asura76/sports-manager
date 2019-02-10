using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using YellowProject;

namespace YellowTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void HVAC_Test()
        {
            int id = 123456;
            Temperature_Controller test_cont = new Temperature_Controller(id);

            Assert.AreEqual(id, test_cont.getUserID());
        }

    }
}
