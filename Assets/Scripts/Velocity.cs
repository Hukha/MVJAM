using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{

    public GameObject target;

    private float HoriInitialSpeed = 5;
    private float VertInitialSpeed = 5;
    private float timeLimit = 2;
    private float timeElapsed = 0;

    void Start()
    {
        float HoriPredict = HoriInitialSpeed * timeLimit;
        float VertiPredict = VertInitialSpeed * timeLimit + (0.5f * Physics2D.gravity.y * timeLimit * timeLimit);

        target.transform.Translate(HoriPredict, VertiPredict, 0);
        GetComponent<Rigidbody2D>().velocity = new Vector2(HoriInitialSpeed, VertInitialSpeed);
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeLimit)
        {
            //stop the bullet
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
}