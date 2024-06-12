namespace DepositCalculator.Models;

public class CapitalCalc(int periods) : BaseCalculator(PaymentCode.Capitalization, periods)
{
    public override double Calculate(int principal, int yearRate)
    {
        double percentSummary = 1;
        foreach (var i in Enumerable.Range( 1, Periods ))
        {
            percentSummary = percentSummary * (100 + (double)yearRate / 12)/100;
            PeriodPayments.Add(principal * (100 + percentSummary)/100);
        }

        return principal * percentSummary;
    }
}

public class MonthlyCalc(int periods) : BaseCalculator(PaymentCode.Monthly, periods)
{
    public override double Calculate(int principal, int yearRate)
    {
        double percentSummary = 0;
        foreach (var i in Enumerable.Range( 1, Periods ))
        {
            var monthPercent = yearRate / 12 ;
            PeriodPayments.Add((double)principal * (100 + monthPercent)/100);
            percentSummary += monthPercent;
        }

        return principal * (100 + percentSummary)/100;
    }
}

public class BaseCalculator : ICalculator
{
    protected readonly int Periods;
    protected readonly PaymentCode PaymentCode;
    public List<double> PeriodPayments { get; set; } = new List<double>();

    public BaseCalculator(PaymentCode paymentCode, int periods)
    {
        PaymentCode = paymentCode;
        Periods = periods;
    }



    public virtual double Calculate(int principal, int rate)
    {
        throw new NotImplementedException();
    }
}

public interface ICalculator
{
    double Calculate(int principal, int rate);
}