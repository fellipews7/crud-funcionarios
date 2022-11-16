using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using TesteLabs.Domain;
using TesteLabs.Domain.Enums;
using TesteLabs.Repository;

namespace TesteLabs.Services
{
    public class FuncionariosServices : IFuncionariosServices
    {
		private IValidate _validate { get; }

		public FuncionariosServices(IValidate validate)
        {
            _validate = validate;
        }

        public void ValidaFuncionarios(Funcionarios funcionario)
        {
			if (funcionario.TipoPessoa == (IdentificadorPessoa)1 && !_validate.ValidaCnpj(funcionario.DocFederal))
			{
				throw new DomainException("CNPJ informado está inválido!");
			}
			else if (funcionario.TipoPessoa == (IdentificadorPessoa)0 && !_validate.ValidaCpf(funcionario.DocFederal))
			{
				throw new DomainException("CPF informado está inválido!");
			}

			if (!_validate.ValidaEmail(funcionario.Email))
			{
				throw new DomainException("Email informado está inválido!");
			}

			if (!Regex.IsMatch(funcionario.Telefone, @"(\(?\d{2}\)?\s)?(\d{4,5}\-\d{4})"))
			{
				throw new DomainException("Telefone informado está inválido!");
			}
			
        }

    }
}
