namespace CathaybkExam.Service;

public static class ExamService
{
    /// <summary>
    ///  計算利率後金額  
    /// </summary>
    /// <param name="amountList"></param>
    /// <param name="interestRate"></param>
    /// <returns></returns>
    public static string[] CalculateByInterestRate(string[] amountList, decimal interestRate = 0.33m)
    {
        var calculatedAmountList = new List<decimal>();
        foreach (var amount in amountList)
        {
            if (decimal.TryParse(amount, out var amountDecimal))
            {
                var interest = amountDecimal * interestRate;
                calculatedAmountList.Add(interest);
            }
            else if (amount == "-")
            {
                calculatedAmountList.Add(0);
            }
        }
        
        var result = calculatedAmountList
            .OrderByDescending(x=> x)
            .Select(x => x.ToString("0.00000")).ToList();
        
        return result.ToArray();
    }
    
    /// <summary>
    /// 遮罩信用卡號
    /// </summary>
    /// <param name="creditCardNumber"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static string MaskTheCreditCardNumber(string creditCardNumber)
    {
        if (creditCardNumber.Length is not (16 or 12))
        {
            throw new ArgumentException("Invalid credit card number");            
        }
        
        var last4Number = creditCardNumber.Substring(creditCardNumber.Length-4, 4);
        var mask = string.Empty;
        for (var i = 0; i < creditCardNumber.Length-4; i++)
        {
            mask += "*";
            if (i % 4 == 3)
            {
                mask += "-";
            }
        }
        
        return mask + last4Number;
    }

    /// <summary>
    /// 泛型轉換成字串
    /// </summary>
    /// <param name="input"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string GenericTypeConvertToString<T>(T input)
    {
        if (input is DateTime)
        {
            return ((DateTime)(object)input).ToString("yyyy/MM/dd");
        }
        else
        {
            return input.ToString();
        }
    }
}