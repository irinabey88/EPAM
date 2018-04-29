namespace BankAccounts.Common.Interfaces.BonusCounter
{
    public interface IBonusCounter
    {
        int CalcBonus(decimal amount, int type);
    }
}