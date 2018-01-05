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
        /// <summary>
        /// Denne test, tester om listen er højere end 0.
        /// </summary>
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
        /// <summary>
        /// Denne test, indlæser listen laver en count og derefter indsætter et objekt og laver endnu et count for at estimere hvorvidt at de ikke er lig hinanden.
        /// </summary>
        [TestMethod()]
        public void IndsætObjektTest()
        {
            //Act
            Service1 service = new Service1();
            //Arrange
            List<ChangeClassName> theList = service.VisListen();
            int firstCount = theList.Count;

            service.IndsætObjekt(new ChangeClassName(1, "testNavn", "testEfternavn", 200, 10));

            theList = service.VisListen();
            int secondCount = theList.Count;
            //Assert
            Assert.AreNotEqual(firstCount, secondCount);
        }
        /// <summary>
        /// Denne test sletter det sidste element på listen. 
        /// </summary>
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