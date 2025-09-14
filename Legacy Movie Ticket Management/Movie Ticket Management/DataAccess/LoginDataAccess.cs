using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Antlr.Runtime;
using System.Windows.Input;

namespace Movie_Ticket_Management.DataAccess
{
    internal static class LoginDataAccess
    {
        private readonly static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DatabaseConnectString"].ConnectionString;
        internal static bool IsUserAuthencication(UserAccountInfos newUserData, out bool IsUserAdmin)
        {
            bool result = false;
            IsUserAdmin = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    using (SqlCommand command = new SqlCommand("spUserAccountAuthenication", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", newUserData.UserName);
                        command.Parameters.AddWithValue("@EncryptedPassword", newUserData.EncryptedPassword);
                        command.Parameters.AddWithValue("@IsUserAdmin", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        command.Parameters.AddWithValue("@ReturnStatusCode", SqlDbType.Int).Direction = ParameterDirection.Output;
                        connection.Open();
                        command.ExecuteNonQuery();
                        if (command.Parameters["@IsUserAdmin"].Value == DBNull.Value)
                        {
                            IsUserAdmin = false;
                        }
                        else
                        {
                            IsUserAdmin = Convert.ToBoolean(command.Parameters["@IsUserAdmin"].Value);
                        }
                        switch (Convert.ToInt32(command.Parameters["@ReturnStatusCode"].Value))
                        {
                            case 1000:
                                result = true;
                                break;
                            case 0:
                                result = false;
                                break;
                            default:
                                result = false;
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
    }
}