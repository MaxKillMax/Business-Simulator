using UnityEngine;
using UnityEngine.Events;

public abstract class Window : MonoBehaviour
{
    public UnityEvent OnStateChanged { get; private set; } = new();

    [SerializeField] private bool _openOnInitialize;

    public bool State { get; private set; }

    public virtual void Initialize()
    {
        SetState(_openOnInitialize);
    }

    public virtual void SetState(bool state)
    {
        State = state;
        gameObject.SetActive(state);
        OnStateChanged?.Invoke();
    }
}
