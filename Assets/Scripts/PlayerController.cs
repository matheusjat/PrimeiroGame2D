using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {
    private Rigidbody2D rb2d;
    public int speed = 1;
    private int count;
    public Text score;
    public Text winMessage;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;

        winMessage.text = "";
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                activity.Call<bool>("moveTaskToBack", true);
            }
            else
            {
                Application.Quit();
            }
        }
    }

	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement*speed);
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.CompareTag("Ouro"))
        {
            colisor.gameObject.SetActive(false);
            count++;
            SetScoreText();
            
        }
    }

    void SetScoreText()
    {
        score.text = "Score: " + count;
        if (count >= 6)
        {
            winMessage.text = "You Win!";
        }        
    }
	
}
