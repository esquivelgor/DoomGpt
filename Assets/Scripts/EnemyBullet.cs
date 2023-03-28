using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

	public int damageAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.tag == "Player")
    	{
    		PlayerController.instance.TakeDamage(damageAmount);
    		
    		Destroy(gameObject);
    	}
    }
}
