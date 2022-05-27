namespace MT.Screens
{
    public interface IScreen
    {
        ScreenType ScreenType { get; }
        bool IsOpened { get; }
        bool IsActive { get; }
        void Open();
        void Close();
    }
}
