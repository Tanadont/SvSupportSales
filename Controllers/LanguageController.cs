using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SvSupportSales.Services;

namespace SvSupportSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private LanguageService _localization;

        public LanguageController(LanguageService localiaztion)
        {
            _localization = localiaztion;
        }

        [HttpGet("lang")]
        public IActionResult Index([FromHeader(Name = "Accept-Language")] string lang)
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            return Ok(_localization.Getkey());
        }

        [HttpPost("encrypt")]
        public IActionResult Encrypt(string text)
        {
            //const string original = "Text to encrypt";
            /*
            var plaintextBytes = new byte[text];
            RandomNumberGenerator.Fill(plaintextBytes);
            var plaintext = Convert.ToBase64String(plaintextBytes);*/

            var key = new byte[32];
            RandomNumberGenerator.Fill(key);

            var result = EncryptWithNet(text, key);
            var decryptedPlainText = DecryptWithNet(result.ciphertext, result.nonce, result.tag, key);
            Debug.WriteLine("Original Text = " + text);
            Debug.WriteLine("Encrypted Text = " + Convert.ToBase64String(result.ciphertext));
            Debug.WriteLine("Decrypted Text = " + decryptedPlainText);
            return Ok(result);
        }

        private static (byte[] ciphertext, byte[] nonce, byte[] tag) EncryptWithNet(string plaintext, byte[] key)
        {
            {
                var nonce = new byte[AesGcm.NonceByteSizes.MaxSize];
                RandomNumberGenerator.Fill(nonce);

                var tag = new byte[AesGcm.TagByteSizes.MaxSize];

                var plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
                var ciphertext = new byte[plaintextBytes.Length];
                using (var aes = new AesGcm(key))
                {
                    aes.Encrypt(nonce, plaintextBytes, ciphertext, tag);
                }
                return (ciphertext, nonce, tag);
            }
        }

        private static string DecryptWithNet(byte[] ciphertext, byte[] nonce, byte[] tag, byte[] key)
        {
            using (var aes = new AesGcm(key))
            {
                var plaintextBytes = new byte[ciphertext.Length];

                aes.Decrypt(nonce, ciphertext, tag, plaintextBytes);

                return Encoding.UTF8.GetString(plaintextBytes);
            }
        }
    }
}
