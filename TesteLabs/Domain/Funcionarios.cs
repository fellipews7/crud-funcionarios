using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using TesteLabs.Domain.Enums;

namespace TesteLabs.Domain
{
    public class Funcionarios : IValidatableObject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(45)]
        public string Nome { get; set; }
        [Required]
        [Range(16, 100)]
        public int Idade { get; set; }
        [Required, StringLength(14)]
        public string DocFederal { get; set; }
        [Required]
        public IdentificadorPessoa TipoPessoa { get; set; }
        [Required, StringLength(30)]
		public string Email { get; set; }
		[Required, StringLength(15)]
		public string Telefone { get; set; }
		public byte[]? Imagem { get; set; }
        public ICollection<FuncionariosEnderecos>? Enderecos { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TipoPessoa == (IdentificadorPessoa)1 && !ValidaCnpj(this.DocFederal))
            {
				yield return new
							ValidationResult("CNPJ informado está inválido!",
								new[]
								{ nameof(this.DocFederal) }
							);
            }
			else if(TipoPessoa == (IdentificadorPessoa)0 && !ValidaCpf(this.DocFederal))
            {
				yield return new
							ValidationResult("CPF informado está inválido!",
								new[]
								{ nameof(this.DocFederal) }
							);
			}

			if (!ValidaEmail(this.Email))
			{
				yield return new
							ValidationResult("Email informado está inválido!",
								new[]
								{ nameof(this.DocFederal) }
							);
			}

			if (!Regex.IsMatch(this.Telefone, @"(\(?\d{2}\)?\s)?(\d{4,5}\-\d{4})"))
			{
				yield return new
							ValidationResult("Telefone informado está inválido!",
								new[]
								{ nameof(this.DocFederal) }
							);
			}

		}

        public bool ValidaCnpj (string cnpj)
        {
			int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int soma;
			int resto;
			string digito;
			string tempCnpj;
			cnpj = cnpj.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
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

		public bool ValidaCpf(string cpf)
        {
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
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

		public bool ValidaEmail (string email)
        {
			try
			{
				var addr = new System.Net.Mail.MailAddress(email);
				return addr.Address == email;
			}
			catch
			{
				return false;
			}
		}
    }
}
