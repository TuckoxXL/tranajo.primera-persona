using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float forcemultiplier;
    public float jumforce;
    public bool canjump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canjump = true;

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalforce = Input.GetAxis("Horizontal") * forcemultiplier;
        float verticalforce = Input.GetAxis("Vertical") * forcemultiplier;

        //rb.AddForce(horizontalforce, 0f, -verticalforce);
        horizontalforce *= Time.deltaTime;
        verticalforce *= Time.deltaTime;
        transform.Translate(horizontalforce, 0, verticalforce);

        if (Input.GetKeyDown(KeyCode.Space) && canjump)
        {
            rb.AddForce(0f, jumforce, 0f, ForceMode.Impulse);
            canjump = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canjump = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("GameOver");

        }
    } 
}
