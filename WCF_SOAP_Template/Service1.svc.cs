using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_SOAP_Template
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        #region Listen som skal udkommenteres når SQL påbegyndes
        //Denne skal udkommenteres når SQL påbegyndes.
        private static List<ChangeClassName> ChangeList = new List<ChangeClassName>()
        {
            new ChangeClassName(1, "Navn", "Type", 2.5, 100,new DateTime(2017,12,27,20,50,00))
        };
        #endregion

        #region Metoder til den lokale liste + udregning af løn * antal arbejdsdage.
        /// <summary>
        /// Denne metode returnere listen
        /// </summary>
        /// <returns></returns>
        public List<ChangeClassName> VisListen()
        {
            return ChangeList;
        }
        /// <summary>
        /// Med denne metode kan man indsætte et objekt til listen.
        /// </summary>
        public void IndsætObjekt(ChangeClassName temp)
        {
            ChangeList.Add(temp);
        }
        /// <summary>
        /// Denne metode sletter et objekt på listen fra det givne id hvis objektet eksistere.
        /// </summary>
        /// <param name="id"></param>
        public void SletObjekt(int id)
        {

            foreach (var d in ChangeList)
            {
                if (d.Id == id)
                {
                    ChangeList.Remove(d);
                }
                if (ChangeList.Count == 0)
                {
                    break;
                }
            }
        }
        /// <summary>
        /// Denne metode tillader at redigere løn & arbejdsdage for objektet.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="løn"></param>
        /// <param name="arbejdsdage"></param>
        public void RedigerObjekt(int id, ChangeClassName temp)
        {
            if (ChangeList.Count != 0 && ChangeList.Exists(b => b.Id == id) && temp.ChangeDouble >= 0 && temp.ChangeInteger >= 0)
            {
                ChangeList.Find(b => b.Id == id).ChangeInteger = temp.ChangeInteger;
                ChangeList.Find(b => b.Id == id).ChangeDouble = temp.ChangeDouble;
            }

        }
        /// <summary>
        /// Denne metode udregne et objekts løn ved at gange lønnen med antal arbejdsdage.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double UdregnObjekt(int id)
        {
            if (ChangeList.Count != 0 && ChangeList.Exists(b => b.Id == id))
            {
                return ChangeList.Find(b => b.Id == id).ChangeDouble *
                       double.Parse(ChangeList.Find(b => b.Id == id).ChangeInteger.ToString());
            }
            return 0;
        }
        #endregion

        #region SQL
        ///// <summary>
        ///// Denne metode returnere en liste fra databasen, connection string er defineret i DatabaseService..
        ///// </summary>
        ///// <returns></returns>
        //public List<ChangeClassName> VisListen()
        //{
        //    SqlCommand GetAllElements = new SqlCommand("SELECT * FROM Eksamen", DatabaseService.SqlCon());
        //    SqlDataReader reader = GetAllElements.ExecuteReader();
        //    DatabaseService.SqlCon().Close();

        //    return Util.ListCreator(reader);
        //}
        ///// <summary>
        ///// Denne metode tillader at indsætte data ind i databasen via SQL
        ///// </summary>
        ///// <param name="temp"></param>
        //public void IndsætObjekt(ChangeClassName temp)
        //{
        //    SqlCommand IndsætObjekt =
        //        new SqlCommand(
        //            "insert into Eksamen(ChangeString, ChangeString1, ChangeDouble, ChangeInteger, DateAndTime) values (@ChangeString, @ChangeString1, @ChangeDouble, @ChangeInteger, @DateAndTime)",
        //            DatabaseService.SqlCon());

        //    IndsætObjekt.Parameters.AddWithValue("@ChangeString", temp.ChangeString);
        //    IndsætObjekt.Parameters.AddWithValue("@ChangeString1", temp.ChangeString1);
        //    IndsætObjekt.Parameters.AddWithValue("@ChangeDouble", temp.ChangeDouble);
        //    IndsætObjekt.Parameters.AddWithValue("@ChangeInteger", temp.ChangeInteger);
        //    IndsætObjekt.Parameters.AddWithValue("@DateAndTime", temp.DateAndTime);
        //    IndsætObjekt.ExecuteNonQuery();
        //    DatabaseService.SqlCon().Close();
        //}
        ///// <summary>
        ///// Denne metode tillader at slette en colonne i databasen via SQL
        ///// </summary>
        ///// <param name="id"></param>
        //public void SletObjekt(int id)
        //{
        //    SqlCommand GetAllElements = new SqlCommand("Delete FROM Eksamen WHERE Id = @Id", DatabaseService.SqlCon());
        //    GetAllElements.Parameters.AddWithValue("@Id", id);
        //    GetAllElements.ExecuteNonQuery();
        //    DatabaseService.SqlCon().Close();
        //}
        ///// <summary>
        ///// Denne tillader at lave ændringer i en kolonne i databasen.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="temp"></param>
        //public void RedigerObjekt(int id, ChangeClassName temp)
        //{
        //    SqlCommand RedigerObjekt =
        //                new SqlCommand(
        //                    "Update Eksamen set ChangeString = @ChangeString, ChangeString1 = @ChangeString1, ChangeDouble = @ChangeDouble, ChangeInteger = @ChangeInteger, DateAndTime = @DateAndTime WHERE Id = @Id",
        //                    DatabaseService.SqlCon());
        //    RedigerObjekt.Parameters.AddWithValue("@Id", id);
        //    RedigerObjekt.Parameters.AddWithValue("@ChangeString", temp.ChangeString);
        //    RedigerObjekt.Parameters.AddWithValue("@ChangeString1", temp.ChangeString1);
        //    RedigerObjekt.Parameters.AddWithValue("@ChangeDouble", temp.ChangeDouble);
        //    RedigerObjekt.Parameters.AddWithValue("@ChangeInteger", temp.ChangeInteger);
        //    RedigerObjekt.Parameters.AddWithValue("@DateAndTime", temp.DateAndTime);
        //    RedigerObjekt.ExecuteNonQuery();
        //    DatabaseService.SqlCon().Close();
        //}
        ///// <summary>
        ///// Denne metode returnere en liste fra databasen, connection string er defineret i DatabaseService.
        ///// Der laves en SQL kommando af select og så læses data og dernæst sættes det læste data til de respektive properties
        ///// derefter udregnes matematiken.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public double UdregnObjekt(int id)
        //{
        //    SqlCommand GetAllElements = new SqlCommand($"SELECT * FROM Eksamen WHERE Id = @Id", DatabaseService.SqlCon());
        //    GetAllElements.Parameters.AddWithValue("@Id", id);
        //    SqlDataReader reader = GetAllElements.ExecuteReader();
        //    DatabaseService.SqlCon().Close();

        //    ChangeClassName tempObjekt = new ChangeClassName();
        //    while (reader.Read())
        //    {
        //        tempObjekt = Util.ObjectCreator(reader);
        //    }
        //    return tempObjekt.ChangeDouble * Double.Parse(tempObjekt.ChangeDouble.ToString());

        //}
        #endregion
    }
}
