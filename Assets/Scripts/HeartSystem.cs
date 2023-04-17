using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class HeartSystem : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    public GameObject[] Hearts;
    public int life;
    private bool dead;
    public GameManagerScript gameManager;

    private void start()
        {
            life = Hearts.Length;
        }
    

     void Update()
     {
        if(dead==true)
        {
            Debug.Log("win!!!");
            Destroy(this.gameObject);
            gameManager.gameOver();

        }
     }
     private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && enabled && dead==true)  {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            Debug.Log("Game over!");
            gameManager.gameOver();
        }
        else if (other.tag == triggeringTag && enabled ){
            Destroy(other.gameObject);
            TakeDamage();
        }
    }
  
    public void TakeDamage()
    {
        life -= 1;
        Destroy(Hearts[life].gameObject);
        if(life < 1)
        {
            dead = true;
        }
    }
      
    

}
