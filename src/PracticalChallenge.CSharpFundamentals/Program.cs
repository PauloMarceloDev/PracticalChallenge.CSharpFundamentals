using System.Globalization;
using System.Text.RegularExpressions;

// PracticalExercises.PracticalExercise01();
// PracticalExercises.PracticalExercise02();
// PracticalExercises.PracticalExercise03();
// PracticalExercises.PracticalExercise04();
// PracticalExercises.PracticalExercise05();
PracticalExercises.PracticalExercise06();


public static class PracticalExercises
{
    public static string PracticalExercise01()
    {
        /*
         * 1. Crie um programa em que o usuário precisa digitar um nome
         * e uma mensagem de boas vindas personalizada com o nome dele
         * é exibida:  Olá, Welisson! Seja muito bem-vindo!
         */
        Console.Write("Por gentileza, digite seu nome: ");
        var userName = Console.ReadLine();
        if (string.IsNullOrEmpty(userName))
            throw new ApplicationException("User name cannot be empty");
        
        var message = $"Olá, {userName}! Seja muito bem-vindo!";
        Console.WriteLine(message);
        return message;
    }
    
    public static string PracticalExercise02()
    {
        /*
         * 2. Crie um programa que concatene um nome e um sobrenome
         * inseridos pelo usuário e ao final exiba o nome completo.
         */
        Console.Write("Por gentileza, insira seu primeiro nome: ");
        var firstName = Console.ReadLine();
        if (string.IsNullOrEmpty(firstName))
            throw new ApplicationException("First name cannot be empty");
        
        Console.Write("Por gentileza, insira seu sobrenome: ");
        var lastName = Console.ReadLine();
        if (string.IsNullOrEmpty(lastName))
            throw new ApplicationException("Last name cannot be empty");

        var message = $"Seu nome completo é: {firstName} {lastName}";
        Console.WriteLine(message);
        return message;
    }

    public static string PracticalExercise03()
    {
        /*
         * 3. Crie um programa com 2 valores do tipo double já declarados que retorne:
         *  -> A soma entre esses dois números;
         *  -> A subtração entre os dois números;
         *  -> A multiplicação entre os dois números;
         *  -> A divisão entre os dois números (vale uma verificação se o segundo número é 0!);
         *  -> A média entre os dois números.
         */
        Console.Write("Por gentileza, digite o primero numero: ");
        var firstNumber = Console.ReadLine();
        if (string.IsNullOrEmpty(firstNumber) || !double.TryParse(firstNumber, out _))
            throw new ApplicationException("First number cannot be empty and must be a number");
        
        Console.Write("Por gentileza, insira o segundo numero: ");
        var secondNumber = Console.ReadLine();
        if (string.IsNullOrEmpty(secondNumber) || !double.TryParse(secondNumber, out _))
            throw new ApplicationException("Second number cannot be empty and must be a number");
        
        var firstNumberAsDouble = double.Parse(firstNumber);
        var secondNumberAsDouble = double.Parse(secondNumber);
        
        if (secondNumberAsDouble == 0)
            throw new ApplicationException("Second number cannot be zero");

        var sum = firstNumberAsDouble + secondNumberAsDouble;
        var subtract = firstNumberAsDouble - secondNumberAsDouble;
        var multiply = firstNumberAsDouble * secondNumberAsDouble;
        var division = firstNumberAsDouble / secondNumberAsDouble;
        var median = (firstNumberAsDouble + secondNumberAsDouble) / 2;
        var message = $"A soma dos números é: {sum}\n" +
                      $"A subtração dos números é: {subtract}\n" +
                      $"A multiplicação dos números é: {multiply}\n" +
                      $"A divisão dos números é: {division}\n" +
                      $"A média dos números é: {median}";

        Console.WriteLine(message);
        return message;
    }

    public static string PracticalExercise04()
    {
        /*
         * 4. Crie um programa em que o usuário digita uma ou mais palavras
         * e é exibido a quantidade de caracteres que a palavra inserida tem.
         */

        Console.Write("Digite uma palavra ou frase para saber quantos caracteres existem: ");
        var userInput = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(userInput))
            throw new ApplicationException("Cannot be empty input");

        var hasSpaces = userInput.Contains(' ');
        if (!hasSpaces)
        {
            var wordLength = userInput.Length;
            var messageWhenIsAWord = $"Sua palavra tem {wordLength} caracteres";
            Console.WriteLine(messageWhenIsAWord);
            return messageWhenIsAWord;
        }

