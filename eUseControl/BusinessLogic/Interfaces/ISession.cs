using System.Web;
using Domain.Entities.User;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface ISession
    {
        ULoginResp UserLogin(ULoginData uLoginData);

        ULoginResp UserRegister(URegisterData URegisterData);

        HttpCookie GenCookie(string loginCredential);

        UserMinimal GetUserByCookie(string apiCookieValue);

    }
}
