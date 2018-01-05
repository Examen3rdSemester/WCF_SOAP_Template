using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_SOAP_Template
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<ChangeClassName> VisListen();
        [OperationContract]
        void IndsætObjekt(ChangeClassName temp);

        [OperationContract]
        ChangeClassName VisObjekt(int id);

        [OperationContract]
        void SletObjekt(int id);

        [OperationContract]
        void RedigerObjekt(ChangeClassName temp);

        [OperationContract]
        double UdregnObjekt(int id);




    }
}
