using conta.models;
using System;

public class ThreadEsperta
{
    private readonly ContaBancaria conta;

    public ThreadEsperta(ContaBancaria conta)
    {
        this.conta = conta;
    }

    public void Run()
    {
        while (true)
        {
            Thread.Sleep(6000);
            lock (conta)
            {
                if (conta.Saldo >= 50)
                {
                    conta.Sacar(50);
                }
                else
                {
                    Console.WriteLine("Saldo insuficiente para saque de 50");
                }
            }
        }

    }
}
