using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using UnityEngine.UI;

public class WaitForPlayerActionState : MonoBehaviour, IState
{
    [SerializeField] private Button _playButton;
    [SerializeField] private MT.PlayScreen.States.EnterState _playScreenEnterState;

    void Start()
    {
        gameObject.SetActive(false);
        _playButton.onClick.AddListener(() =>
        {
            Tonext(_playScreenEnterState);
        });
    }

    public void Enter()
    {
        gameObject.SetActive(true);
    }

    private void Tonext(IState nextState)
    {
        gameObject.SetActive(false);
        nextState.Enter();
    }
}
