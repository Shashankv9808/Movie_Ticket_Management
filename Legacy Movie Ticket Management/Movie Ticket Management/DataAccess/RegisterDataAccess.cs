using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Movie_Ticket_Management.DataAccess
{
    internal static class RegisterDataAccess
    {
        private readonly static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DatabaseConnectString"].ConnectionString;
        internal static bool RegisterNewUserAccount(UserAccountInfos newUserData, out string resultMessage)
        {
            bool result = false;
            resultMessage = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    using (SqlCommand command = new SqlCommand("spRegisterUserAccount", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", newUserData.UserName);
                        command.Parameters.AddWithValue("@EncryptedPassword", newUserData.EncryptedPassword);
                        command.Parameters.AddWithValue("@FirstName", newUserData.FirstName);
                        command.Parameters.AddWithValue("@LastName", newUserData.LastName);
                        command.Parameters.AddWithValue("@ContactNumber", newUserData.ContactNumber);
                        command.Parameters.AddWithValue("@EmailAddress", newUserData.EmailAddress);
                        command.Parameters.AddWithValue("@IsUserAdmin", 0);
                        if(newUserData.ImageSize == null)
                        {
                            command.Parameters.AddWithValue("@ImageSize", SqlDbType.Int);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ImageSize", newUserData.ImageSize);
                        }
                        if(newUserData.ImageData == null)
                        {
                            command.Parameters.AddWithValue("@ImageData", SqlDbType.Binary);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ImageData", newUserData.ImageData);
                        }
                        command.Parameters.AddWithValue("@ReturnStatusCode", SqlDbType.Int).Direction = ParameterDirection.Output;
                        connection.Open();
                        command.ExecuteNonQuery();
                        // read output value from @ReturnStatusCode
                        switch(Convert.ToInt32(command.Parameters["@ReturnStatusCode"].Value))
                        {
                            case 1000:
                                result = true;
                                resultMessage = "User Account Created Successfully.";
                                break;
                            case 1001:
                                resultMessage = "UserName is already exists in database.";
                                break;
                            case 1002:
                                resultMessage = "E-mail ID already exists in database.";
                                break;
                            case 1003:
                                resultMessage = "Contact Number is already exists in database";
                                break;
                            default:
                                resultMessage = "User Account Creation Un-Successful.";
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string exception = ex.Message;
            }
            return result;
        }
        internal static List<UserAccountInfos> GetUserAccountDataList()
        {
            List<UserAccountInfos> all_user_account_list = new List<UserAccountInfos>();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    using (SqlCommand command = new SqlCommand("spGetAllUserAccountDetails", connection))
                    {
                        connection.Open();
                        using (SqlDataReader rd = command.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                UserAccountInfos info = new UserAccountInfos()
                                {
                                    UserID = (int)rd.GetInt64(UserAccountDataInfoFields.UserID),
                                    UserName = rd.GetString(UserAccountDataInfoFields.UserName),
                                    EncryptedPassword = rd.GetString(UserAccountDataInfoFields.EncryptedPassword),
                                    FirstName = rd.GetString(UserAccountDataInfoFields.FirstName),
                                    LastName = rd.GetString(UserAccountDataInfoFields.LastName),
                                    EmailAddress = rd.GetString(UserAccountDataInfoFields.EmailAddress),
                                    ContactNumber = Convert.ToInt64(rd.GetDecimal(UserAccountDataInfoFields.ContactNumber)),
                                    IsUserAdmin = rd.GetBoolean(UserAccountDataInfoFields.IsUserAdmin),
                                };
                                if (!rd.IsDBNull(UserAccountDataInfoFields.ImageSize))
                                {
                                    info.ImageSize = rd.GetInt32(UserAccountDataInfoFields.ImageSize);
                                }
                                else
                                {
                                    info.ImageSize = null;
                                }
                                if (!rd.IsDBNull(UserAccountDataInfoFields.ImageData))
                                {
                                    info.ImageData = Convert.ToBase64String((byte[])rd.GetSqlBinary(UserAccountDataInfoFields.ImageData));
                                }
                                else
                                {
                                    info.ImageData = null;
                                }
                                all_user_account_list.Add(info);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string exception = ex.Message;
            }
            return all_user_account_list;
        }
    }
}