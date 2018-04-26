using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SiteAdmin.Infrastructure.Core.Base
{
    class Util
    {
        public static Regex _cpf = new Regex(@"^\d{3}\.?\d{3}\.?\d{3}\-?\d{2}$", RegexOptions.Compiled);
        public static Regex _cnpj = new Regex(@"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)");
        public static Regex _email = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

        public static string BaseUrl { get; set; }

        public static string GenerateHashMD5(string value)
        {
            //criando nova instância de um hasher md5
            MD5 md5hasher = MD5.Create();
            //criando um gerador de strings
            StringBuilder gerarString = new StringBuilder();

            //criando um vetor de bytes que recebera
            //em bytes o valor da senha original
            byte[] vetor = Encoding.Default.GetBytes(value);

            //calculando o hash dos bytes e inserindo no próprio vetor
            vetor = md5hasher.ComputeHash(vetor);

            //repita para cada elemento do vetor gerar uma
            //string convertida para hexadecimal
            foreach (byte item in vetor)
            {
                gerarString.Append(item.ToString("x2"));
            }

            //retornar a string em forma de string e em maiúscula
            return gerarString.ToString().ToUpper();
        }

        //Serializa o objeto e retorna uma string em formato json
        public static string JsonSerializer<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }

        //Lê o json e retorna o objeto já montado
        public static T JsonDeserialize<T>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            System.IO.MemoryStream ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }

        public static bool ValidateCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        public static bool ValidateCpf(string cpf)
        {
            //cpfs com numeros iguais soa considerador cpfs validos segundo a receita, porem cancelados.
            //estou colocando para retornar falso para eles embora ejam validos para a receita.
            switch (cpf)
            {
                case "00000000000":
                    return false;
                case "11111111111":
                    return false;
                case "2222222222":
                    return false;
                case "33333333333":
                    return false;
                case "44444444444":
                    return false;
                case "55555555555":
                    return false;
                case "66666666666":
                    return false;
                case "77777777777":
                    return false;
                case "88888888888":
                    return false;
                case "99999999999":
                    return false;
            }

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", string.Empty).Replace("-", string.Empty);
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static string GeneratePassword(int length = 10)
        {
            char[] senha = new char[length];
            Random randomizer = new Random();

            for (int i = 0; i < length; i++)
            {
                // Índices (range de códigos da tabela ASCII).
                // 0: números -> 48 ~ 57; 
                // 1: maiúsculas -> 65 ~ 90; 
                // 2: minúsculas -> 97 ~ 122;

                // O método Next() da classe Random obtém um valor aleatório no range numérico que lhe é passado.
                // Esse "+1" é apenas para ilustrar que, num range (x, y),
                // o método Next() obtém valores MAIORES OU IGUAIS a x e MENORES que y.
                // Dessa forma é necessário adicionar 1 ao segundo parametro.
                int[] caracteresAleatorios = { randomizer.Next(48, 57 + 1), randomizer.Next(65, 90 + 1), randomizer.Next(97, 122 + 1) };

                // Exemplo do funcionamento do método next:
                // Para se obter um índice de 0 a 2, precisamos de um range 0 ~ 3.

                // O valor inteiro recebido é convertido em char, 
                // obtendo o caractere referente ao código decimal ASCII.
                senha[i] = (char)caracteresAleatorios[randomizer.Next(0, 3)];
            }

            // O array de char agora é transformado em uma string e então retornado.
            return new string(senha);
        }
    }
}
