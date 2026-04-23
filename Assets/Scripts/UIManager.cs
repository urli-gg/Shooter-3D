using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI waveText;
    public WaveManager waveManager;

    void Update()
    {
        waveText.text = "Ronda " + waveManager.waveNumber;
    }
}
