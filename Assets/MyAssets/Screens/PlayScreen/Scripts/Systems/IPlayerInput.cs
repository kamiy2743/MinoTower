using UnityEngine;
using UnityEngine.Events;

namespace MT.Screens.PlayScreen.Systems
{
    public interface IPlayerInput
    {
        void MoveBlockAddListener(UnityAction call);
        void DropBlockAddListener(UnityAction call);
        Vector2 PointerPosition();
    }
}