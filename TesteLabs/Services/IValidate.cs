namespace TesteLabs.Services
{
    public interface IValidate
    {
        public bool ValidaCnpj(string cnpj);
        public bool ValidaCpf(string cpf);
        public bool ValidaEmail(string email);
    }
}
