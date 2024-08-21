using System;

namespace conta.models
{
    public class ContaBancaria
    {
        // Atributos
        private int numero;
        private string titular;
        private decimal saldo;
        private readonly object lockObject = new object();

        // Construtor com validação
        public ContaBancaria
        (
            int numero,
            string titular,
            decimal saldoInicial
        )
        {
            if (numero < 0)
            {
                throw new ArgumentException("Número da conta não pode ser negativo.");
            }

            this.numero = numero;
            this.titular = titular;
            this.saldo = saldoInicial;
        }

        // Propriedade para o número da conta
        public int Numero
        {
            get { return numero; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Número da conta não pode ser negativo.");
                }
                numero = value;
            }
        }

        // Propriedade para o titular da conta
        public string Titular
        {
            get { return titular; }
            set { titular = value; }
        }

        // Propriedade para o saldo da conta
        public decimal Saldo
        {
            get
            {
                lock (lockObject)
                {
                    return saldo;
                }
            }
        }

        // Método para depositar valor na conta
        public void Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Valor do depósito deve ser positivo.");
            }

            lock (lockObject)
            {
                saldo += valor;
                Console.WriteLine($"Depositado: {valor}. Saldo atual: {saldo}");
            }
        }

        // Método para sacar valor da conta
        public void Sacar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Valor do saque deve ser positivo.");
            }

            lock (lockObject)
            {
                if (saldo >= valor)
                {
                    saldo -= valor; // Correção: Deveria subtrair o valor do saldo
                    Console.WriteLine($"Sacado: {valor}. Saldo atual: {saldo}");
                }
                else
                {
                    Console.WriteLine($"Tentativa de saque de {valor} falhou. Saldo atual: {saldo}");
                }
            }
        }

        // Método ToString para representar a conta como uma string
        public override string ToString()
        {
            return $"Número da Conta: {numero}, Titular: {titular}, Saldo: {saldo:C}";
        }
    }
}
