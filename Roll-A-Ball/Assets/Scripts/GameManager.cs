using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //singleton fo this script
     public static GameManager Instance { get; private set;}
     public int score =0; //var to track points 
     public TextMeshProUGUI scoreText; //var that holds score text
      public GameObject victoryText; //var what holds victory text

      public GameObject pickupParent; //var which holds parent pick up game obj, used to count how many pick ups there are in game
      public int totalPickups = 0; //total number of pickups in game


      private PlayerController player;
   
  
   private void Awake()
   {
    if (Instance==null) //no other copy of this script in this scene 
    {
        Instance=this; //this refers to itself
    } 
    else //this is not the only copy
    {
        //delete extra copy
        Debug.LogWarning("cannot have more than one instance of [GameManager] in the sence! deleted extra copy");
        Destroy(this.gameObject);
    }
   }

   private void Start()
   {
    score= 0; //reset score to 0 when game starts 
    UpdateScoreText(); 
    victoryText.SetActive(false); //disable score text
    totalPickups= pickupParent.transform.childCount;
   }

   public void UpdateScore(int amount) // amount To Increase By
   {
        //Increase core var by ammount given
        if(score >= totalPickups) WinGame(); //if no more pickups then
        score = score + amount;
        UpdateScoreText();
   }

   public void UpdateScoreText()
   {  //string      //int      //this wont work because you cannot convert string to int
     //scoreText.text= score
     scoreText.text= "score: " + score.ToString(); //Tostring makes this into a string making the code work
   }
   public void WinGame()
   {
     victoryText.SetActive(true);  //enable victoy text
     EndGame();
     AudioManager.Instance.PlaySound("Win");
   }

   public void EndGame()
   {
        Invoke("LoadCurrentLevel", 2f);
   }

   private void LoadCurrentLevel() 
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
   private void losegame()
   {
   {
      Invoke("LoadCurrentLevel", 2f);
   }




   void LoadCurrentLevel()
  {
      SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));
  }



   }
}

