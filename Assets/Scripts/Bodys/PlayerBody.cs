using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : Body
{

    private void Start()
    {
        AllSceneServices.SceneServices.GetService<SceneFightService>().PlayerBody = this;
    }


}
