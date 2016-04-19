using System;

namespace Authentication
{
    public sealed class Token
    {
        private TokenCacheWrapper _cacheWrapper = new TokenCacheWrapper();
        const int DefaultCacheTimeout = 60;

        /// <summary>
        /// Reason : Overload method, to genrate token and save it into system. Token return in ref variable if authenticated.
        /// </summary>
        /// <param name="userId">user id string</param>
        /// <param name="userName">user name</param>
        /// <param name="password">password</param>
        /// <param name="cacheTimeOut">cacheTimeOut in minute. If less than zero then default cache time is 60 min</param>
        /// <returns>Return token success if authenticated else return error message</returns>
        public string CreateToken(string userId, string userRole, int cacheTimeOut, ref string token)
        {
            if (string.IsNullOrWhiteSpace((string)userId) || string.IsNullOrWhiteSpace((string)userRole))
                return Message.InvalidInput;

            return CreateToken((object)userId, userRole, cacheTimeOut, ref token);
        }

        /// <summary>
        /// Reason : To genrate token and save it into system. Return token if authenticated else return null
        /// </summary>
        /// <param name="userId">user id int</param>
        /// <param name="userName">user name</param>
        /// <param name="password">password</param>
        /// <param name="cacheTimeOut">cacheTimeOut in minute. If less than zero then default cache time is 60 min</param>
        /// <returns>Return token if authenticated else return null</returns>
        public string CreateToken(int userId, string userRole, int cacheTimeOut, ref string token)
        {
            if (userId <= 0 || string.IsNullOrWhiteSpace((string)userRole))
                return Message.InvalidInput;

            return CreateToken((object)userId, userRole, cacheTimeOut, ref token);
        }

        private string CreateToken(object userId, string userRole, int cacheTimeOut, ref string token)
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();

            var merged = new byte[time.Length + key.Length];
            time.CopyTo(merged, 0);
            key.CopyTo(merged, time.Length);
            token = Convert.ToBase64String(key);
            cacheTimeOut = cacheTimeOut <= 0 ? DefaultCacheTimeout : cacheTimeOut;

            UserDetails userDetails = new UserDetails();
            userDetails.UserId = userId;
            userDetails.Role = userRole;
            userDetails.Token = token;

            _cacheWrapper.AddToken(token, userDetails, cacheTimeOut);

            return Message.Success;
        }

        /// <summary>
        /// To Validate token
        /// logic to check input token in cache. if exists return true else return false. 
        /// </summary>
        /// <param name="token">token</param>
        /// <returns>Return true if Toeken exists else return false</returns>
        public Boolean ValidateToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                return false;

            return (_cacheWrapper.GetToken(token) != null);
        }

        /// <summary>
        /// Reason : To get user details
        /// </summary>
        /// <param name="token">Get user details by token</param>
        /// <returns></returns>
        public UserDetails GetUserDetails(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return null;
            return (UserDetails)_cacheWrapper.GetToken(token);
        }
    }
}
