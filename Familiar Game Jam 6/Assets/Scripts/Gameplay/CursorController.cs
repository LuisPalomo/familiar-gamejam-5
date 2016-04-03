using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour {

    public Vector2 cursorDir;//variable de direccion de nuestro cursor
    public float mouseSens=2;//+-+
    public float sensPlus;
    public float sensMin;
    public float time = 4;
    public int lives;
    public Camera cam;
    float timeA;
    string powerWhat = "NORMAL";
    string damageWhat = "NODAMAGE";
    Rect cameraRect;


    // Use this for initialization
    void Start () {
        timeA = time;
        lives = GameManager.Instance.lives;

        var bottomLeft = cam.ScreenToWorldPoint(Vector3.zero);
        var topRight = cam.ScreenToWorldPoint(new Vector3(
                    cam.pixelWidth, cam.pixelHeight));

        cameraRect = new Rect(
                    bottomLeft.x,
                    bottomLeft.y,
                    topRight.x - bottomLeft.x,
                    topRight.y - bottomLeft.y);
    }
	
	// Update is called once per frame
	void Update () {

        Cursor.lockState = CursorLockMode.Locked;

        switch (powerWhat)
        {
            case "NORMAL":
                GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case "REVERSETIME":
                if (timeA == time)
                {
                    GetComponent<SpriteRenderer>().color = Color.red;
                    mouseSens = mouseSens * (-1);
                }
                timeA -= Time.deltaTime;
                if (timeA < 0)
                {
                    mouseSens = mouseSens * (-1);
                    timeA = time;
                    powerWhat = "NORMAL";
                }
                break;
            case "SENSPLUS":
                if (timeA == time)
                {
                    GetComponent<SpriteRenderer>().color = Color.green;
                    mouseSens = mouseSens + sensPlus;
                }
                timeA -= Time.deltaTime;
                if (timeA < 0)
                {
                    mouseSens = mouseSens - sensPlus;
                    timeA = time;
                    powerWhat = "NORMAL";
                }
                break;
            case "SENSMIN":
                if (timeA == time)
                {
                    GetComponent<SpriteRenderer>().color = Color.blue;
                    mouseSens = mouseSens - sensMin;
                }
                timeA -= Time.deltaTime;
                if (timeA < 0)
                {
                    mouseSens = mouseSens + sensMin;
                    timeA = time;
                    powerWhat = "NORMAL";
                }
                break;
            case "LOSTLIVE":
                if (timeA == time)
                {
                    GetComponent<Animator>().SetBool("damageP", true);
                    lives--;
                    GameManager.Instance.lives=lives;
                }
                timeA -= Time.deltaTime;
                if (timeA < 0)
                {
                    GetComponent<Animator>().SetBool("damageP", false);
                    timeA = time;
                    powerWhat = "NORMAL";
                }
                break;
        }
        switch (damageWhat)
        {
            case "NODAMAGE":
                break;

            case "LOSTLIVE":
                if (timeA == time)
                {
                    GetComponent<Animator>().SetBool("damageP", true);
                    lives--;
				GameManager.Instance.lives--;
                }
                timeA -= Time.deltaTime;
                if (timeA < 0)
                {
                    GetComponent<Animator>().SetBool("damageP", false);
                    timeA = time;
                    damageWhat = "NODAMAGE";
                }
                break;
        }

        transform.position = new Vector3(
     Mathf.Clamp(transform.position.x, cameraRect.xMin, cameraRect.xMax),
     Mathf.Clamp(transform.position.y, cameraRect.yMin, cameraRect.yMax),
     transform.position.z);

    }
    void FixedUpdate()
    {
        cursorDir = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        GetComponent<Rigidbody2D>().velocity=cursorDir*mouseSens;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
         if (coll.gameObject.tag.Equals("DownRever") && powerWhat.Equals("NORMAL"))
        {
            powerWhat = "REVERSETIME";

        }
        else if (coll.gameObject.tag.Equals("DownSens") && powerWhat.Equals("NORMAL"))
        {
            powerWhat = "SENSMIN";
        }
        else if (coll.gameObject.tag.Equals("UpSens") && powerWhat.Equals("NORMAL"))
        {
            powerWhat = "SENSPLUS";
        }
        else if (coll.gameObject.tag.Equals("Damage") && damageWhat.Equals("NODAMAGE"))
        {
            damageWhat = "LOSTLIVE";
        }
		else if (coll.gameObject.tag.Equals("Coins"))
		{
			GameManager.Instance.coins++;
			Destroy (coll.gameObject);
		}
        

    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("DownRever") && powerWhat.Equals("NORMAL"))
        {
            powerWhat = "REVERSETIME";

        }
        else if (coll.gameObject.tag.Equals("DownSens") && powerWhat.Equals("NORMAL"))
        {
            powerWhat = "SENSMIN";
        }
        else if (coll.gameObject.tag.Equals("UpSens") && powerWhat.Equals("NORMAL"))
        {
            powerWhat = "SENSPLUS";
        }
        else if (coll.gameObject.tag.Equals("Damage") && damageWhat.Equals("NODAMAGE"))
        {
            damageWhat = "LOSTLIVE";
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("DownRever") && powerWhat.Equals("NORMAL"))
        {
            powerWhat = "REVERSETIME";

        }
        else if (other.gameObject.tag.Equals("DownSens") && powerWhat.Equals("NORMAL"))
        {
            powerWhat = "SENSMIN";
        }
        else if (other.gameObject.tag.Equals("UpSens") && powerWhat.Equals("NORMAL"))
        {
            powerWhat = "SENSPLUS";
        }
        else if (other.gameObject.tag.Equals("Damage") && damageWhat.Equals("NODAMAGE"))
        {
            damageWhat = "LOSTLIVE";
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Damage") && damageWhat.Equals("NODAMAGE"))
        {
            damageWhat = "LOSTLIVE";
        }
    }

}
