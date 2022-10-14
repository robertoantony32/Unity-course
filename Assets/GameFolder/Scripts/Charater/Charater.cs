using GameFolder.Scripts.Player.Movement;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Charater : MonoBehaviour
{
    public int life;
    public Transform render;
    private Animator _render;
    private PlayerController player;

    public Transform cam;
    public TextMeshProUGUI heartCountText;

    public AudioClip bossBattleMusic;
    public AudioClip youWin;


    private void Awake()
    {        
        _render = render.GetComponent<Animator>();
    }

    private void Update()
    {
        
        if(life <= 0 && !transform.name.Equals("BossBrain"))
        {
            _render.GetComponent<Animator>().Play("die_animation", -1);
        }

        if (transform.CompareTag("Player"))
        {
            heartCountText.text = "x" + life;

            if (SceneManager.GetActiveScene().name.Equals("BossLevel"))
            {
                cam.GetComponent<Animator>().enabled = false;
                cam.GetComponent<Camera>().orthographicSize = 13.64f;
                cam.position = new Vector3(12.39f, 6.34f, -1);
                cam.parent = null;
                SceneManager.MoveGameObjectToScene(cam.gameObject, SceneManager.GetActiveScene());

                if (GameObject.Find("BossBrain").GetComponent<Charater>().life > 0)
                {

                    if (cam.GetComponent<AudioSource>().clip != bossBattleMusic)
                    {
                        cam.GetComponent<AudioSource>().clip = bossBattleMusic;
                        cam.GetComponent<AudioSource>().Play();
                    }
                }
                else
                {
                    if (cam.GetComponent<AudioSource>().clip != null)
                    {
                        cam.GetComponent<AudioSource>().Stop();
                        cam.GetComponent<AudioSource>().clip = null;
                        cam.GetComponent<AudioSource>().PlayOneShot(youWin);
                    }
                }
            }
            
        }
        

        if (transform.name.Equals("BossBrain"))
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(1.78f, (life * 1.09f / 30f));
            
            if (life <= 0)
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                GameObject.Find("YouWin").GetComponent<GameOver>().enabled = true;
                GameObject.Find("PlayerPivot").GetComponent<PlayerController>().enabled = false;
                GameObject.Find("PlayerPivot").GetComponent<CapsuleCollider2D>().enabled = false;
                GameObject.Find("PlayerPivot").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
        }

        
    }


    public void PlayerDamage(int value)
    {
        life -= value;
        _render.Play("PlayerDamage", 1);
        cam.GetComponent<Animator>().Play("CameraPlayerDamage", -1);
        GetComponent<PlayerController>()._audioSource.PlayOneShot(GetComponent<PlayerController>().damageSound);
    }
}
