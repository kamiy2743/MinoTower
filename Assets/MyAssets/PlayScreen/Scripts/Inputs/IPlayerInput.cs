using UnityEngine;

namespace MT.PlayScreen.Inputs
{
    public interface IPlayerInput
    {
        bool MoveBlock();
        bool RotateBlock();
        bool DropBlock();
        Vector2 PointerPosition();
    }
}