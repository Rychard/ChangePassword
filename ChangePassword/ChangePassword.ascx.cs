using System;
using System.DirectoryServices.AccountManagement;

namespace ChangePassword
{
    public partial class ChangePassword : System.Web.UI.UserControl
    {
        public EventHandler PasswordChanged;
        private void OnPasswordChanged()
        {
            if (PasswordChanged != null)
            {
                PasswordChanged(this, new EventArgs());
            }
        }

        public EventHandler PasswordChangeAttempted;
        private void OnPasswordChangeAttempted()
        {
            if (PasswordChangeAttempted != null)
            {
                PasswordChangeAttempted(this, new EventArgs());
            }
        }

        /// <summary>
        /// Gets a value indicating whether the user visiting the page has authenticated.
        /// </summary>
        public Boolean IsAuthenticated
        {
            get
            {
                Boolean isAuthenticated = Page.User.Identity.IsAuthenticated;
                return isAuthenticated;
            }
        }

        /// <summary>
        /// Gets the username of the currently logged in user.
        /// </summary>
        public String Username
        {
            get
            {
                if (IsAuthenticated)
                {
                    return Page.User.Identity.Name;
                }
                throw new Exception("No user is currently logged in.");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsAuthenticated)
            {
                throw new Exception("You must be logged in to change your password!");
            }
            txtCurrentUser.Text = Username;
        }

        protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
        {
            OnPasswordChangeAttempted();
            if (Page.IsValid)
            {
                TryUpdate(CurrentPassword.Text, NewPassword.Text);
            }
            else
            {
                ExceptionMessage.Text = "Validation Failed";
            }
        }

        public void TryUpdate(string oldPassword, string newPassword)
        {
            try
            {
                String sUser = Page.User.Identity.Name;
                String sUserWithoutDomain = sUser.Substring(sUser.IndexOf('\\') + 1);
                using (var context = new PrincipalContext(ContextType.Machine))
                using (var user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, sUserWithoutDomain))
                {
                    if (user != null)
                    {
                        user.ChangePassword(oldPassword, newPassword);
                        OnPasswordChanged();
                    }
                    else
                    {
                        ExceptionMessage.Text = "A local user account by the name '" + sUserWithoutDomain + "' was not found.";
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionMessage.Text = e.Message;
            }
        }
    }
}