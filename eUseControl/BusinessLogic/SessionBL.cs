﻿using System.Web;
using Domain.Entities.User;
using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic
{
    public class SessionBL : UserApi, ISession
    {
        public ULoginResp UserLogin(ULoginData uLoginData)
        {
            return UserLoginAction(uLoginData);
        }
        public ULoginResp UserRegister(URegisterData uRegisterData)
        {
            return UserRegisterAction(uRegisterData);
        }

        public HttpCookie GenCookie(string loginCredential)
        {
            return Cookie(loginCredential);
        }

        public UserMinimal GetUserByCookie(string apiCookieValue)
        {
            return UserCookie(apiCookieValue);
        }
    }
}
