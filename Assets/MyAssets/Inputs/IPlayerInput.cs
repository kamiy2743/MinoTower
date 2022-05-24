namespace MT.Inputs
{
    public interface IPlayerInput
    {
        bool MoveBlock();
        bool RotateBlock();
        bool DropBlock();
    }
}