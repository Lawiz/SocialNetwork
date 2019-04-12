using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Domain;
using BLL.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface ILoginService
    {
        OperationResult Registration(string email, string name, string hashPassword);

        OperationResult Login(string email, string passwod);

    }

    

    public class LoginService : BaseService<User>,ILoginService
    {
        public LoginService(DbContext context) : base(context)
        {
            
        }
        public OperationResult Registration(string email, string name, string hashPassword)
        {
            try
            {
                var user = Repository.FirstOrDefault(f => f.Email.Equals(email) || f.UserName.Equals(name));
                if (user == null)
                {
                    Repository.Add(new User()
                    {
                        Email = email,
                        UserName = name,
                        PasswordHash = hashPassword

                    });
                }
                else
                {
                    return new OperationResult() {Succes = false, Info = "Имя пользователя или почта уже используюся"};
                }

                return new OperationResult() {Succes = true, Info = "Пользователь успешно добавлен"};
            }
            catch (Exception e)
            {
                return new OperationResult() {Succes = false, Info = "Произошла ошибка"};
            }

        }

        public OperationResult Login(string email, string passwod)
        {
            
            var user = Repository.FirstOrDefault(f => f.Email.Equals(email));
            if (user != null && user.PasswordHash.Equals(passwod))
            {
                return new OperationResult() {Succes = true, Info = "Зашел"};
            }
            else
            {
                return new OperationResult() {Succes = false, Info = "Неверные имя пользователя или пароль"};
            }
            
        }
    }

}
