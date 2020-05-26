using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    private float healthPercentage;
    private int maxHealth;

    // Use this for initialization
    void Start()
    {
        
        maxHealth = 5;
        health = maxHealth;
    }

    public void Hit()
    {
        health -= 1;
        Debug.Log("Health: " + health);
       if (health == 0) {
   // Debug.Break();
    Messenger.Broadcast (GameEvent.PLAYER_DEAD);
}
        healthPercentage = ((float)health) /maxHealth;
        //step 1) Have the PlayerCharacter script broadcast a HEALTH_CHANGED Event when the player is hit by a laser. [done]
        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, healthPercentage);


        //step 2) Make the event take as a parameter the percentage of player health remaining


        //You should create a new member variable called maxHealth. 
        //Have the UIController listen for the event so that it can update the Health Bar when it happens.




    }
    public void FirstAid(int healthAdded)
    {
        Debug.Log("firstaid");
        if (health < maxHealth)
        {
            health += healthAdded;
            if (health > maxHealth)
            {
                health = maxHealth;
            }

            float healthPercent = ((float)health) / maxHealth;
            Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, healthPercent);
           
        }
    }
}
