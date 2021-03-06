using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;

    public GameObject gamewon;
    public GameObject gamelost;

    public float speed;

    private bool isgameover = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isgameover == true)
        {
            return;
        }
        
        if(Input.GetAxis("Horizontal") > 0)//positive horizontal
        {
            rigidbody2d.velocity = new Vector2(speed, 0f);
        }else if(Input.GetAxis("Horizontal") < 0)//negative horizontal
        {
            rigidbody2d.velocity = new Vector2(-speed, 0f);   
        }else if(Input.GetAxis("Vertical") > 0)//positive vertical
        {
           rigidbody2d.velocity = new Vector2(0f, speed); 
        }else if(Input.GetAxis("Vertical") < 0)// negative vertical
        {
            rigidbody2d.velocity = new Vector2(0f, -speed);
        }else if(Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            //stop
            rigidbody2d.velocity = new Vector2(0f, 0f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Door")
        {
            Debug.Log("Level Completed !!");
            gamewon.SetActive(true);
            isgameover = true;
        }else if (other.tag == "Enemy")
        {
            Debug.Log("Level Lost !!");
            gamelost.SetActive(true);
            isgameover = true;
        }
                    
    }
    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart button clicked");
    }

}
