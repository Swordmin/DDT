using UnityEngine;
using Zenject;

public abstract class Bootstrap : MonoInstaller
{
    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }
}