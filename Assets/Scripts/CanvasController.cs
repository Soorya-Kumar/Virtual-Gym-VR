using UnityEngine;

public class CanvasController : MonoBehaviour
{
    private Canvas Canvas;
    private PlayerController playerController;

    void Start()
    {
        Canvas = GetComponent<Canvas>();
        if (Canvas != null)
        {
            Canvas.enabled = false;
        }
        else
        {
            Debug.LogWarning("Canvas component not found on " + gameObject.name);
        }

        playerController = FindObjectOfType<PlayerController>();

        if (playerController == null)
        {
            Debug.LogError("PlayerController not found in the scene.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Canvas != null)
            {
                Canvas.enabled = !Canvas.enabled;
                if (Canvas.enabled)
                {
                    playerController.LockControls();
                }
                else
                {
                    playerController.UnlockControls();
                }
            }
        }
    }
}
