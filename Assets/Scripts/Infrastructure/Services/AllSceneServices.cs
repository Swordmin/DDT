using System.Collections.Generic;
using UnityEngine;

public class AllSceneServices : Service
{
    [SerializeField] private List<Service> _services = new List<Service>();

    public static AllSceneServices SceneServices;

    private void Awake()
    {
        if (!SceneServices)
            SceneServices = this;
    }

    private void Start()
    {
        foreach (Service service in _services)
        {
            service.Enter();
        }
    }

    public void RegisterService(Service service)
    {
        _services.Add(service);
    }

    public T GetService<T>() where T : Service
    {
        foreach (Service service in _services)
        {
            if (service as T)
            {
                return (T)service;
            }
        }

        return null;
    }
}