        var phraseLength = userInput.Length;
        var phraseLengthWithoutSpaces = userInput
            .Replace(" ", string.Empty).Length;

        var messageWhenIsAPhrase = $"Sua frase tem {phraseLength} caracteres, ou {phraseLengthWithoutSpaces}" +
                                   " sem contar os espaços";
        Console.WriteLine(messageWhenIsAPhrase);
        return messageWhenIsAPhrase;
    }

    public static bool PracticalExercise05()
    {
        /*
         * 5. Crie um programa em que o usuário precisa digitar a placa de um veículo e o programa
         * verifica se a placa é válida, seguindo o padrão brasileiro válido até 2018:
         *  -> A placa deve ter 7 caracteres alfanuméricos;
         *  -> Os três primeiros caracteres são letras (maiúsculas ou minúsculas);
         *  -> Os quatro últimos caracteres são números;
         *  Ao final, o programa deve exibir Verdadeiro se a placa for válida e Falso caso contrário.
         */
        Console.Write("Validador de placa veicular, digite o valor a verificado: ");
        var userInput = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(userInput))
            throw new ApplicationException("Cannot be empty input");

        var normalizeInput = userInput.Replace("-", string.Empty).ToUpperInvariant();
        const int plateLength = 7;
        if (normalizeInput.Length != plateLength)
        {
            Console.WriteLine("Placa inválida");
            return false;
        }

        const int plateLettersLength = 3;
        const int plateNumbersLength = 4;
        var plateLetters = normalizeInput[..plateLettersLength];
        var plateNumbers = normalizeInput[plateLettersLength..(plateLettersLength + plateNumbersLength)];

        var isValidPlate = plateLetters.All(char.IsLetter) 
               && plateNumbers.All(char.IsNumber);

        Console.WriteLine(!isValidPlate ? "Placa inválida" : "Placa válida");

        return isValidPlate;
    }

    public static string PracticalExercise06()
    {
        /*
         * 6. Crie um programa que solicita ao usuário a exibição da data atual em diferentes formatos:
         *  -> Formato completo (dia da semana, dia do mês, mês, ano, hora, minutos, segundos).
         *  -> Apenas a data no formato "01/03/2024".
         *  -> Apenas a hora no formato de 24 horas.
         *  -> A data com o mês por extenso.
         */
        var menuOptions = new List<Tuple<int, string>>
        {
            new(1, "Formato completo (dia da semana, dia do mês, mês, ano, hora, minutos, segundos)."),
            new(2, "Apenas a data no formato \"01/03/2024\"."),
            new(3, "Apenas a hora no formato de 24 horas."),
            new(4, "A data com o mês por extenso."),
        };
        ShowMenu(menuOptions);
        Console.Write("Digite a sua opcao: ");
        var userInput = Console.ReadLine();
        if (string.IsNullOrEmpty(userInput) || !int.TryParse(userInput, out _))
            throw new ApplicationException("Cannot be empty input and must be a number");

        var userInputAsInteger = int.Parse(userInput);
        var menuOptionOrDefault = menuOptions.SingleOrDefault(menuOption => 
            menuOption.Item1 == userInputAsInteger);
        
        if (menuOptionOrDefault is null)
            throw new ApplicationException("Invalid option");

        var now = DateTime.Now;
        CultureInfo.CurrentCulture = new CultureInfo("pt-BR");
        switch (menuOptionOrDefault.Item1)
        {
            case 1:
                var fullFormat = now.ToString("dddd, dd/MM/yyyy HH:mm:ss");
                Console.WriteLine(fullFormat);
                return fullFormat;
            case 2:
                var onlyDateFormat = now.ToString("dd/MM/yyyy");
                Console.WriteLine(onlyDateFormat);
                return onlyDateFormat;
            case 3:
                var onlyTimeFormat = now.ToString("HH:mm:ss");
                Console.WriteLine(onlyTimeFormat);
                return onlyTimeFormat;
            case 4:
                var month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(now.Month);
                var formattedDate = $"{now.Day} de {month} de {now.Year}";
                Console.WriteLine(formattedDate);
                return formattedDate;
        }

        return string.Empty;
    }

    private static void ShowMenu(List<Tuple<int, string>> menuOptions)
    {
        Console.WriteLine("Selecione um das opçoes abaixo:");
        foreach (var option in menuOptions)
        {
            Console.WriteLine($"[{option.Item1}] - {option.Item2}");
        }
    }
}