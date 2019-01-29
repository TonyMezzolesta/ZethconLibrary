using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZethconLibrary;

namespace TestApp
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("ActiveUserAPI");           
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedItem.ToString())
            {
                case "ActiveUserAPI":
                    ActivateUserRequestModel activeUserRequest = JsonConvert.DeserializeObject<ActivateUserRequestModel>(richTextBox1.Text.ToString()); ;                  
                    ActivateUserResponseModel activeUserReponse = ZethconAPI.ActivateUserAPI(activeUserRequest);
                    richTextBox2.Text = JsonConvert.SerializeObject(activeUserReponse).ToString();
                    break;
            }
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}
