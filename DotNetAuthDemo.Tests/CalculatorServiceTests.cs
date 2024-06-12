namespace DotNetAuthDemo.Tests;

public class CalculatorServiceTests
{
    [Fact]
    public void Should_Input_Two_Ints_And_Add_Them()
    {
          //given 
          var calService = new CalculatorService();
          var randomInt1 = 2;
          var randomInt2 = 5;
          var expectedValue = randomInt1 + randomInt2;

          //when

          var actualValue = calService.Add(randomInt1 ,randomInt2);
          //then
          Assert.Equal(expectedValue,actualValue);
    }
    
    [Fact]
    public void Should_Input_Two_Doubles_And_Add_Them()
    {
        //given 
        var calService = new CalculatorService();
        var randomInt1 = 2.3;
        var randomInt2 = 5.6;
        var expectedValue = randomInt1 + randomInt2+8;

        //when

        var actualValue = calService.Add(randomInt1 ,randomInt2)+8;
        //then
        Assert.Equal(expectedValue,actualValue,1);
    }
    
}