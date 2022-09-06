using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmbraceSetupUI : MonoBehaviour
{
    public EmbraceSetup setup;
    public Toggle jsonToggle;
    public TMP_InputField writeIntervalField;
    public TMP_InputField memoryIntervalField;
    public TMP_Dropdown directionDropdown;

    public void StartGame()
    {
        setup.useJson = jsonToggle.isOn;
        setup.writeInterval = int.Parse(writeIntervalField.text);
        setup.memoryInterval = int.Parse(memoryIntervalField.text);
        setup.direction = directionDropdown.value;
        setup.StartGame();
    }
}
