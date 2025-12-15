using UnityEngine;
using TMPro;

public class HUDcontroller : MonoBehaviour
{
    public static HUDcontroller instance;

    private void Awake()
    {
        instance = this;

    }
    [SerializeField] TMP_Text interactiontext;

    public void EnableInteractionText(string text)
    {
        interactiontext.text = text + "(E)";
        interactiontext.gameObject.SetActive(true);
    }
    public void DisableInteractionText()
    {
        interactiontext.gameObject.SetActive(false);
    }
}
