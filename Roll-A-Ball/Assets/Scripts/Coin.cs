using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class Coin : MonoBehaviour
{
  private AudioSource audioSource;
  public AudioClip coinSound;
  
  //step 1, detect collision 
  //step 2 , Identify obj colliding with this 
  //step 3, destory if obj collides with player 

  public int pointValue = 1;
  
 
 

  private void OnTriggerEnter(Collider other) // Function called when this collider colides with an obj marked as trigger
  {
        if (other.gameObject.CompareTag("Player"))  
        {
            Destroy(this.gameObject); //destory coin
            GameManager.Instance.UpdateScore(pointValue); //tell GameManager to update score by 1 
            GameManager.Instance.totalPickups -= 1; //increase score when picked up
            AudioManager.Instance.PlaySound("PickUp");
        }

  }

  private void Update()
  {
  transform.Rotate(new Vector3(15, 30, 90) * Time.deltaTime);
  //Time.delta will make something frame independent
  }
}
