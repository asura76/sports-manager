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


        [TestMethod]
        public void changeTemp()
        {
            int id = 123456;
            int temp = 30;
            char tempType = 'c';
            Temperature_Controller test_temp = new Temperature_Controller(id);
            test_temp.changeTemp(32, 'f');
            Assert.AreEqual(test_temp.CurrentTemp_, 89.6);
            Assert.AreEqual(test_temp.PrefConv_, 'F');
        }
    }
}
