using System.Globalization;
using System.Linq;
using System;

namespace SEU_NAMESPACE
{
    public static class MaskFormatHelper
    {
        public static string MaskCpfCnpj(this string cpfCnpj)
        {
            if (string.IsNullOrEmpty(cpfCnpj) || !cpfCnpj.All(char.IsDigit)) return string.Empty;

            if (cpfCnpj.Length == 11)
                return cpfCnpj = string.Format(@"{0:000\.000\.000\-00}", long.Parse(cpfCnpj));
            else if (cpfCnpj.Length == 14)
                return cpfCnpj = string.Format(@"{0:00\.000\.000\/0000\-00}", long.Parse(cpfCnpj));

            return cpfCnpj;
        }

        public static string MaskPhone(this string phone)
        {
            if (string.IsNullOrEmpty(phone) || !phone.All(char.IsDigit)) return string.Empty;

            if (phone.Length == 11)
                return long.Parse(phone).ToString("(00) 00000-0000");
            if (phone.Length == 10)
                return long.Parse(phone).ToString("(00) 0000-0000");

            return phone;
        }

        public static string MaskCep(this string cep)
        {
            if (string.IsNullOrEmpty(cep)) return string.Empty;

            return cep.All(char.IsDigit) && cep.Length == 8 ? Convert.ToUInt64(cep).ToString(@"00000\-000") : cep;
        }

        public static string MaskCep(this int cep) => cep.ToString().MaskCep();

        #region Format Currency

        /// <summary>
        /// Formata o valor com o prefixo BRL ou USD ex: R$1.200,00
        /// </summary>
        /// <param name="currency">Valor a ser formatado</param>
        /// <param name="isBRL">Se é BRL ou USD</param>
        /// <param name="decimals">Casas decimais</param>
        /// <returns>Retorna o valor formatado</returns>
        public static string MaskCurrencyWithPrefix(this decimal currency, bool isBRL, int decimals = 0)
        {
            return currency.ToString($@"C{decimals}", CultureInfo.CreateSpecificCulture(isBRL ? "pt-BR" : "en-US"));
        }

        /// <summary>
        /// Formata o valor sem o prefixo BRL ou USD ex: 1.200,00
        /// </summary>
        /// <param name="currency">Valor a ser formatado</param>
        /// <param name="isBRL">Se é BRL ou USD</param>
        /// <param name="decimals">Casas decimais</param>
        /// <returns>Retorna o valor formatado</returns>
        public static string MaskCurrencyBRLWithoutPrefix(this decimal currency, bool isBRL, int decimals = 0)
        {
            return currency.ToString($@"N{decimals}", CultureInfo.CreateSpecificCulture(isBRL ? "pt-BR" : "en-US"));
        }

        /// <summary>
        /// Formata o valor com o prefixo BRL ou USD ex: R$1.200,00
        /// </summary>
        /// <param name="currency">Valor a ser formatado</param>
        /// <param name="isBRL">Se é BRL ou USD</param>
        /// <param name="decimals">Casas decimais</param>
        /// <returns>Retorna o valor formatado</returns>
        public static string MaskCurrencyWithPrefix(this double currency, bool isBRL, int decimals = 0)
        {
            return currency.ToString($@"C{decimals}", CultureInfo.CreateSpecificCulture(isBRL ? "pt-BR" : "en-US"));
        }

        /// <summary>
        /// Formata o valor sem o prefixo BRL ou USD ex: 1.200,00
        /// </summary>
        /// <param name="currency">Valor a ser formatado</param>
        /// <param name="isBRL">Se é BRL ou USD</param>
        /// <param name="decimals">Casas decimais</param>
        /// <returns>Retorna o valor formatado</returns>
        public static string MaskCurrencyWithoutPrefix(this double currency, bool isBRL, int decimals = 0)
        {
            return currency.ToString($@"N{decimals}", CultureInfo.CreateSpecificCulture(isBRL ? "pt-BR" : "en-US"));
        }
        #endregion
    }
}
