using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AutoMapper;
using eUseControl.Domain.Entities.User;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Enums;
using eUseControl.Helpers;
using EntityState = System.Data.Entity.EntityState;
using Domain.Entities.User;

namespace eUseControl.BusinessLogic.Core
{
    public class UserApi
    {
        internal ULoginResp UserLoginAction(ULoginData data)
        {
            UDbTable user;
            //var pass = LoginHelper.HashGen(data.Password);

            using (var db = new UserContext())
            {
                user = db.Users.FirstOrDefault(u => u.Email == data.Email && u.Password == data.Password);
            }

            if (user == null)
            {
                return new ULoginResp { Status = false, StatusMsg = "Email sau parola sunt incorecte." };
            }

            // Generarea cookie la autentificare
            var apiCookie = Cookie(user.Email);
            // Add cookie to response
            HttpContext.Current.Response.Cookies.Add(apiCookie);

            return new ULoginResp { Status = true };
        }

        internal HttpCookie Cookie(string loginCredential)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(loginCredential)
            };

            using (var db = new SessionContext())
            {
                // Initializare DB SessionContext, in caz daca nu exista
                Database.SetInitializer<SessionContext>(new CreateDatabaseIfNotExists<SessionContext>());

                var session = db.Sessions.FirstOrDefault(s => s.Email == loginCredential);
                if (session != null)
                {
                    session.CookieString = apiCookie.Value;
                    session.ExpireTime = DateTime.Now.AddMinutes(60);
                    session.Email = loginCredential;
                    db.Entry(session).State = EntityState.Modified;
                }
                else
                {
                    db.Sessions.Add(new Session
                    {
                        Email = loginCredential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                }

                db.SaveChanges();
            }

            return apiCookie;
        }

        internal UserMinimal UserCookie(string cookie)
        {
            using (var db = new SessionContext())
            {
                var session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
                if (session == null)
                {
                    return null;
                }

                UDbTable currentUser;
                using (var userDb = new UserContext())
                {
                    currentUser = userDb.Users.FirstOrDefault(u => u.Email == session.Email);
                }

                if (currentUser == null)
                {
                    return null;
                }

                var userminimal = Mapper.Map<UserMinimal>(currentUser);

                return userminimal;
            }
        }

        internal ULoginResp UserRegisterAction(URegisterData data)
        {
            UDbTable user;

            using (var db = new UserContext())
            {
                user = db.Users.FirstOrDefault(u => u.Email == data.Email);
            }

            if (user != null)
            {
                return new ULoginResp { Status = false, StatusMsg = "User already exists" };
            }

            // Create a new user
            user = new UDbTable
            {
                Nume = data.Nume,
                Prenume = data.Prenume,
                Email = data.Email,
                Password = data.Password,
                Level = URole.User
            };

            // Save the new user to the database
            using (var db = new UserContext())
            {
                Database.SetInitializer<UserContext>(new CreateDatabaseIfNotExists<UserContext>());
                db.Users.Add(user);
                db.SaveChanges();
            }

            // Succes
            return new ULoginResp { Status = true, StatusMsg = "Utilizatorul a fost înregistrat cu succes." };
        }
    }

}