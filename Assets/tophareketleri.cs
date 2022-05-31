using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class tophareketleri : MonoBehaviour
{


    public Rigidbody2D top;
    public float xHizi, yHizi;

    public TextMeshProUGUI player1Yazi, player2Yazi, winnerYazisi, finishYazisi;
    int player1Skor, player2Skor;
    public int maxSkor;

    public AudioSource skorSesi, kazanmaSesi;



    void Update()
    {
        player1Yazi.text = player1Skor.ToString();
        player2Yazi.text = player2Skor.ToString();
        if (Time.timeScale == 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D temas)
    {
        if (temas.gameObject.tag == "player1")
        {
            top.velocity = new Vector2(-xHizi, Random.Range(-4f, 4f));
        }

        else if (temas.gameObject.tag == "player2")
        {
            top.velocity = new Vector2(xHizi, Random.Range(-4f, 4f));
        }

        if (temas.gameObject.tag == "ustDuvar")
        {
            top.velocity = new Vector2(top.velocity.x, -yHizi);
        }
        else if (temas.gameObject.tag == "altDuvar")
        {
            top.velocity = new Vector2(top.velocity.x, yHizi);
        }


        if (temas.gameObject.tag == "solDuvar")
        {
            player2Skor++;
            transform.position = new Vector2(-6.19f, 0f);
            skorSesi.Play();
        }

        else if (temas.gameObject.tag == "sagDuvar")
        {
            player1Skor++;
            transform.position = new Vector2(6.19f, 0f);
            skorSesi.Play();
        }

        if (player1Skor == maxSkor)
        {
            winnerYazisi.text = "Player 1 Won !";
            finishYazisi.text = "Tekrar Oynamak Icin Enter'a Bas";
            kazanmaSesi.Play();
            Time.timeScale = 0;

        }
        else if (player2Skor == maxSkor)
        {
            winnerYazisi.text = "PLayer 2 Won !";
            finishYazisi.text = "Tekrar Oynamak Icin Enter'a Bas";
            kazanmaSesi.Play();
            Time.timeScale = 0;
        }

        


    }
}
