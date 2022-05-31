namespace MT.Screens
{
    public interface IScreen
    {
        ScreenType Type { get; }
        bool IsOpened { get; }
        bool IsActive { get; }
        void Open();
        void Close();
    }
}
