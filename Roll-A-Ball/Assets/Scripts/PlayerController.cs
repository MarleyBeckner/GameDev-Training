using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller; // var to hold the character movement componet 
    public float moveSpeed = 5f; //controls how character moves 

    public float rotateSpeed = 5f; //speed which character rotates 
    // Start is called before the first frame update
    //private Vector3 moveDirection = Vector3.zero;
    public int health;
    private Enemy enemy;

    void Start()
    {
        controller = GetComponent<CharacterController>(); //assigns the controller vat to the players char controller component 

        enemy= FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        //gather input from the player
        float horizontalInput = Input.GetAxis("Horizontal"); //stores left and right input from player
        float verticalInput = Input.GetAxis("Vertical"); //stores forward and back input
        
        //calc the direction of character should be based on input 
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        //Move the player based on input
        controller.Move(movement * moveSpeed * Time.deltaTime);

        //Vector.3 (0, 0, 0) ---> player isnt moving 
        if (movement != Vector3.zero) // if player moving 
        {
            //rotate player in the direction
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
        
    }
    void OnTriggerEnter(Collider Other)
   {
        if(Other.CompareTag("enemy"))
        {
            //trigger the damage
            health = health - enemy.damage;


            if(health <= 0)
            {
                GameManager.Instance.EndGame();

                Destroy(gameObject);
            }
            AudioManager.Instance.PlaySound("Death");
        }
   }

    
}
