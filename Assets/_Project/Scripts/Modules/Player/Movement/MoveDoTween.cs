using DG.Tweening;

public class MoveDoTween : Module
{
    string moveId = "MoveMe";

    private void OnEnable()
    {
        BeatManager.onBeat += ManageOnBeat;
    }

    private void OnDisable()
    {
        BeatManager.onBeat -= ManageOnBeat;
    }

    private void ManageOnBeat(BeatData beatData)
    {
        float newPos = myEntityTransform.position.x + (beatData.GetTimeToFollowingBeat(beatData, 1) * gameConfig.playerSpeedOnDoTween);
        MoveMe(newPos, gameConfig.playerSpeedOnDoTween / gameConfig.playerSpeedOnDoTween * beatData.GetTimeToFollowingBeat(beatData, 1));
    }

    public void MoveMe(float xPos, float time)
    {
        DOTween.Kill(moveId, false);
        myEntityTransform.DOMoveX(xPos, time).SetId(moveId).SetEase(Ease.Linear);
    }
}
