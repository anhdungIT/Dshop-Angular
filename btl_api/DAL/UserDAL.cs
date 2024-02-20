using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.UserDAL;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Model.Models;
using DAL.Helper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DAL
{
    public interface IUserDAL
    {
        public bool Register(ApplicationUser user);
        public string Authenticate(LoginRequest request);

        public bool Delete(ApplicationUser user);
        public bool Update(ApplicationUser user);
        public List<ApplicationUser> GetAll();
    }
    public class UserDAL : IUserDAL
    {
        private IDatabaseHelper _dbHelper;
        private readonly AppSettings _appSettings;
        public UserDAL(IDatabaseHelper dbHelper, IOptions<AppSettings> appSettings)
        {
            _dbHelper = dbHelper;
            _appSettings = appSettings.Value;
        }
        public static bool IsValidPassword(string plainText)
        {
            Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            Match match = regex.Match(plainText);
            return match.Success;
        }
        public bool Register(ApplicationUser user)
        {
            if (!IsValidPassword(user.Password))
            {
                return false;
            }
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "register",
                "@name", user.FullName,
                "@address", user.Address,
                "@birthday", user.BirthDay,
                "@email", user.Email,
                "@phone", user.PhoneNumber,
                "@username", user.UserName,
                "@password", user.Password
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(ApplicationUser user)
        {
            if (!IsValidPassword(user.Password))
            {
                return false;
            }
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_user_update",
                "@userId", user.CustomerId,
                "@name", user.FullName,
                "@address", user.Address,
                "@birthday", user.BirthDay,
                "@email", user.Email,
                "@phone", user.PhoneNumber,
                "@username", user.UserName,
                "@password", user.Password
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(ApplicationUser user)
        {


            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_user_delete",
                "@id", user.CustomerId);
                ;
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ApplicationUser> GetAll()
        {

            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_user_getAll");

                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return result.ConvertTo<ApplicationUser>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Authenticate(LoginRequest request)
        {

            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Accounts_User_CheckLogin",
                     "@username", request.UserName,
                     "@password", request.Password);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                var user = dt.ConvertTo<ApplicationUser>().FirstOrDefault();
                if (user == null)
                    return null;

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.FullName.ToString()),         
                    new Claim(ClaimTypes.DenyOnlyWindowsDeviceGroup, user.Password)
                    }),
                    Expires = DateTime.UtcNow.AddHours(3),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var tmp = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(tmp);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public class LoginRequest
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}
