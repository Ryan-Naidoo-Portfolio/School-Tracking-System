using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System;


namespace test_Data.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Please enter Username")]
        public required string UserName { get; set; }
        [Required(ErrorMessage = "Please enter Email")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Get big boy")]
        public required string Password { get; set; }
    }



    public static class Hashing
    {
        public static string ToSHA256(string S)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(S));

            var sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }



    }

   
}

