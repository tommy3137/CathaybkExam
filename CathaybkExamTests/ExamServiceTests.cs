using CathaybkExam.Service;

namespace CathaybkExamTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CalculateByInterestRateTest_若字串有Dash符號_Dash符號應回傳0()
    {
        // Arrange
        var amountList = new string[] { "1.2", "1.4", "0.2", "-", "-0.005" };

        var expected = new string[] { "0.46200", "0.39600", "0.06600", "0.00000", "-0.00165"};
        
        // Act
        var result = ExamService.CalculateByInterestRate(amountList);
        
        // Assert
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void CalculateByInterestRateTest_若字串有非數字與Dash的符號_應不回傳該筆資料()
    {
        // Arrange
        var amountList = new string[] { "1.2", "1.4", "abc", "-", "-0.005" };
        
        var expected = new string[] { "0.46200", "0.39600", "0.00000", "-0.00165"};

        // Act
        var result = ExamService.CalculateByInterestRate(amountList);
        
        // Assert
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void MaskTheCreditCardNumberTest_若字串長度不是12或16_應拋出ArgumentException()
    {
        // Arrange
        var creditCardNumber = "1111111111";
        
        // Act
        // Assert
        Assert.Throws<ArgumentException>(() => ExamService.MaskTheCreditCardNumber(creditCardNumber));
    }
    
    [Test]
    public void MaskTheCreditCardNumberTest_若字串長度是12_應回傳遮罩後的字串()
    {
        // Arrange
        var creditCardNumber = "446599876123";
        
        var expected = "****-****-6123";
        
        // Act
        var result = ExamService.MaskTheCreditCardNumber(creditCardNumber);
        
        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void MaskTheCreditCardNumberTest_若字串長度是16_應回傳遮罩後的字串()
    {
        // Arrange
        var creditCardNumber = "3758634830869288";
        
        var expected = "****-****-****-9288";
        
        // Act
        var result = ExamService.MaskTheCreditCardNumber(creditCardNumber);
        
        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void GenericTypeConvertToStringTest_若傳入的型別是DateTime_應回傳yyyyMMdd並以左斜線分隔的字串()
    {
        // Arrange
        var value = new DateTime(2023, 10, 13, 10,5, 30);
        
        var expected = "2023/10/13";
        
        // Act
        var result = ExamService.GenericTypeConvertToString(value);
        
        // Assert
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void GenericTypeConvertToStringTest_若傳入的型別是int_應回傳int的字串()
    {
        // Arrange
        var value = 123;
        
        var expected = "123";
        
        // Act
        var result = ExamService.GenericTypeConvertToString(value);
        
        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void GenericTypeConvertToStringTest_若傳入的型別是decimal_應回傳decimal的字串()
    {
        // Arrange
        var value = 123.456m;
        
        var expected = "123.456";
        
        // Act
        var result = ExamService.GenericTypeConvertToString(value);
        
        // Assert
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void GenericTypeConvertToStringTest_若傳入的型別是string_應回傳string的字串()
    {
        // Arrange
        var value = "數數發";
        
        var expected = "數數發";
        
        // Act
        var result = ExamService.GenericTypeConvertToString(value);
        
        // Assert
        Assert.AreEqual(expected, result);
    }
}