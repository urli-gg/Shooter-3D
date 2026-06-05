using UnityEngine;

public class HideInstructions : MonoBehaviour
{
    public GameObject instructions;
    public float timeToHide = 8f;

    void Start()
    {
        Invoke("HideText", timeToHide);
    }

    void HideText()
    {
        instructions.SetActive(false);
    }
}
