using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System.Threading;
using Cysharp.Threading.Tasks;

public class Test : MonoBehaviour
{
    [SerializeField] private float duration;

    private CancellationTokenSource _cts = new CancellationTokenSource();

    [ContextMenu("test")]
    public async void TestMethod()
    {
        try
        {
            await transform.DOMoveX(10, duration).ToUniTask(cancellationToken: _cts.Token);
            Debug.Log("completed");
        }
        catch
        {
            Debug.Log("cansel");
        }
    }

    [ContextMenu("dokill")]
    public void Kill()
    {
        transform.DOKill();
        _cts.Cancel();
    }
}
