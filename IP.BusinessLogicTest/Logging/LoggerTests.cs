using Microsoft.VisualStudio.TestTools.UnitTesting;
using IP.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IP.BusinessLogic.Context;
using Moq;
using IP.BusinessLogic.Logging;

namespace IP.Logging.Tests
{
    [TestClass()]
    public class LoggerTests
    {

        #region Variables

        private IUserContext _userContext;
        private IApplicationContext _applicationContext;
        
        #endregion

        //Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void SetupInitialize()
        {

            _userContext = new Mock<IUserContext>().Object;
            _applicationContext = new Mock<IApplicationContext>().Object;

            
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }


        [TestMethod()]
        public void LogExceptionTest()
        {
            Logger log = new Logger(_userContext, _applicationContext);
            log.LogException("test", new Exception("test"));


            //BasicLogger Basiclog = new BasicLogger(_userContext, _applicationContext);
            //Basiclog.LogException("test", new Exception("test"));
            Assert.IsTrue(true);
        }
    }
}