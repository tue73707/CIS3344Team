using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Utilities;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace CIS3344TeamProject
{
    /// <summary>
    /// Summary description for homeSvc
    /// </summary>
    
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class homeSvc : System.Web.Services.WebService
    {
        SqlCommand objCommand = new SqlCommand();
        DBConnect objDB = new DBConnect();

        // This method receives a maximum price of a home and returns a Home object with the field values from the database.
        // This method returns an ArrayList of Home objects that represents all the home with a given max price.
        [WebMethod]
        public List<Home> GetHomeByMaxPrice(Decimal price)
        {
            List<Home> homeList = new List<Home>();
           // DBConnect objDB = new DBConnect();
            String strSQL = "SELECT * FROM Home WHERE Price <= " + price;
            int count = 0;

            objDB.GetDataSet(strSQL, out count);

            for (int i = 0; i < count; i++)
            {
                Home objHome = new Home();
                objHome.mls= (int)objDB.GetField("MLS", i);
                objHome.address = objDB.GetField("Address", i).ToString();
                objHome.city = objDB.GetField("City", i).ToString();
                objHome.state = objDB.GetField("State", i).ToString();
                objHome.zipcode = objDB.GetField("ZipCode", i).ToString();
                objHome.bed = (int)objDB.GetField("Bed", i);
                objHome.bath = (int)objDB.GetField("Bath", i);
                objHome.price = (Decimal)objDB.GetField("Price", i);
                objHome.size = (int)objDB.GetField("Size", i);
                objHome.status = objDB.GetField("Status", i).ToString();
                objHome.description = objDB.GetField("Description", i).ToString();
                objHome.url = objDB.GetField("URL", i).ToString();




                homeList.Add(objHome);
            }

            return homeList;
        }

        // This method receives number of bed & bath for a home and returns a Home object with the field values from the database.
        // This method returns an ArrayList of Home objects that represents all the homes with a given number of bed & bath.
        [WebMethod]
        public List<Home> GetHomeByBedAndBath(int bed, int bath)
        {
            List<Home> homeList = new List<Home>();
           // DBConnect objDB = new DBConnect();
            String strSQL = "SELECT * FROM Home WHERE Bed =" + bed + ",Bath =" + bath;
            int count = 0;

            objDB.GetDataSet(strSQL, out count);

            for (int i = 0; i < count; i++)
            {
                Home objHome = new Home();
                objHome.mls = (int)objDB.GetField("MLS", i);
                objHome.address = objDB.GetField("Address", i).ToString();
                objHome.city = objDB.GetField("City", i).ToString();
                objHome.state = objDB.GetField("State", i).ToString();
                objHome.zipcode = objDB.GetField("ZipCode", i).ToString();
                objHome.bed = (int)objDB.GetField("Bed", i);
                objHome.bath = (int)objDB.GetField("Bath", i);
                objHome.price = (int)objDB.GetField("Price", i);
                objHome.size = (int)objDB.GetField("Size", i);
                objHome.status = objDB.GetField("Status", i).ToString();
                objHome.description = objDB.GetField("Description", i).ToString();
                objHome.url = objDB.GetField("URL", i).ToString();




                homeList.Add(objHome);
            }

            return homeList;
        }

        [WebMethod]
        public Boolean AddHome(Home home)
        {
            //DBConnect objDB = new DBConnect();

            string strSQL = "INSERT INTO Home (Address, City, State, ZipCode, Bed, Bath, Price, Size, Status, Description, URL)" +
                " VALUES ('" + home.address + "','" + home.city + "','" + home.state + "','" + home.zipcode +
                "','" + home.bed + "','" + home.bath + "','" + home.price + "','" + home.size + "','" +
                home.status + "','" + home.description + "','" + home.url + "')";

            int result = objDB.DoUpdate(strSQL);

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public Home GetHome(int mlsNum)
        {
            DBConnect objDB = new DBConnect();
            Home home = new Home();

            //string strSQL = "SELECT Address, City, State, ZipCode, Bed, Bath, Price, Size, Status, Description, URL FROM Home WHERE MLS=" + mlsNum;
            string strSQL = "SELECT * FROM Home WHERE MLS=" + mlsNum;
            int count = 0;

            objDB.GetDataSet(strSQL, out count);

            if (count > 0)
            {
                //home.mls = Convert.ToInt32(objDB.GetField("MLS", 0).ToString());
                home.address = objDB.GetField("Address", 0).ToString();
                home.city = objDB.GetField("City", 0).ToString();
                home.state = objDB.GetField("State", 0).ToString();
                home.zipcode = objDB.GetField("ZipCode", 0).ToString();
                home.bed = Convert.ToInt32(objDB.GetField("Bed", 0).ToString());
                home.bath = Convert.ToInt32(objDB.GetField("Bath", 0).ToString());
                home.price = Convert.ToDecimal(objDB.GetField("Price", 0).ToString());
                home.size = Convert.ToInt32(objDB.GetField("Size", 0).ToString());
                home.status = objDB.GetField("Status", 0).ToString();
                home.description = objDB.GetField("Description", 0).ToString();
                home.url = objDB.GetField("URL", 0).ToString();
            }
            return home;
        }

        [WebMethod]
        public Home UpdateStatus(int mlsNum, string status)
        {
            DBConnect objDB = new DBConnect();
            Home home = new Home();

            //string strSQL = "SELECT Address, City, State, ZipCode, Bed, Bath, Price, Size, Status, Description, URL FROM Home WHERE MLS=" + mlsNum;
            string strSQL = "UPDATE Home SET status='" + status + "' WHERE MLS=" + mlsNum;
            int count = 0;

            objDB.GetDataSet(strSQL, out count);

            if (count > 0)
            {
                //home.mls = Convert.ToInt32(objDB.GetField("MLS", 0).ToString());
                home.address = objDB.GetField("Address", 0).ToString();
                home.city = objDB.GetField("City", 0).ToString();
                home.state = objDB.GetField("State", 0).ToString();
                home.zipcode = objDB.GetField("ZipCode", 0).ToString();
                home.bed = Convert.ToInt32(objDB.GetField("Bed", 0).ToString());
                home.bath = Convert.ToInt32(objDB.GetField("Bath", 0).ToString());
                home.price = Convert.ToInt32(objDB.GetField("Price", 0).ToString());
                home.size = Convert.ToInt32(objDB.GetField("Size", 0).ToString());
                home.status = objDB.GetField("Status", 0).ToString();
                home.description = objDB.GetField("Description", 0).ToString();
                home.url = objDB.GetField("URL", 0).ToString();
            }
            return home;
        }


    }
}
