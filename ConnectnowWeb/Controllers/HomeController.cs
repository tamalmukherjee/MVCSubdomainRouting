namespace ConnectnowWeb.Controllers
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index(string subdomain)
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Route("Crypto/Gethash/{data}")]
        public ActionResult GetHash(string data)
        {
            return Content(ComputeHash(data));
        }

        [Route("Crypto/Verifydata/{data}")]
        public ActionResult VerifyHash(string data)
        {
            string hash = @"+wExY4w35i2eAOrNeFSQdJ9g3+QH4RMF2mR3LL0jS9UfwHlN7bgfcEJT/qBu+bodvCSmCc6cHW2j5xqSXVdzPGz+SkrYGokfbuY=";
            return Content(VerifyHash(data, hash).ToString());
        }

        private static string ComputeHash(string plainText, byte[] saltBytes = null)
        {
            if (saltBytes == null)
            {
                Random random = new Random();
                int saltSize = random.Next(4, 16);
                saltBytes = new byte[saltSize];
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                rng.GetNonZeroBytes(saltBytes);
            }

            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] plainTextWithSaltBytes = new byte[plainTextBytes.Length + saltBytes.Length];

            for (int i = 0; i < plainTextBytes.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainTextBytes[i];
            }

            for (int i = 0; i < saltBytes.Length; i++)
            {
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];
            }

            HashAlgorithm hash = new SHA512Managed();

            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);
            byte[] hashWithSaltBytes = new byte[hashBytes.Length + saltBytes.Length];

            for (int i = 0; i < hashBytes.Length; i++)
            {
                hashWithSaltBytes[i] = hashBytes[i];
            }

            for (int i = 0; i < saltBytes.Length; i++)
            {
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];
            }

            string hashValue = Convert.ToBase64String(hashWithSaltBytes);
            return hashValue;
        }

        private static bool VerifyHash(string plainText, string hashValue)
        {
            byte[] hashWithSaltBytes = Convert.FromBase64String(hashValue);
            int hashSizeInBits = 512;
            int hashSizeInBytes = hashSizeInBits / 8;

            if (hashWithSaltBytes.Length < hashSizeInBytes)
            {
                return false;
            }

            byte[] saltBytes = new byte[hashWithSaltBytes.Length - hashSizeInBytes];

            for (int i = 0; i < saltBytes.Length; i++)
            {
                saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];
            }

            string expectedHashString = ComputeHash(plainText, saltBytes);

            return hashValue == expectedHashString;
        }
    }
}