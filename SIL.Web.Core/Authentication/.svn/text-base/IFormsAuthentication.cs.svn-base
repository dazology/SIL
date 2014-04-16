using System.Web.Security;
using System.Web;


namespace SIL.Web.Core.Authentication
{
    public interface IFormsAuthentication
    {
        void Signout();
        void SetAuthCookie(HttpContextBase httpContext, FormsAuthenticationTicket authenticationTicket);
        void SetAuthCookie(HttpContext httpContext, FormsAuthenticationTicket authenticationTicket);
        FormsAuthenticationTicket Decrypt(string encryptedTicket);
    }
}
