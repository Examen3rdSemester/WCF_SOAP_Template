using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WCF_SOAP_Template
{
    public class Util
    {
        public static ChangeClassName ObjectCreator(SqlDataReader reader)
        {
            ChangeClassName TemporaryObj = new ChangeClassName();


            TemporaryObj.Id = reader.GetInt32(0);
            TemporaryObj.ChangeString = reader.GetString(1);
            TemporaryObj.ChangeString1 = reader.GetString(2);
            TemporaryObj.ChangeDouble = reader.GetDouble(3);
            TemporaryObj.ChangeInteger = reader.GetInt32(4);


            return TemporaryObj;
        }
        public static List<ChangeClassName> ListCreator(SqlDataReader reader)
        {
            List<ChangeClassName> TemporaryList = new List<ChangeClassName>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ChangeClassName TemporaryObj = new ChangeClassName();

                    TemporaryObj.Id = reader.GetInt32(0);
                    TemporaryObj.ChangeString = reader.GetString(1);
                    TemporaryObj.ChangeString1 = reader.GetString(2);
                    TemporaryObj.ChangeDouble = reader.GetDouble(3);
                    TemporaryObj.ChangeInteger = reader.GetInt32(4);

                    TemporaryList.Add(TemporaryObj);
                }
            }

            return TemporaryList;
        }
    }
}