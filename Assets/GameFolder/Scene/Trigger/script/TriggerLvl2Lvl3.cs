using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLvl2Lvl3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SceneManager.LoadScene("BossLevel");
        }
    }
}
