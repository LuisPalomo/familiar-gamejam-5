using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour {

    public Vector2 cursorDir;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        if(Input.GetKey("a")){
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

	}
    void FixedUpdate()
    {
        cursorDir = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));//variable de direccion de nuestro cursor
        Debug.Log(cursorDir.x+" "+cursorDir.y);
       
        GetComponent<Rigidbody2D>().velocity=cursorDir*2;
        
       
    }
}
