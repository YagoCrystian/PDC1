using System;
using System.Threading;
using conta.models;

public class ThreadEconomica
{
    private readonly ContaBancaria conta;

    public ThreadEconomica(ContaBancaria conta)
    {
        this.conta = conta;
    }

    public void Run()
    {
        while (true) // A thread deve rodar indefinidamente até o programa ser encerrado
        {
            Thread.Sleep(12000); // Espera 12000 milissegundos (12 segundos)

            lock (conta)
            {
                if (conta.Saldo >= 5) // Verifica se há saldo suficiente
                {
                    conta.Sacar(5); // Retira 5 reais
                }
                else
                {
                    Console.WriteLine("Saldo insuficiente para saque de 5 reais.");
                }
            }
        }
    }
}
