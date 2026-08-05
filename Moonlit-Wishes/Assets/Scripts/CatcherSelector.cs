using UnityEngine;

public class CatcherSelector : MonoBehaviour
{
    public BoxCollider2D upperCatcher;
    public BoxCollider2D lowerCatcher;

    private void Start()
    {
        ShowLowerCatcher();
    }

    private void Update()
    {
        // Upper-left or upper-right
        if (Input.GetKeyDown(KeyCode.Q) ||
            Input.GetKeyDown(KeyCode.E))
        {
            ShowUpperCatcher();
        }

        // Lower-left or lower-right
        if (Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.D))
        {
            ShowLowerCatcher();
        }
    }

    private void ShowUpperCatcher()
    {
        upperCatcher.enabled = true;
        lowerCatcher.enabled = false;
    }

    private void ShowLowerCatcher()
    {
        upperCatcher.enabled = false;
        lowerCatcher.enabled = true;
    }
}