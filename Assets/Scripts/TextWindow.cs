using UnityEngine;
using TMPro;

public class TextWindow : MonoBehaviour
{
    public void UpdateText(int count)
    {
        this.GetComponent<TextMeshProUGUI>().text = $"{count} / 30";
    }
}
