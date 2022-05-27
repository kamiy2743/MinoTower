public class ScrollAmount
{
    private static float maxValue = float.MaxValue;
    private static float minValue = 0f;

    public readonly float value;

    public static ScrollAmount Max = new ScrollAmount(maxValue);
    public static ScrollAmount Min = new ScrollAmount(minValue);

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