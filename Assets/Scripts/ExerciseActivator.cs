using UnityEngine;

public class ExerciseActivator : MonoBehaviour
{
    public Exercise item;
    private ExerciseManager exerciseManager; 
    private bool isPlayerNearby = false; 

    void Start()
    {
        exerciseManager = FindObjectOfType<ExerciseManager>();
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E) && !exerciseManager.itemPanel.activeSelf)
        {
            ActivateItem();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            exerciseManager.HideItemPanel();
        }
    }

    void ActivateItem()
    {
        exerciseManager.UpdateItemUI(item);
    }
}
