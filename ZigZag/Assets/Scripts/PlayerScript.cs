using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10;
    public Animator gameOverAnim;
    public LayerMask whatIsGround;
    public Transform contactPoint;
    public GameObject resetButton;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    public TMP_Text scoreText2;
    public TMP_Text scoreNumber;
    public TMP_Text highscoreNumber;
    public Image background;
    private int score;
    private bool isPlaying = false;
    private bool isDead;
    public GameObject ps;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        direction = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGrounded() && isPlaying)
        {
            isDead = true;
            GameOver();
            resetButton.SetActive(true);
            if (transform.childCount > 0) transform.GetChild(0).transform.parent = null;
        }
        //this determines players direction, but doesnt move him
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            isPlaying = true;
            score++;
            scoreText.text = score.ToString();
            if (direction == Vector3.back)
            {
                direction = Vector3.right;
            }
            else
            {
                direction = Vector3.back;
            }
        }
        //this thing moves the player
        float amountToMove = speed * Time.deltaTime;
        transform.Translate(direction * amountToMove);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Point")
        {
            score += 3;
            scoreText.text = score.ToString();
            other.gameObject.SetActive(false);
            Instantiate(ps, transform.position, Quaternion.identity);
        }
    }

    private void GameOver()
    {
        gameOverAnim.SetTrigger("GameOver");
        scoreNumber.text = score.ToString();
        int highscore = PlayerPrefs.GetInt("Highscore", 0);
        if(score > highscore) { 
            PlayerPrefs.SetInt("Highscore", score);
            background.color = new Color32(241,27,191,255);
            scoreText2.color = Color.white;
            highscoreText.color = Color.white;
            scoreNumber.color = Color.white;
            highscoreNumber.color = Color.white;
        }
        highscoreNumber.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    private bool isGrounded()
    {
        Collider[] colliders = Physics.OverlapSphere(contactPoint.position, .5f, whatIsGround);
        for(int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject!= gameObject) return true;
        }
        return false;
    }
}
