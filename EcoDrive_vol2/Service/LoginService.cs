using EcoDrive_vol2.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Service
{
    public class LoginService
    {
        private LoginContext context =
            new LoginContext();

        public string Login(
            string username,
            string password)
        {
            // Validasi sederhana
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            return context.Login(
                username,
                password);

        }
    }
}