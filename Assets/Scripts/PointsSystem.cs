using TMPro;
using UnityEngine;

public class PointsSystem : MonoBehaviour
{
    public int points = 0;
    public TextMeshProUGUI pointsText;

    void Start()
    {
        UpdateUI();
    }

    public void AddPoints(int amount)
    {
        points += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        pointsText.text = "Puntos: " + points;
    }
}
