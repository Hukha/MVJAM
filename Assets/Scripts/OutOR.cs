using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOR : MonoBehaviour {
    public GameObject Text;

    void OnCollisionEnter2D(Collision2D collision) {
        StartCoroutine(WaitForMe());
    }

    IEnumerator WaitForMe()
    {
        Text.SetActive(true);
        yield return new WaitForSeconds(2);
        Text.SetActive(false);
    }
}
