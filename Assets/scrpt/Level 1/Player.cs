using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator _animator;
    private float movement = 0f;
    private int _score = 0;
    public float currentHealth { get; private set;}
    public GameOver over;
    [SerializeField] private AudioSource point;
    [SerializeField] private float staringHealth;
    [SerializeField] private float speed;
    [SerializeField] private float gravity;
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void GameOver()
    {
        over.Setup(_score);
    }
    
    void Start()
    {
        currentHealth = staringHealth;
        body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //pergerakan yang kami gunakan menggunakan body velocity
        //dan untuk menggerakan kekanan dan kekiri (x/horizontal) kami menggukan input.getaxis("horizontal")
        //dan untuk kecepatan gerakan horizonInput di kali speed yang sudah ditentukan di serializefield
        // alasan kami menggunakan input.getAxis karena ketika kami menggunakan input.system,
        // gerak lompatnya tidak sesuai dengna apa yang kami konsepkan
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
       _animator.SetBool("run", horizontalInput !=0);

       //agar spirte mengikuti pergerakan contoller dari player karena itu kami menggunakan tranform.localscale
       // untuk mengatur posisi dari sprite agar sesuai dengan controller
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }

        //untuk kontroler lompat kami menggunakan Input.Getkey, dengan spasi sebagai tombol untuk melompat
        // dimana Input.Getkey memiliki 2 values True kitika player menekan spasi, False ketika player tidak menekan spasi
        if (Input.GetKey(KeyCode.Space))
        {
            //sekarang ketika menekan spasi kami perlu mendefinisikan apa yang terjadi setelahnya
            //dan yang kami inginkan ketika menekan spasi adalah untuk merubah body.velocity
            //hanya saja yang kami rubah disini adalah y-axis
            //didalam vector 2 kami menambahkan velocity.x agar dapat mempertahankan cepat gerak dari horizontal input
            //terakhir velovity.x dikalikan dengan gravity untuk kami dapat mengatur cepat lompatnya
            //dan ini juga mengatur pergerakan gravitasi dari player kami
            body.velocity = new Vector2(body.velocity.x,gravity);
        }
    }

    public void TakeDemage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, staringHealth);

        if (currentHealth > 0)
        {
            _animator.SetTrigger("damage");
        }
        else
        {
            Time.timeScale = 0;
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            _score++;
            _scoreText.text = $": {_score}";
            point.Play();
        }

        if (other.CompareTag("Portal"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
        if (other.CompareTag("portal2"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
        }
        if (other.CompareTag("PortalHard"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
    }
    
    public void OnMove(InputValue value)
    {
        movement = value.Get<float>();
    }
}