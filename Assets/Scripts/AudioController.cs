using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    
    public AudioSource watershotgun, colliderSound, enemyDead, healthPickup, ammoPickup, playerDamage, steps, gun1;
    
    private void Awake()
	  {
		  instance = this;
	  }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PlayWaterShotgun()
    {
      watershotgun.Stop();
      watershotgun.Play();
    }
    
    public void PlaycolliderSound()
    {
      colliderSound.Stop();
      colliderSound.Play();
    }
    
    public void PlayenemyDead()
    {
      enemyDead.Stop();
      enemyDead.Play();
    }
    
    public void PlayHealthPickup()
    {
      healthPickup.Stop();
      healthPickup.Play();
    }
    
    public void PlayAmmoPickup()
    {
      ammoPickup.Stop();
      ammoPickup.Play();
    }
    
    public void PlayGun1()
    {
      gun1.Stop();
      gun1.Play();
    }
    
    public void PlayPlayerDamage()
    {
      playerDamage.Stop();
      playerDamage.Play();
    }
    
    public void PlaySteps()
    {
      steps.Stop();
      steps.Play();
    }
}

