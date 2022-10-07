
using System.Net.Mime;
using GameFolder.Scripts.Player.Movement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Charater : MonoBehaviour
{
    public int life;
    public Transform render;
    private Animator _render;
    public Transform cam;


    private void Awake()
    {        
        _render = render.GetComponent<Animator>();
    }

    private void Update()
    {
        if (life <= 0)
        {
            _render.Play("die_animation", -1);
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
