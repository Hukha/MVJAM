using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    Vector2 MousePos;
    public Vector2 difference;
    public Transform Prefab;
    public Transform Instant;
    public float dist;
    public float test;
    public float rotacio;
    [HideInInspector]
    public bool Destr;
    public GameManager gameManager;
    private AudioSource source;
	// Use this for initialization
	void Start () {
        Destr = true;
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        MousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        difference = Camera.main.ScreenToWorldPoint(MousePos) - transform.position;
        difference.Normalize();
        dist = Vector2.Distance(transform.position, Camera.main.ScreenToWorldPoint(MousePos));
        Debug.DrawRay(Instant.position, difference * 1, Color.green);
        //Debug.DrawRay(transform.position, (difference) * dist, Color.green);
        rotacio = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, rotacio);
        if (gameManager.GamePause == false) {
            transform.rotation = Quaternion.Euler(0f, 0f, rotacio);
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Instant.position, difference, 1);
            if (hit.collider == null && Destr == true && gameManager.GamePause == false || hit.transform.tag != "Planet" && Destr == true && gameManager.GamePause == false)
            {
                Shoot();
            }
        }
    }

    void Shoot() {
        Debug.Log("Pene");
        Quaternion OffSet = transform.rotation;
        OffSet *= Quaternion.Euler(0f, 0f, -90f);
        source.Play();
        Instantiate(Prefab, Instant.position, OffSet);
        Destr = false;
    }
}
