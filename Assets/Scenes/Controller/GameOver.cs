using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void Update()
    {
        GetComponent<CanvasGroup>().alpha += Time.deltaTime * 0.5f;
    }
}
