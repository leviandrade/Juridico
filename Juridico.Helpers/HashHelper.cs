using System.Security.Cryptography;
using System.Text;

namespace Juridico.Helpers
{
    public static class HashHelper
    {
        public static string CriptografarTexto(string texto)
        {
            var algoritmo = SHA512.Create();
            var encodedValue = Encoding.UTF8.GetBytes(texto);
            var encryptedPassword = algoritmo.ComputeHash(encodedValue);

            var sb = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
