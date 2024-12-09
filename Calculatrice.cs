using System;

class Calculatrice
{
    enum Operation
    {
        Plus,
        Moins,
        Multiplication,
        Division
    }

    delegate double OperationDelegate(double a, double b);  

    static void Main (string[] args)
    {
        OperationDelegate addition= (x,y) => x+y;
        OperationDelegate soustraction = (x, y) => x - y;
        OperationDelegate multiplication = (x, y) => x * y;
        OperationDelegate division = (x, y) => y != 0 ? x / y : throw new DivideByZeroException("Division par zéro non autorisée");



        Console.WriteLine("Entrer le premier nombre : ");
        double a = double.Parse(Console.ReadLine());

        Console.WriteLine("Entrer le deuxième nombre : ");
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine("Choisissez l'opération que vous voulez effectuer :");
        string operationInput = Console.ReadLine();


        if (!Enum.TryParse(operationInput, true, out Operation operation))
        {
            Console.WriteLine("Opération Invalide");
            return;
        }

        try
        {
            double result = operation switch
            {
                Operation.Plus => addition(a, b),
                Operation.Moins => soustraction(a, b),
                Operation.Multiplication => multiplication(a, b),
                Operation.Division => division(a, b),



            };
            Console.WriteLine($"Le résultat de l'opération est : {result}");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");

        }

    }
}