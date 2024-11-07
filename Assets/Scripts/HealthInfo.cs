using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthInfo : MonoBehaviour
{
    public GameObject healthInfoPanel;
    public TextMeshProUGUI muscleText;
    public TextMeshProUGUI weightText;
    public TextMeshProUGUI enduranceText;
    private PlayerController playerController;

    private int muscle = 15;
    private int weight = 60;
    private int endurance = 15;

    private bool isPanelVisible = false;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        healthInfoPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleHealthInfoPanel();
        }
    }

    void ToggleHealthInfoPanel()
    {
        isPanelVisible = !isPanelVisible;
        healthInfoPanel.SetActive(isPanelVisible);

        if (isPanelVisible)
        {
            UpdateHealthInfo();
            playerController.LockControls();
        }
        else
        {
            playerController.UnlockControls();
        }
    }

    void UpdateHealthInfo()
    {
        muscleText.text = $"Muscle: {muscle} ({GetMuscleCondition(muscle)})";
        weightText.text = $"Weight: {weight} ({GetWeightCondition(weight)})";
        enduranceText.text = $"Εndurance: {endurance} ({GetEnduranceCondition(endurance)})";
    }

    string GetMuscleCondition(int value)
    {
        if (value >= 0 && value <= 25) return "Bad";
        else if (value > 25 && value <= 50) return "Good";
        else if (value > 50 && value <= 75) return "Grear";
        else return "Excessive";
    }

    string GetWeightCondition(int value)
    {
        if (value >= 0 && value <= 25) return "Very Poor";
        else if (value > 25 && value <= 50) return "Bad";
        else if (value > 50 && value <= 75) return "Great";
        else return "Obese";
    }

    string GetEnduranceCondition(int value)
    {
        if (value >= 0 && value <= 25) return "Bad";
        else if (value > 25 && value <= 50) return "Good";
        else if (value > 50 && value <= 75) return "Great";
        else return "Amazing";
    }

    public void Change()
    {
        muscle += 5;
        weight -= 1;
        endurance += 5;
        UpdateHealthInfo();
    }
}
