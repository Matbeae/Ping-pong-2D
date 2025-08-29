using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    private float speed;
    public Vector2 direction;
    public float speedUp;
    public Player1 player1;
    public Player2 player2;
    public int scorecounter1;
    public int scorecounter2;
    public TextMeshProUGUI Score1;
    public TextMeshProUGUI Score2;
    public TextMeshProUGUI TimerSeconds;
    public TextMeshProUGUI TimerMinuts;
    public float timerseconds;
    public float timerminuts;
    public AudioSource ReboundWall;
    public AudioSource ReboundPlayers;
    public GameObject Congratulation;
    public GameObject CongratulationInfo;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        timerseconds = 0.0f;
        timerminuts = 0.0f;
        ReboundWall.Stop();
        ReboundPlayers.Stop();
        float x = Random.Range(-1.0f, 1.0f);
        float y = Random.Range(-1.0f, 1.0f);
        transform.position = Vector2.zero;
        speed = 4.7f;
        direction = new Vector2(x, y);
        if (Mathf.Round(x) == 0.0f || Mathf.Round(x) == 0.1f || Mathf.Round(x) == -0.1f)
            Start();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {
            ReboundPlayers.Play();
            direction.x = -direction.x;
            speed *= speedUp;
        }
        if (collision.gameObject.name == "Walls" || collision.gameObject.name == "Walls (1)")
        {
            ReboundWall.Play();
            direction.y = -direction.y;
        }
        if (Input.GetKey(KeyCode.W) && direction.y < 0 && collision.gameObject.name == "Player1" || Input.GetKey(KeyCode.UpArrow) && direction.y < 0 && collision.gameObject.name == "Player2" || Input.GetKey(KeyCode.S) && direction.y > 0 && collision.gameObject.name == "Player1" || Input.GetKey(KeyCode.DownArrow) && direction.y > 0 && collision.gameObject.name == "Player2")
        {
            direction.y *= -0.7f;
        }
        if (Input.GetKey(KeyCode.W) && direction.y > 0 && collision.gameObject.name == "Player1" || Input.GetKey(KeyCode.UpArrow) && direction.y > 0 && collision.gameObject.name == "Player2" || Input.GetKey(KeyCode.S) && direction.y < 0 && collision.gameObject.name == "Player1" || Input.GetKey(KeyCode.DownArrow) && direction.y < 0 && collision.gameObject.name == "Player2")
        {
            direction.y *= 1.25f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        timerseconds+=Time.deltaTime;
        if (Mathf.Round(timerseconds) < 10)
        {
            TimerSeconds.text = "0" + Mathf.Round(timerseconds).ToString();
        }
        else
        {
            TimerSeconds.text = Mathf.Round(timerseconds).ToString();
        }
        if(Mathf.Round(timerseconds) == 60.0f)
        {
            timerseconds = 0.0f;
            timerminuts++;   
        }
        if (timerminuts < 10.0f)
        {
            TimerMinuts.text = "0" + timerminuts.ToString();
        }
        else
        {
            TimerMinuts.text = timerminuts.ToString();
        }
        rigidbody.velocity = direction.normalized * speed;
        if (transform.position.x > player2.transform.position.x)
        {
            scorecounter1++;
            Score1.text = scorecounter1.ToString();
            Start();
        }
        if (transform.position.x < player1.transform.position.x)
        {
            scorecounter2++;
            Score2.text = scorecounter2.ToString();
            Start();
        }
        if (scorecounter1 == 11 || scorecounter2 == 11)
        {
            Time.timeScale = 0.0f;
            Congratulation.SetActive(true);
            CongratulationInfo.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            scorecounter1 = 0;
            scorecounter2 = 0;
            Score1.text = scorecounter1.ToString();
            Score2.text = scorecounter2.ToString();
            Congratulation.SetActive(false);
            CongratulationInfo.SetActive(false);
            Start();
        }
        if(Input.GetKey(KeyCode.Backspace))
        {
            Start();
        }
    }
}
