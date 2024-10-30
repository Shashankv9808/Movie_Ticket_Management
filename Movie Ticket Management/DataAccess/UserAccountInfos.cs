using System;
using System.Security.Cryptography;

namespace Movie_Ticket_Management.DataAccess
{
    public class UserAccountInfos
    {
        public Int64 UserID { get; set; }
        public string UserName { get; set; }
        public string EncryptedPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool IsUserAdmin { get; set; }
        public int ImageSize { get; set; }
        public string ImageData { get; set; }
        public static String Encrypt(String Password)
        {
            if (Password == null)
            {
                throw new ArgumentNullException();
            }
            HashAlgorithm hash_algorithm = new SHA1CryptoServiceProvider();
            // Convert the original string to array of Bytes
            byte[] password_as_bytes = System.Text.Encoding.UTF8.GetBytes(Password);
            // Compute the Hash, returns an array of Bytes
            byte[] hashed_password_as_bytes = hash_algorithm.ComputeHash(password_as_bytes);
            // need to free up some resources
            hash_algorithm.Clear();
            // Return a base 64 encoded string of the Hash value
            return Convert.ToBase64String(hashed_password_as_bytes);
        }
    }
    
}