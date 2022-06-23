public class PlayerBody : Body
{
    public void Initialized()
    {
        AllSceneServices.SceneServices.GetService<SceneFightService>().PlayerBody = this;
    }
}