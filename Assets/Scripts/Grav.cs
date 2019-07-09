using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Grav : MonoBehaviour {

    const float G = 200f;

    public Rigidbody2D rb;
    public GameObject Body;
    public Vector2 f;
    public GameObject[] Players;
    public GameObject b;
    public Vector2 force;
    public AudioSource source;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(f, ForceMode2D.Impulse);
        Body = GameObject.FindWithTag("Player");
        b = GameObject.FindWithTag("Base");
        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (GameObject other in Players)
        {
            //Debug.Log("PRINT");
            Vector2 direction = rb.position - other.GetComponent<Rigidbody2D>().position;
            float distance = direction.magnitude;


            float forceMagnitude = (rb.mass * other.GetComponent<Rigidbody2D>().mass) / Mathf.Pow(distance, 2f);
            forceMagnitude *= G;
            force = (direction.normalized * forceMagnitude) * Time.fixedDeltaTime;

            other.GetComponent<Rigidbody2D>().AddForce(force);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (this.transform.tag == "Planet")
        {
            source.Play();
            ContactPoint2D contact = collision.contacts[0];
            b.transform.position = contact.point;
        }
        
    }

}
