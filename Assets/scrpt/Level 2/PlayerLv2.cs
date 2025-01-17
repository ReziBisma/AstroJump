using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerLv2 : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator _animator;
    private float movement = 0f;
    private int _score = 0;
    public float currentHealth2 { get; private set;}
    public GameOverLv2 over;
    public GameOverLv2 trans;
    [SerializeField] private float staringHealth2;
    [SerializeField] private float speed;
    [SerializeField] private float gravity;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private AudioSource getdiamond;
    [SerializeField] private AudioSource damage;
    [SerializeField] private AudioSource bgm;

    public void GameOverLv2()
    {
        over.Setup(_score);
    }

    public void GameOverLv22()
    {
        trans.Setup(_score);
    }
    
    void Start()
    {
        getdiamond.Stop();
        damage.Stop();
        currentHealth2 = staringHealth2;
        body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
       _animator.SetBool("run", horizontalInput !=0);

        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x,gravity);
        }
    }

    public void TakeDemage(float _damage)
    {
        currentHealth2 = Mathf.Clamp(currentHealth2 - _damage, 0, staringHealth2);

        if (currentHealth2 > 0)
        {
            _animator.SetTrigger("damage");
            damage.Play();
        }
        else
        {
             _animator.SetTrigger("death");
            Time.timeScale = 0;
            GameOverLv2();
            bgm.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            _score++;
            _scoreText.text = $": {_score}";
            getdiamond.Play();
        }

        if (other.CompareTag("Portal"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
        if (other.CompareTag("portal2"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
        }
        if (other.CompareTag("endportal"))
        {
            Time.timeScale = 0;
            GameOverLv22();
            bgm.Stop();
        }

        if (other.CompareTag("endportal1"))
        {
            SceneManager.LoadScene("Credit");
            bgm.Stop();
        }

    }
    
    public void OnMove(InputValue value)
    {
        movement = value.Get<float>();
    }
}
