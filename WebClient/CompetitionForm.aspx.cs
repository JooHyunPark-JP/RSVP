using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{


        
    public partial class CompetitionForm : System.Web.UI.Page
    {
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_AllStudents_Click(object sender, EventArgs e)
        {
            //Get method from service trough variable client by used SoapClient. 
            GridView1.DataSource = client.ExtractAllStudents();
            //Datababind to Gridview. 
            GridView1.DataBind();



        }

        protected void btn_SomeParts_Click(object sender, EventArgs e)
        {
            GridView2.DataSource = client.ExtractSomeParts();
            GridView2.DataBind();
        }

        protected void btn_Detail_Click(object sender, EventArgs e)
        {
            GridView3.DataSource = client.ExtractDetailInformation();
            GridView3.DataBind();
        }
    }
}