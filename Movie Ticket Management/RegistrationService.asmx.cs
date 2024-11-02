using Movie_Ticket_Management.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace Movie_Ticket_Management
{

    public class RegistrationService : WebService
    {

        [WebMethod]
        public void UserNameExists(string userName)
        {
            try
            {
                List<UserAccountInfos> all_user_account = RegisterDataAccess.GetUserAccountDataList();
                bool userNameInUse = all_user_account.Any(user => user.UserName.ToLower() == userName.Trim().ToLower());
                Registration regsitration = new Registration();
                regsitration.UserName = userName;
                regsitration.UserNameInUse = userNameInUse;
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(regsitration));
            }
            catch (Exception ex)
            {
                string expection = ex.Message;
            }
        }
        //TODO: Yet to implement the caching mechanism.
        //private const string UserCacheKey = "UserAccountList";

        //[WebMethod]
        //public void UserNameExists(string userName)
        //{
        //    bool userNameInUse;
        //    try
        //    {
        //        // Check cache for user list
        //        List<UserAccountInfos> all_user_account = Cache[UserCacheKey] as List<UserAccountInfos>;

        //        if (all_user_account == null)
        //        {
        //            // Fetch data from database if not cached
        //            all_user_account = RegisterDataAccess.GetUserAccountDataList();

        //            // Add data to cache with expiration
        //            Cache.Insert(UserCacheKey, all_user_account, null, DateTime.UtcNow.AddMinutes(10), CacheItemPriority.Normal);
        //        }

        //        // Check for username existence
        //        userNameInUse = all_user_account.Any(user => user.UserName.ToLower() == userName.Trim().ToLower());

        //        Registration registration = new Registration();
        //        registration.UserName = userName;
        //        registration.UserNameInUse = userNameInUse;
        //        JavaScriptSerializer js = new JavaScriptSerializer();
        //        Context.Response.Write(js.Serialize(registration));

        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exception
        //    }
        //}
    }
}
