using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Authentication;
namespace Test.Authentication
{
    [TestClass]
    public class TokenTest
    {

        internal Token _authToken = new Token();

        #region Create token

        /// <summary>
        ///  Create Token with null and invalid data
        /// </summary>
        [TestMethod]
        public void CreateTokenWithNullAndInvalidData()
        {
            //Arrange
            int userIdInt = -1;
            string userIdStringNull = null;
            string userIdStringInvalid = "     ";
            string userRoleNull = null;
            string userRoleInvalid = "   ";
            int timeOut = 0;
            object expectedResult = null;

            string tokenWithNullData = null;
            string tokenWithInvalidData = null;
            string tokenWithInvalidDataForStringUserId = null;

            //Act
            //Act when token is Invalid for interger user id
            _authToken.CreateToken(userIdInt, userRoleNull, timeOut, ref tokenWithNullData);
            //Act when token is null for string user id
            _authToken.CreateToken(userIdStringNull, userRoleInvalid, timeOut, ref tokenWithInvalidData);
            //Act when token is invalid 
            _authToken.CreateToken(userIdStringInvalid, userRoleInvalid, timeOut, ref tokenWithInvalidDataForStringUserId);

            //Assert
            Assert.AreEqual(expectedResult, tokenWithNullData, "Exception occurred due to null data for invalid user id of integer type");
            Assert.AreEqual(expectedResult, tokenWithInvalidData, "Exception occurred due to null data for invalid user id of string type");
            Assert.AreEqual(expectedResult, tokenWithInvalidDataForStringUserId, "Exception occurred due to invalid data for user id string type");

        }

        /// <summary>
        /// Case : Create token with valid inputs.
        /// </summary>
        [TestMethod]
        public void CreateTokenWithValidInputData()
        {
            //Arrange
            int userIdInt = 4;
            string userIdString = "abc";
            string userRole = "Admin";
            int timeOut = 1;
            string tokenForIntUserId = null;
            string tokenForStringUserId = null;

            //Act
            _authToken.CreateToken(userIdInt, userRole, timeOut, ref tokenForIntUserId);
            _authToken.CreateToken(userIdString, userRole, timeOut, ref tokenForStringUserId);

            //Assert
            Assert.IsNotNull(tokenForIntUserId, "Valid Token created for user id of integer type");
            Assert.IsNotNull(tokenForStringUserId, "Valid Token created for user id of string type");
        }

        #endregion

        #region Validate Token

        /// <summary>
        /// Case 1: Validate Token with null and invalid data values
        /// </summary>
        [TestMethod]
        public void ValidateTokenWithInvalidData()
        {
            //Arrange
            string tokenInvalid = null;
            string tokenNull = null;
            Boolean expectedResult = false;
            //Act
            object actualResultWhenInvalidToken = _authToken.ValidateToken(tokenInvalid);
            object actualResultWhenNullToken = _authToken.ValidateToken(tokenNull);

            //Assert
            Assert.AreEqual(expectedResult, actualResultWhenInvalidToken);
            Assert.AreEqual(expectedResult, actualResultWhenNullToken);

        }

        [TestMethod]
        public void ValidateTokenWithValidData()
        {
            //Arrange
            string token = null;
            _authToken.CreateToken(1, "Admin", 1, ref token);
            Boolean expectedResult = true;

            //Act
            object actualResult = _authToken.ValidateToken(token);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion

        #region Get User Details by Token

        /// <summary>
        /// Case 1: Get user details by Invalid Token
        /// </summary>
        [TestMethod]
        public void GetUserDetailsByInvalidToken()
        {
            //Arrange
            string tokenNull = null;
            string tokenInvalid = "    ";
            object expectedResult = null;

            //Act
            object actualResultWhenTokenNull = _authToken.GetUserDetails(tokenNull);
            object actualResultWhenTokenInvalid = _authToken.GetUserDetails(tokenInvalid);

            //Assert
            Assert.AreEqual(expectedResult, actualResultWhenTokenNull, "Exception occurred due to null token");
            Assert.AreEqual(expectedResult, actualResultWhenTokenInvalid, "Exception occurred due to invalid token");
        }

        /// <summary>
        /// Case 2: Get user details by valid Token
        /// </summary>
        [TestMethod]
        public void GetUserDetailsByValidToken()
        {
            //Arrange
            string token = null;
            _authToken.CreateToken(1, "Admin", 1, ref token);
            Boolean expectedResult = true;
            //Act
            object actualResult = _authToken.ValidateToken(token);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        #endregion
    }
}
