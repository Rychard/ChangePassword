using System;
using System.Web.UI;

namespace ChangePassword
{
    public partial class Default : Page
    {
        protected override void OnInit(EventArgs e)
        {
            ChangePasswordControl.PasswordChangeAttempted += PasswordChangeAttempted;
            ChangePasswordControl.PasswordChanged += PasswordChanged;
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void PasswordChangeAttempted(object sender, EventArgs eventArgs)
        {
            panelSuccess.Visible = false;
        }

        private void PasswordChanged(object sender, EventArgs eventArgs)
        {
            panelSuccess.Visible = true;
        }
    }
}