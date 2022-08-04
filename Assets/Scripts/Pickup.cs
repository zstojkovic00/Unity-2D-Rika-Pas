using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public bool isGem, isHeal;

    private bool isCollected;

    public GameObject pickupEffect;

    // Start is called before the first frame update
    void Start()
    {
       UlController.instance.UpdateGemCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !isCollected)
        {
            if(isGem)
            {
                LevelManager.instance.gemsCollected++;
                isCollected = true;
                Destroy(gameObject);

                Instantiate(pickupEffect, transform.position, transform.rotation);


                UlController.instance.UpdateGemCount();
                AudioManager.instance.PlaySFX(6);
            }
            if(isHeal)
            {
                if(PlayerHealth.instance.currentHealth != PlayerHealth.instance.maxHealth)
                 {
                     PlayerHealth.instance.HealPlayer();

                     isCollected = true;
                     Destroy(gameObject);


                     Instantiate(pickupEffect, transform.position, transform.rotation);
                     AudioManager.instance.PlaySFX(7);

                     
                 }
                
            }
        }
    }
}
