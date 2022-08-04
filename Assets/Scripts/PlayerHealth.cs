using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{   
    public static PlayerHealth instance;

    public int currentHealth, maxHealth;

    public float invincibleLenght;
    
    private float invincibleCounter;
    private SpriteRenderer theSR;

    public GameObject deathEffect;


    private void Awake()
    {
       instance = this;
    }
    


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            if(invincibleCounter <= 0 )
            {
                theSR.color = new Color(theSR.color.r,theSR.color.g, theSR.color.b, 1f);
            }
        }
    }
    public void DealDamage(){
        if(invincibleCounter <= 0 )
        {

        //currentHealth = currentHealth - 1;
        //currentHealth -= 1;

        currentHealth--;

        if (
            currentHealth <= 0
        )
        
        {
            currentHealth = 0;

            //gameObject.SetActive(false);

            Instantiate(deathEffect, transform.position, transform.rotation);

            LevelManager.instance.RespawnPlayer();
        } 
        else 
        {
            invincibleCounter = invincibleLenght;
            theSR.color = new Color(theSR.color.r,theSR.color.g, theSR.color.b, .5f);



            PlayerMovement.instance.KnockBack();
            AudioManager.instance.PlaySFX(9);
        }
        UlController.instance.UpdateHealthDisplay();

        }
    }


    public void HealPlayer()
    {
        currentHealth++;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UlController.instance.UpdateHealthDisplay();
    }
    
 
   

}
