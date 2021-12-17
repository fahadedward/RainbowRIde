using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 moveDirection;
    public float gravityScale;
    private GameObject playerObj;
    public Rigidbody rb;
    float speedIncrease;
    int health = 3;
    [SerializeField]
    Text healthText;
    [SerializeField]
    Text scoreText;
    int score;
    int highscore;
    [SerializeField]
    Text highscoreText;

    [SerializeField]
    public int Health
    {
        get { return health; }
    }
    [SerializeField]
    AudioSource[] sounds;
    public int Highscore
    {
        get { return highscore; }
    }
    public float SpeedIncrease
    {
        get { return speedIncrease; }
    }

    private void Awake()
    {
        // grabs the current highscore and updates it when the game is started 
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        highscoreText.text = "Highscore: " + highscore.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        //audioFile = playerObj.GetComponent<Audio>();
        //isJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (score > highscore) 
        {
            // sets the new highscore to the current score if we beat the highscore
            PlayerPrefs.SetInt("Highscore", score);
            // updates score if we beat the score in game
            highscoreText.text = "Highscore: " + score.ToString();
        }
        speedIncrease += Time.deltaTime;

        if (speedIncrease >= 30)
        {
            moveSpeed++;
            speedIncrease = 0f;
        }
        // print(speedIncrease);
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * 4, moveDirection.y);

        healthText.text = "Health: " + health.ToString();
        scoreText.text = "Score: " + score.ToString();
    }

    private void FixedUpdate()
    {
        if (transform.position.x > 1.877f)
        {
            transform.position = new Vector3(1.82f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -1.6f)
        {
            transform.position = new Vector3(-1.585f, transform.position.y, transform.position.z);
        }
        rb.MovePosition(rb.position + moveDirection * 2 * Time.fixedDeltaTime);
        //rb.MovePosition(rb.position + -transform.up * moveSpeed * Time.fixedDeltaTime);

    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            health--;
            sounds[0].Play();
            //print(health);
            if(health <= 0)
            {
                SceneManager.LoadScene("EndScene");
            }
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            score += 100;
            sounds[1].Play();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Mushroom"))
        {
            score += 2500;
            sounds[2].Play();
            Destroy(other.gameObject);
        }
    }
}

/*  if (controller.isGrounded && moveDirection.y < 0)
  {
      moveDirection.y = -2f;
  }

  //if (Input.GetAxis("Horizontal") > 0 && file.inside == false)
  //{
  //    transform.rotation = Quaternion.Euler(0f, 90f, 0f);
  //}
  //else if (Input.GetAxis("Horizontal") < 0 && file.inside == false)
  //{
  //    transform.rotation = Quaternion.Euler(0f, 270f, 0f);
  //}

  //if (file.inside)
  //{
  //    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
  //}

  if (controller.isGrounded)
  {
      if (Input.GetButtonDown("Jump"))
      {
          moveDirection.y = jumpForce;
      }
  }
  else
  {
      moveDirection.y += (Physics.gravity.y * gravityScale * Time.deltaTime);
  }
  if (controller.enabled == true)
  {
      controller.Move(moveDirection * Time.deltaTime);
  } */
