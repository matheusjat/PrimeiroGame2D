using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {
    private Rigidbody2D rb2d;
    private Animator anim;
    private AudioSource audio;
    public AudioClip pop;
    private int count;
    private int totalOuros;

    public int speed = 1;
    public Text score;
    public Text winMessage;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        Vector2 movement = new Vector2(0,0);

        winMessage.text = "";

        anim = this.GetComponent<Animator>();
        audio = this.GetComponent<AudioSource>();

        totalOuros = GameObject.FindGameObjectsWithTag("Ouro").Length;
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
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        moveHorizontal = Input.GetAxis("Horizontal");
        moveHorizontal = Input.acceleration.x;

        moveVertical = Input.GetAxis("Vertical");
        moveVertical = Input.acceleration.y;

        moveHorizontal = 

        if ((moveHorizontal != 0) || (moveVertical != 0))
        {
            anim.Play("Running", -1);
        }
        else
        {
            anim.Play("Stopped", -1);
        }

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement*speed);
        
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.CompareTag("Ouro"))
        {
            audio.PlayOneShot(pop);

            colisor.gameObject.SetActive(false);
            count++;
            SetScoreText();
            
        }
    }

    void SetScoreText()
    {
        score.text = "Score: " + count;
        if (count >= totalOuros)
        {
            winMessage.text = "You Win!";
        }        
    }
	
}
