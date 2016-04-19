using Authentication;
using System;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        Token authService = new Token();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string timeOut = System.Configuration.ConfigurationManager.AppSettings["cacheTimeOut"];
            string token = null;
            string message= authService.CreateToken(1, "Admin", Convert.ToInt32(timeOut), ref token);
            txtToken.Text = token != null ? token : lblMessage.Text = message;
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            Boolean token = authService.ValidateToken(txtToken.Text.ToString());
            lblMessage.Text = "\"" + txtToken.Text.ToString() + "\"" + " is " + (token ? " Valid token" : " Invalid token");
        }

        private void btnUerDetails_Click(object sender, EventArgs e)
        {
            UserDetails details= authService.GetUserDetails(txtToken.Text.ToString());
            if (details == null)
            {
                lblMessage.Text = "Invalid Token";
                return;
            }
            lblMessage.Text = "User Id :" + details.UserId + ", User Role : " + details.Role;
        }
    }
}
