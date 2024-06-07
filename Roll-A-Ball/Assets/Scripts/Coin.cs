using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
  //step 1, detect collision 
  //step 2 , Identify obj colliding with this 
  //step 3, destory if obj collides with player 

  private void OnTriggerEnter(Collider other) // Function called when this collider colides with an obj marked as trigger
  {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }

  }
}
