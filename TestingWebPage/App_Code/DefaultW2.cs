using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;


/// <summary>
/// Summary description for DefaultW2
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class DefaultW2 : System.Web.Services.WebService {

    public DefaultW2 () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    public string sendData(string Name, string Number, string Email, string Subj, string Message)
    {
        string json = "";
       
        string connstr = ConfigurationManager.ConnectionStrings["DBL"].ConnectionString;
        SqlConnection conn = new SqlConnection(connstr);
        conn.Open();
        //This will to run the DB query with user entered value specificaly 
        //insert into Claim_Status_Trans(Claim_ID,Claim_Status,Status,Deleted_Flag,Row_upd_date)values(@claimid,7,1,0,@rowupddate)
        string qry1 = "insert into SendDataTable(Name, Number, Email, Subj, Message)values('" + Name + "','" + Number + "','" + Email + "','" + Subj + "','" + Message + "')";
        SqlCommand movestoclaims = new SqlCommand(qry1, conn);
        movestoclaims.ExecuteNonQuery();
        conn.Close();
        return json;
    }

    
    
}
