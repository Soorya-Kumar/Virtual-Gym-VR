using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class getName : MonoBehaviour
{
    private TMP_Text tmpText;

    void Start()
    {

        tmpText = GetComponent<TMP_Text>();
        if (tmpText != null)
        {
            string parentName = transform.parent != null ? transform.parent.name : "No Parent";
            tmpText.text = parentName;
        }
        else
        {
            Debug.LogWarning("TMP_Text component not found on " + gameObject.name);
        }
    }
}
