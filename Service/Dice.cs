namespace PacMan.Service
{
    public class Dice
    {
        private readonly int _minValue = 1;
        private readonly int _maxValue;

        public Dice(int maxValue)
        {
            _maxValue = maxValue;
        }

        public int DiceShooter(Random random)
        {
            int ret = 0;
            for (int a = 1; a < _minValue; a++)
            {
                ret += Launch(random);
            }
            return ret;
        }

        private int Launch(Random random) => random.Next(_minValue, _maxValue + 1);
    }
}