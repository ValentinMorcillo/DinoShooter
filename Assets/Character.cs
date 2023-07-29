using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public float vida = 100;
    public Text vidaUI;
    public Button button;
  


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BulletEnemy"))
        {
            vida -=  10;
            Debug.Log(vida);
        }
    }

  
    void Update()
    {
        if (vida <= 0)
        {
            Destroy(this.gameObject);
            button.gameObject.SetActive(true);
        }

        vidaUI.text = "Vida: " + vida;
    }
}
