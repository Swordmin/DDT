using System;
using System.Collections.Generic;
using UnityEngine;

public class BootstrapScene : Bootstrap
{
    public static BootstrapScene Bootstrap;
    

    private void Awake()
    {
        if (!Bootstrap)
            Bootstrap = this;
    }

}