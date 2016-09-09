using PraticalTest.Service.Interfaces;
using PraticalTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PraticalTest.Domain.Interfaces;

namespace PraticalTest.Service
{
    public class ServiceUser : IServiceUser
    {
        IRepositoryUser _repositoryUser;

        public ServiceUser(IRepositoryUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public User Authenticate(string userEmail, string password)
        {
            try
            {
                User user = _repositoryUser.Authenticate(userEmail);

                if (user == null)
                    return null;

                if (ValidatePassword(password, user.Password))
                {
                    return user;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidatePassword(string password, string MD5HashPassword)
        {
            string hashString = GetMD5Hash(password);
            return (hashString == MD5HashPassword);
        }

        /// <summary>
        /// Criptografia para md5
        /// </summary>
        /// <param name="s">Password string</param>
        /// <returns></returns>
        private string GetMD5Hash(string s)
        {
            //create new instance of md5
            MD5 md5 = MD5.Create();

            //convert the input text to array of bytes
            byte[] hashData = md5.ComputeHash(Encoding.Default.GetBytes(s));

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString("x2"));
            }

            // return hexadecimal string
            return returnValue.ToString();

        }

        public IEnumerable<User> GetAll(bool admin)
        {
            try
            {
                IEnumerable<User> userList = _repositoryUser.GetAll(admin);

                return userList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
