namespace DAL.Interface.Interfaces
{
    public interface IBonusCounter
    {
        int CalcBonus(decimal amount, int type);
    }
}