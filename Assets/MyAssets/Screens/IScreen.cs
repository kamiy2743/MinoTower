namespace MT.Screens
{
    public interface IScreen
    {
        ScreenType Type { get; }
        void Open();
        void Close();
    }
}
