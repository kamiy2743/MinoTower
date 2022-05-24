using UnityEngine;

namespace MT.Inputs
{
    public interface IPlayerInput
    {
        bool MoveBlock();
        bool RotateBlock();
        bool DropBlock();
        Vector2 PointerPosition();
    }
}