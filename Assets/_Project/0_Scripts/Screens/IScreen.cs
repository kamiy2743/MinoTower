using Cysharp.Threading.Tasks;

namespace MT
{
    public interface IScreen
    {
        ScreenType Type { get; }
        UniTask OpenAsync(float duration);
        UniTask CloseAsync(float duration);
    }
}
