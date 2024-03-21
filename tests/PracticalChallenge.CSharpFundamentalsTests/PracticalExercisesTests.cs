using System.Globalization;

namespace PracticalChallenge.CSharpFundamentalsTests;

public class PracticalExercisesTests
{
    [Fact]
    public void PracticalExercise01_ReturnsCorrectMessage()
    {
        // Arrange
        const string userName = "John";
        const string expectedMessage = $"Olá, {userName}! Seja muito bem-vindo!";
        Console.SetIn(new StringReader(userName));

        // Act
        var result = PracticalExercises.PracticalExercise01();

        // Assert
        Assert.Equal(expectedMessage, result);
    }

    [Fact]
    public void PracticalExercise01_ThrowsExceptionWhenUserNameIsEmpty()
    {
        // Arrange
        var input = new StringReader(string.Empty);
        Console.SetIn(input);

        // Act & Assert
        var exception = Assert.Throws<ApplicationException>(PracticalExercises.PracticalExercise01);
        Assert.Equal("User name cannot be empty", exception.Message);
    }
    
    [Fact]
    public void PracticalExercise02_ReturnsCorrectMessage()
    {
        // Arrange
        const string expectedMessage = "Seu nome completo é: John Doe";
        var input = new StringReader("John\nDoe");
        Console.SetIn(input);

        // Act
        var result = PracticalExercises.PracticalExercise02();

        // Assert
        Assert.Equal(expectedMessage, result);
    }

    [Fact]
    public void PracticalExercise02_ThrowsExceptionWhenFirstNameIsEmpty()
    {
        // Arrange
        var input = new StringReader("\nDoe");
        Console.SetIn(input);

        // Act & Assert
        var exception = Assert.Throws<ApplicationException>(PracticalExercises.PracticalExercise02);
        Assert.Equal("First name cannot be empty", exception.Message);
    }

    [Fact]
    public void PracticalExercise02_ThrowsExceptionWhenLastNameIsEmpty()
    {
        // Arrange
        var input = new StringReader("John\n");
        Console.SetIn(input);

        // Act & Assert
        var exception = Assert.Throws<ApplicationException>(PracticalExercises.PracticalExercise02);
        Assert.Equal("Last name cannot be empty", exception.Message);
    }
    
    [Fact]
    public void PracticalExercise03_ReturnsCorrectResults()
    {
        // Arrange
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        const string firstNumber = "10";
        const string secondNumber = "5";
        var input = new StringReader($"{firstNumber}\n{secondNumber}");
        Console.SetIn(input);
        const string expectedMessage = $"A soma dos números é: 15\n" +
                                       $"A subtração dos números é: 5\n" +
                                       $"A multiplicação dos números é: 50\n" +
                                       $"A divisão dos números é: 2\n" +
                                       $"A média dos números é: 7.5";

        // Act
        var result = PracticalExercises.PracticalExercise03();

        // Assert
        Assert.Equal(expectedMessage, result);
    }

    [Fact]
    public void PracticalExercise03_ThrowsExceptionForZeroDivisor()
    {
        // Arrange
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        const string firstNumber = "10";
        const string secondNumber = "0";
        var input = new StringReader($"{firstNumber}\n{secondNumber}");
        Console.SetIn(input);

        // Act & Assert
        var exception = Assert.Throws<ApplicationException>(PracticalExercises.PracticalExercise03);
        Assert.Equal("Second number cannot be zero", exception.Message);
    }

    [Theory]
    [InlineData("", "5", "First number cannot be empty and must be a number")]
    [InlineData("10a", "1", "First number cannot be empty and must be a number")]
    [InlineData("abc", "5", "First number cannot be empty and must be a number")]
    [InlineData("10", "def", "Second number cannot be empty and must be a number")]
    [InlineData("10", "15r", "Second number cannot be empty and must be a number")]
    [InlineData("5", "", "Second number cannot be empty and must be a number")]
    public void PracticalExercise03_ThrowsExceptionForInvalidInput(string firstNumber, string secondNumber, 
        string exceptionMessage)
    {
        // Arange
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        var input = new StringReader($"{firstNumber}\n{secondNumber}");
        Console.SetIn(input);
        
        // Act & Assert
        var exception = Assert.Throws<ApplicationException>(PracticalExercises.PracticalExercise03);
        Assert.Equal(exceptionMessage, exception.Message);
    }
    
    [Fact]
    public void PracticalExercise04_ReturnsCorrectResultForWord()
    {
        // Arrange
        var input = new StringReader("hello");
        Console.SetIn(input);
        var expectedMessage = "Sua palavra tem 5 caracteres";

        // Act
        var result = PracticalExercises.PracticalExercise04();

        // Assert
        Assert.Equal(expectedMessage, result);
    }

    [Fact]
    public void PracticalExercise04_ReturnsCorrectResultForPhrase()
    {
        // Arrange
        var input = new StringReader("hello world");
        Console.SetIn(input);
        var expectedMessage = "Sua frase tem 11 caracteres, ou 10 sem contar os espaços";

        // Act
        var result = PracticalExercises.PracticalExercise04();

        // Assert
        Assert.Equal(expectedMessage, result);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void PracticalExercise04_ThrowsExceptionForEmptyInput(string inputAsString)
    {
        // Arrange
        var input = new StringReader(inputAsString);
        Console.SetIn(input);
        
        // Act & Assert
        var exception = Assert.Throws<ApplicationException>(PracticalExercises.PracticalExercise04);
        Assert.Equal("Cannot be empty input", exception.Message);
    }
    
    [Theory]
    [InlineData("ABC1234", true)]
    [InlineData("abc1234", true)]
    [InlineData("ABC-1234", true)]
    [InlineData("abc-1234", true)]
    [InlineData("ABCD123", false)] // Plate has only 6 characters
    [InlineData("ABC12345", false)] // Plate has more than 7 characters
    [InlineData("1234567", false)] // Plate has only numbers
    [InlineData("ABC-12D4", false)] // Plate has an invalid character
    public void PracticalExercise05_ValidatesPlatesCorrectly(string inputAsString, bool expected)
    {
        // Arrange
        var input = new StringReader(inputAsString);
        Console.SetIn(input);
        
        // Act
        var result = PracticalExercises.PracticalExercise05();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void PracticalExercise05_ThrowsExceptionForEmptyInput()
    {
        // Arrange
        var input = new StringReader("");
        Console.SetIn(input);
        
        // Act & Assert
        var exception = Assert.Throws<ApplicationException>(() => PracticalExercises.PracticalExercise05());
        Assert.Equal("Cannot be empty input", exception.Message);
    }
}