using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsAppForSearchingWords.ServiceReference1;
using System.Configuration;
//using WindowsAppForSearchingWords.RequiredClasses;

namespace WindowsAppForSearchingWords
{
    public partial class SearchBoxForm : Form
    {
        public SearchBoxForm()
        {
            InitializeComponent();
        }



        private void Searchbtn_Click(object sender, EventArgs e)
        {
            try
            {
                String[] SearchableWords = txtSearchWords.Text.Split(new Char[] { ',' });
                String str = ConfigurationManager.AppSettings["JsonFileStorageLocation"];
                ServiceReference1.FileUploaderClient client = new ServiceReference1.FileUploaderClient();
                SelectedFilesDetails[] SelectedFiles = client.RetrieveFile(SearchableWords);
                //client.RetrieveFile(SearchableWords);
                if (SelectedFiles != null)
                {

                }
            }
            catch(Exception xc)
            {

            }
        }

        private void SearchBoxForm_Load(object sender, EventArgs e)
        {

        }

    }
}
