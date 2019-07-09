using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAA : MonoBehaviour {
    public LineRenderer line;
    public float play_speed;
    public Vector2 velocity;
    public Vector2 last_pos;
    public Vector2 gravity;
    public int physics_steps;
    public float bounce_damping;
    public Transform muzzle;
    public float fire_velocity;
    // Use this for initialization
    void Start () {
       // gravity = GameObject.Find("Attractor (3)").GetComponent<Grav>().force;

    }

    // Update is called once per frame
    void Update()
    {
        gravity = Physics.gravity;//GameObject.Find("Attractor (3)").GetComponent<Grav>().force;
        play_speed = Time.deltaTime;
        velocity += gravity * play_speed;
        RaycastHit2D hit = Physics2D.Linecast(last_pos, (last_pos + (velocity * play_speed)));
        last_pos = transform.position;
        if (hit != null)
        {
            velocity = Vector2.Reflect(velocity * bounce_damping, hit.normal);
            transform.position = hit.point;
        }
        //transform.position += velocity * play_speed;
    }
    void FixedUpdate()
    {
            //last_pos = muzzle.position;
            velocity = muzzle.forward * fire_velocity;
            line.positionCount = 1;
            line.SetPosition(0, last_pos);
            int i = 1;
            while (i < physics_steps)
            {
                //Debug.Log("SI2");
                velocity += gravity * Time.fixedDeltaTime;
                RaycastHit2D hit = Physics2D.Linecast(last_pos, (last_pos + (velocity * Time.fixedDeltaTime)));
                if (hit != null)
                {
                    //Debug.Log("SI3");
                    velocity = Vector2.Reflect(velocity * bounce_damping, hit.normal);
                    last_pos = hit.point;
                }
                line.positionCount = i + 1;
                line.SetPosition(i, last_pos);
                last_pos += velocity * Time.fixedDeltaTime;
                i++;
            }
        
    }
}
