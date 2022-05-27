namespace MT.Screens
{
    public interface IScreen
    {
        void Open();
        void Close();
        bool isOpened { get; }
        bool isActive { get; }
    }
}
