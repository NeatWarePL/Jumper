using UnityEngine;

public class InputController : Module
{
    float startingXInputPosition;
    bool down;

    public void OnInputDown()
    {
        startingXInputPosition = Input.mousePosition.x;
        down = true;
    }

    public void OnInputUp()
    {
        down = false;
    }

    private void Update()
    {
        if (down)
        {
            float positionTest = startingXInputPosition - Input.mousePosition.x;
            myEntityTransform.position = new Vector3(myEntityTransform.position.x, myEntityTransform.position.y, myEntityTransform.position.z + positionTest * gameConfig.playerSteeringSensitivity * 0.01f);
            startingXInputPosition = Input.mousePosition.x;
        }
        if (myEntityTransform.position.z < -10)
        {
            myEntityTransform.position = new Vector3(myEntityTransform.position.x, myEntityTransform.position.y, -10);
        }
        if (myEntityTransform.position.z > 60)
        {
            myEntityTransform.position = new Vector3(myEntityTransform.position.x, myEntityTransform.position.y, 60);
        }
    }
}
