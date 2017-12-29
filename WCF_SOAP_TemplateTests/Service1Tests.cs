using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCF_SOAP_Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_SOAP_Template.Tests
{
    [TestClass()]
    public class Service1Tests
    {
        [TestMethod()]
        public void VisListenTest()
        {
            //Act
            Service1 service = new Service1();
            //Arrange
            List<ChangeClassName> tempList = service.VisListen();
            //Assert
            Assert.AreNotEqual(0, tempList.Count);
        }

        [TestMethod()]
        public void IndsætObjektTest()
        {
            //Act
            Service1 service = new Service1();
            //Arrange
            List<ChangeClassName> theList = service.VisListen();
            int firstCount = theList.Count;

            service.IndsætObjekt(new ChangeClassName(1, "testNavn", "testEfternavn", 200, 10, DateTime.Now));

            theList = service.VisListen();
            int secondCount = theList.Count;
            //Assert
            Assert.AreNotEqual(firstCount, secondCount);
        }

        [TestMethod()]
        public void SletObjektTest()
        {
            //Act
            Service1 service = new Service1();
            //Arrange 
            List<ChangeClassName> theList = service.VisListen();
            int firstCount = theList.Count;

            var temp = theList.Last();

            service.SletObjekt(temp.Id);

            theList = service.VisListen();
            int secondCount = theList.Count;
            //Assert
            Assert.AreNotEqual(firstCount,secondCount);
        }
    }
}