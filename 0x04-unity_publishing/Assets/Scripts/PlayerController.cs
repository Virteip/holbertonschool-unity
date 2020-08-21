using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public int health = 5;
    public float speed = 200;
    public Rigidbody rb;
    private int score = 0;
    public Text scoreText;
    public Text healthText;
    public Text victoryText;
    public Text defeatText;
    public Image vicdefBG;

    // Check health
    void Update()
    {
        if (health == 0)
        {
            vicdefBG.color = Color.red;
            victoryText.color = Color.white;
            victoryText.text = "Game Over!";
            vicdefBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
        }

        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }

        SetScoreText();
        SetHealthText();
    }

    // Move with wasd
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(0, 0, speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(0, 0, -speed * Time.deltaTime);
    }


    // Trigger Actions When Tag Is Touched
    void OnTriggerEnter(Collider other)
    {   
        if (other.tag == "Pickup")
        {
            score++;
            other.gameObject.SetActive(false);
        }

        if (other.tag == "Trap")
        {
            health--;
        }

        if (other.tag == "Goal")
        {
            vicdefBG.color = Color.green;
            victoryText.color = Color.black;
            victoryText.text = "You Win!";
            vicdefBG.gameObject.SetActive(true);
        }
    }

    //Change score dynamically
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    void SetBannerGameOver()
    {
        vicdefBG.color = Color.green;
        victoryText.color = Color.black;
        victoryText.text = "You Win!";
        vicdefBG.gameObject.SetActive(true);
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new  WaitForSeconds(seconds);
        SceneManager.LoadScene("Maze", LoadSceneMode.Single);
        score = 0;
        health = 5;
    }
}
