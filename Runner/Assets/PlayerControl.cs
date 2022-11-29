using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public GameObject gameOver;
    public int liveScore = 1;
    public Transform groundCheck;
    public LayerMask groundMask;
    private bool ground = false;
    private float groundRadius = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ground = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);
        if (Input.GetKey(KeyCode.Space)&& ground == true)
        {
             
            Jump();
        }
        if (liveScore == 0)
        {
            gameOver.SetActive(true);
        }

    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            liveScore--;
        }
    }

    public void Restart() 
    {
        SceneManager.LoadScene("Demo");
    }
}
