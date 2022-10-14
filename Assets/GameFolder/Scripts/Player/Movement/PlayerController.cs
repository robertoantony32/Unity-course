using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace GameFolder.Scripts.Player.Movement
{
   public class PlayerController : MonoBehaviour
   {
      private Rigidbody2D _rb;
      private float _dir;
      public AudioSource _audioSource;
      public AudioClip attack1Sound;
      public AudioClip attack2Sound;
      public AudioClip damageSound;
      public AudioClip dashSound;
      
      
      public Transform floorCollider;
      public Transform playerRender;
      public Transform gameOverScreen;
      public Transform pauseScreen;
      

      public int comboNum;
      private float comboTime;
      public float dashTime;
      public float speed;
      public float dashForce;
      public float jumpForce;

      public LayerMask floorLayer;
      public Animator _animator;
      private Charater _charater;
      public TextMeshProUGUI heartCountText;

      public string currentLevel;
      
      private void Awake()
      {
         _audioSource = GetComponent<AudioSource>();
         floorCollider.GetComponent<FloorCollider>();
         _animator = playerRender.GetComponent<Animator>();
         _charater = GetComponent<Charater>();

         currentLevel = SceneManager.GetActiveScene().name;
         
         DontDestroyOnLoad(transform.gameObject);

         TryGetComponent(out _rb);
      }
      private void Update()
      {
         if (!currentLevel.Equals(SceneManager.GetActiveScene().name))
         {
            currentLevel = SceneManager.GetActiveScene().name;
            transform.position = GameObject.Find("Spawn").transform.position;
         }
         
         
         heartCountText.text = "x" + _charater.life;

         if (_charater.life <= 0)
         {
            gameOverScreen.GetComponent<GameOver>().enabled = true;
            GetComponent<Rigidbody2D>().simulated = false;
            enabled = false;
         }


         if (Input.GetButtonDown("Cancel"))
         {
            pauseScreen.GetComponent<Pause>().enabled = !pauseScreen.GetComponent<Pause>().enabled;
         }

         dashTime += Time.deltaTime;
         if (Input.GetButtonDown("Fire2") && dashTime > 1)
         {
            _audioSource.PlayOneShot(dashSound, 0.5f);
            
            dashTime = 0;
            _animator.Play("dash_animation", -1);
            _rb.velocity = Vector2.zero;
            _rb.gravityScale = 0;
            _rb.AddForce(new Vector2(playerRender.localScale.x * dashForce,0));
            Invoke("RestoreGravityScale", 0.5f);
         }
         

         comboTime += Time.deltaTime;
         if (Input.GetKeyDown(KeyCode.Z) && comboTime > 0.3f)
         {
            comboNum++;
            if (comboNum > 2)
            {
               comboNum = 1;
            }
            
            
            comboTime = 0;
            _animator.Play("Attack" + comboNum, -1);

            switch (comboNum)
            {
               case 1:
                  _audioSource.PlayOneShot(attack1Sound, 0.5f);
                  break;
               case 2:
                  _audioSource.PlayOneShot(attack2Sound, 0.5f);
                  break;
            }
         }

         if (comboTime >= 1)
         {
            comboNum = 0;
         }

         bool canJump = Physics2D.OverlapCircle(floorCollider.position, 0.5f, floorLayer);
         if (Input.GetButtonDown("Jump") && canJump)
         {
            _animator.Play("jump_animation", -1);
            _rb.velocity = Vector2.zero;
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            //_rb.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
         }

         _dir = Input.GetAxisRaw("Horizontal");

         if (_dir != 0)
         {
            playerRender.localScale = new Vector3(_dir, 1, 1);
            _animator.SetBool("PlayerRun", true);
         }
         else
         {
            _animator.SetBool("PlayerRun", false);
         }
         
      }

      private void FixedUpdate()
      {
         if (dashTime > 0.5f)
         {
            _rb.velocity = new Vector2(speed * _dir, _rb.velocity.y);
         }
      
      }

      public void DestroyPlayer()
      {
         Destroy(transform.gameObject);
      }

      void RestoreGravityScale()
      {
         _rb.gravityScale = 6;
      }
      
   }
}
