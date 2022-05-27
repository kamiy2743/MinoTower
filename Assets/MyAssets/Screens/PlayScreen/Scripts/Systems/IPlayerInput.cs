using UnityEngine;

namespace MT.Screens.PlayScreen.Systems
{
    public interface IPlayerInput
    {
        bool MoveBlock();
        bool RotateBlock();
        bool DropBlock();
        Vector2 PointerPosition();
    }
}