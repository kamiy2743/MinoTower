namespace MT.Screens.PlayScreen.Systems
{
    public class ScrollAmount
    {
        private const float maxValue = float.MaxValue;
        private const float minValue = 0f;

        public readonly float value;

        public static readonly ScrollAmount Max = new ScrollAmount(maxValue);
        public static readonly ScrollAmount Min = new ScrollAmount(minValue);

        public ScrollAmount(float scrollAmount)
        {
            if (scrollAmount < minValue)
            {
                value = minValue;
                return;
            }

            if (scrollAmount > maxValue)
            {
                value = maxValue;
                return;
            }

            value = scrollAmount;
        }
    }
}