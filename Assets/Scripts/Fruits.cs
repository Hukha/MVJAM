using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruits : MonoBehaviour {
    public GameManager gameManager;
    public Image Cheese;
    public Image Vegetal;
    public Image Bacon;
    public Image Huevos;
    public Image Tomatoe;
    public AudioSource source;

    void Start() {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {

            source.Play();
            if (this.gameObject.tag == "Cheese") {
                Debug.Log("Cheese");
                
                var tempcolor = Cheese.color;
                tempcolor.a = 1;
                Cheese.color = tempcolor;
                gameManager.CatchFruit();
                Destroy(gameObject);
            }
            if (this.gameObject.tag == "Vegetal")
            {
                Debug.Log("Vegetal");
                var tempcolor = Vegetal.color;
                tempcolor.a = 1;
                Vegetal.color = tempcolor;
                gameManager.CatchFruit();
                Destroy(gameObject);
            }
            if (this.gameObject.tag == "Bacon")
            {
                Debug.Log("Bacon");
                var tempcolor = Bacon.color;
                tempcolor.a = 1;
                Bacon.color = tempcolor;
                gameManager.CatchFruit();
                Destroy(gameObject);
            }
            if (this.gameObject.tag == "Huevos")
            {
                Debug.Log("Huevos");
                var tempcolor = Huevos.color;
                tempcolor.a = 1;
                Huevos.color = tempcolor;
                gameManager.CatchFruit();
                Destroy(gameObject);
            }
            if (this.gameObject.tag == "Tomatoe")
            {
                Debug.Log("Tomatoe");
                var tempcolor = Tomatoe.color;
                tempcolor.a = 1;
                Tomatoe.color = tempcolor;
                gameManager.CatchFruit();
                Destroy(gameObject);
            }

        }
    }
}
