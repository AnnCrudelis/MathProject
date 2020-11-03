using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class UpdateJoystickLabels : MonoBehaviour
{
    public SingleJoystick leftJoystick;
    public SingleJoystick rightJoystick;

    public Text leftText;
    public Text rightText;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        Vector3 leftJoystickValues = leftJoystick.GetInputDirection();
        Vector3 rightJoystickValues = rightJoystick.GetInputDirection();

        leftText.text = leftJoystickValues.ToString();
        rightText.text = rightJoystickValues.ToString();
    }
}
