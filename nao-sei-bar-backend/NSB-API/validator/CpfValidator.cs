namespace Nao_Sei_Bar_Backend.src.validators
{
    public static class CpfValidator
    {
        public static bool ValidarCpf(string cpf)
        {
            // Remover caracteres não numéricos
            cpf = cpf?.Replace(".", "").Replace("-", "");

            // Verificar se o CPF tem 11 dígitos e se contém apenas números
            if (cpf.Length != 11 || !cpf.All(char.IsDigit))
            {
                return false;
            }

            // Verificar se o CPF é uma sequência de números repetidos (exemplo: 111.111.111-11)
            if (cpf.All(c => c == cpf[0]))
            {
                return false;
            }

            // Calcular os dois dígitos verificadores
            var soma1 = 0;
            var soma2 = 0;
            for (int i = 0; i < 9; i++)
            {
                soma1 += (10 - i) * (cpf[i] - '0');
                soma2 += (11 - i) * (cpf[i] - '0');
            }

            var digito1 = (soma1 * 10) % 11;
            if (digito1 == 10) digito1 = 0;

            var digito2 = (soma2 * 10) % 11;
            if (digito2 == 10) digito2 = 0;

            // Verificar se os dígitos calculados correspondem aos dígitos fornecidos no CPF
            return cpf[9] == (digito1 + '0') && cpf[10] == (digito2 + '0');
        }
    }
}
