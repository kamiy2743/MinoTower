namespace MT
{
    public interface IScreen
    {
        ScreenType Type { get; }
        void Open();
        void CloseAsync();
    }
}
