using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour {
    public Rigidbody2D rb;
    public float power;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        power = GameObject.Find("GameObject").GetComponent<Gun>().dist * 50;
        if (power > 900)
        {
            power = 900;
            rb.AddForce(this.transform.up * (power), ForceMode2D.Impulse);
        }
        else {
            rb.AddForce(this.transform.up * (power), ForceMode2D.Impulse);
        }
        //Destroy(gameObject, 5);
    }
	
	// Update is called once per frame
	void Update () {
        transform.up = rb.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            GameObject.Find("GameObject").GetComponent<Gun>().Destr = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().Shooting();
            Destroy(gameObject);
        }
        else {
            GameObject.Find("GameObject").GetComponent<Gun>().Destr = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().Shooting();
            Destroy(gameObject);
        }
    }
}
