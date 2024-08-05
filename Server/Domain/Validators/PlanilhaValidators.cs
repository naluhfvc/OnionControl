using Microsoft.AspNetCore.Http;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace OnionServer.Domain.Validators
{
    public static class PlanilhaValidators
    {
        public static string ValidarNumeroDoc(string numeroDoc)
        {
            var docFormatado = SomenteNumeros(numeroDoc);

            if (docFormatado.Length != 11 && docFormatado.Length != 14)
            {
                throw new ArgumentException("Número de documento inválido. Quantidade de dígitos deve ser de um CPF ou CNPJ.");
            }

            return docFormatado;
        }

        public static string SomenteNumeros(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("Texto não pode ser vazio.");
            }

            return new string(text.Where(char.IsDigit).ToArray());
        }

        public static string ValidarCEP(string cep)
        {
            var cepFormatado = SomenteNumeros(cep);

            if (cepFormatado.Length != 8)
            {
                throw new ArgumentException("CEP inválido.");
            }

            return cepFormatado;
        }

        public static DateOnly FormatarDataParaDateOnly(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException("Data não pode ser vazia ou nula.");
            }
            var formato = "dd/MM/yyyy HH:mm:ss";
            if (DateTime.TryParseExact(data, formato,CultureInfo.InvariantCulture, DateTimeStyles.None, out var dataFormatada))
            {
                Console.WriteLine(DateOnly.FromDateTime(dataFormatada));
                return DateOnly.FromDateTime(dataFormatada);
            }
            else
            {
                throw new FormatException("O campo Data fornecido não está em um formato válido.");
            }
        }
    }
}
