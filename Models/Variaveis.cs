using System;
using System.Formats.Asn1;

public class Variaveis
{
    //Anotações de tipos
    public int userCount;

    //Uma variavel pode ser declarada
    //e nao inicializada
    public int totalCount;

    // CONSTANTES
    // para declarar uma constante
    // utilizamos a palavra-chave CONST
    // No entanto a CONST deve ser inicializada
    // quando declarada
    const int interestRate = 10;

    //o metodo construtor e invocado
    //na inicialização do objeto por meio
    // da palavra reservada new
    // Por regra, o construtor sempre tem
    // o mesmo nome da classe
    public Variaveis()
    {
        totalCount = 0;

        //tipo implícito
        // a palavvra chave var se encarrega
        // de definir o tipo da variável
        // na instrução de atribuição
        var signalStrength = 22;
        var companyName = "ACME";
    }
}