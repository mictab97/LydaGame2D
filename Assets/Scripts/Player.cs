using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _lives = 3;

    private UIManager _uiManager;
    private GameManager _gameManager;
    //private SpawnManger _spawnManager;
    public Animator animator;

    public TextMeshProUGUI countText;
    //public Text countText;
    public Text skullText;

    public float ms = 6;
    private int count;
    private int _score = 0;

    void Start() 
    {
        animator.GetComponent<Animator>();
        count = 0;
        SetCountText ();

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.LogError("There is no UI Manager in the scene");
        }

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("There is no Game Manager in the scene.");
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * ms * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {

            transform.Translate(Vector3.right * ms * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.RightArrow)))
        {
            animator.SetBool("OnWalk", true);
        }else
        {
            animator.SetBool("OnWalk", false);
            animator.SetBool("OnWalk", true);
        }
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    public void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 7f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive (false);
            count = count +1;
            SetCountText ();
        }

        else if (other.gameObject.CompareTag ("Skull"))
        {
            other.gameObject.SetActive (false);
            //count = count +1;
            SetSkullText ();
            Damage();
        }
    }

    void SetSkullText ()
    {
        skullText.text = "damage:" + count.ToString ();
    }

    void SetCountText ()
    {
        countText.text = "bug coin:" + count.ToString ();
    }

    public void Damage()
    {
        //reduce lives by 1
        _lives -= 1;
    
        //check if dead
        // destroy us
        if (_lives < 1)
        {
            //_spawnManager.OnPlayerDeath();
            _gameManager.GameOver();
            Destroy(this.gameObject);
            Time.timeScale = 0f;
        }
        _uiManager.UpdateLives(_lives);
    }

        public void AddScore()
        {
            _score +=1;
            _uiManager.SetScoreText(_score);
        }
}
