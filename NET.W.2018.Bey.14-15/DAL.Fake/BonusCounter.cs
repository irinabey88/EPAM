using DAL.Interface.Interfaces;

namespace ConsolePL
{
    public class BonusCounter : IBonusCounter
    {
        public int CalcBonus(decimal amount, int type)
        {
            return (int)amount / (type * 10);
        }
    }
}