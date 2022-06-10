using Cysharp.Threading.Tasks;

namespace MT
{
    public interface IPreInitializeStateAsync
    {
        UniTask Enter();
    }
}