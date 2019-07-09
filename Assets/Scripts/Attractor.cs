using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{

    const float G = 600f;
    //const float G = 100f;

    public static List<Attractor> Attractors;

    public Rigidbody2D rb;
    public Vector2 f;


    public LineRenderer lineRenderer;
    public int segmentCount = 20;
    public LineRenderer _lineRenderer;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (Attractors == null)
            Attractors = new List<Attractor>();

        Attractors.Add(this);
        rb.AddForce(f, ForceMode2D.Impulse);    
    }
    void FixedUpdate()
    {
        foreach (Attractor attractor in Attractors)
        {
            if (attractor != this)
                Attract(attractor);
        }
        
    }

    /*void OnEnable()
    {
        if (Attractors == null)
            Attractors = new List<Attractor>();

        Attractors.Add(this);
    }*/

    void OnDisable()
    {
        Attractors.Remove(this);
    }



    void Attract(Attractor objToAttract)
    {
        Rigidbody2D rbToAttract = objToAttract.rb;

        Vector2 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance == 0f)
            return;

        float forceMagnitude = (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2f);
        forceMagnitude *= G;
        Vector2 force = (direction.normalized * forceMagnitude) * Time.fixedDeltaTime;

        rbToAttract.AddForce(force);
    }


}