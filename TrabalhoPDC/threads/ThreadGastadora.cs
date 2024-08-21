using System;
using System.Threading;
using conta.models;


public class ThreadGastadora
{
    private readonly ContaBancaria conta;

    public ThreadGastadora(ContaBancaria conta)
    {
        this.conta = conta;
    }

    public void Run()
    {
        while (true) // A thread deve rodar indefinidamente até o programa ser encerrado
        {
            Thread.Sleep(3000); // Espera 3000 milissegundos (3 segundos)

            lock (conta)
            {
                if (conta.Saldo >= 10) // Verifica se há saldo suficiente
                {
                    conta.Sacar(10); // Retira 10 reais
                }
                else
                {
                    Console.WriteLine("Saldo insuficiente para saque de 10 reais.");
                }
            }
        }
    }
}
