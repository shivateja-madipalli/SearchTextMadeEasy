using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InsertDocumentSearchWord_WebInterface
{
    public partial class UploadPage : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        protected static string CalledFromClient()
        {
            return "Hello from the server-side World!";
        }

        protected void DummyButtonForClick_Click(object sender, EventArgs e)
        {
            // call wcf function from here
            Response.Redirect("http://www.microsoft.com/gohere/look.htm");
        }
    }
}