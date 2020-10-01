namespace LGPD
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [SensitiveData]                     // SensitiveData
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        [SensitiveData]                     // SensitiveData
        public string CPF { get; set; }

        public int EmpresaId { get; set; }

        public virtual Empresa EmpresaNavigation { get; set; }
    }
}