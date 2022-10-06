using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    private int lifeChange;
    public Slider lifeBar;

    private void Start()
    {
        lifeChange = GetComponent<Charater>().life;
        lifeBar.maxValue = lifeChange;
        lifeBar.value = lifeChange;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeChange != GetComponent<Charater>().life)
        {
            lifeChange  = GetComponent<Charater>().life;
            GetComponent<Charater>().render.GetComponent<Animator>().Play("DoorDamage", -1);
            lifeBar.value = lifeChange;
        }

        if (GetComponent<Charater>().life <= 0)
        {
            Destroy(transform.gameObject);
        }

    }
}
