using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public static PlayerController instance;	
	
	public Rigidbody2D theRB;
	
	public float moveSpeed = 5f;
	
	private Vector2 moveInput;
	private Vector2 mouseInput;
	
	public float mouseSensitivity = 1f; 
	
	public Camera viewCam;
	
	public GameObject bulletImpact;
	public int currentAmmo;
	
	public Animator gunAnim;
	public Animator anim;
	
	public int currentHealth;
	public int maxHealth = 100;
	public GameObject deadScreen;
	private bool hasDied;
	
	public Text healthText, ammoText;
	
	private void Awake()
	{
		instance = this;
	}
	
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthText.text = currentHealth.ToString();
        ammoText.text = currentAmmo.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
    
    	if(!hasDied) 
    	{
			// Player movement
		    moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		    
		    Vector3 moveHorizontal = transform.up * -moveInput.x;
		    Vector3 moveVertical = transform.right * moveInput.y;
		    
		    
		    theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed;
		    
		    // Player view control
		    mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
		    
		    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);
		    
		    // Camera view
		    viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));
		    
		    // Shooting
		    
		    if(Input.GetMouseButtonDown(0))
		    {
		    	if(currentAmmo > 0)
		    	{
		    	
		    		Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
		    		RaycastHit hit;
		    		if(Physics.Raycast(ray, out hit))
		    		{
		    			Instantiate(bulletImpact, hit.point, transform.rotation);
		    			
		    			if(hit.transform.tag == "Enemy")
		    			{
		    				hit.transform.parent.GetComponent<EnemyController>().TakeDamage();
		    			}
		    			
		    			//Debug.Log("I'm looking at " + hit.transform.name);
		    		} else 
		    		{
		    			Debug.Log("I'm looking at nothing ");
		    		}
		    		currentAmmo--;
		    		gunAnim.SetTrigger("Shoot");
		    		UpdateAmmoUI();
		    	}
		    }
		    
		    if(moveInput != Vector2.zero)
		    {
		    	anim.SetBool("IsMoving", true);
		    } else {
		    	anim.SetBool("IsMoving", false);
		    }
        }
        
    }
    
    public void TakeDamage(int damageAmount)
    {
    	currentHealth -= damageAmount;
    
    	if(currentHealth <= 0)
    	{
    		deadScreen.SetActive(true);
    		hasDied = true;
    		currentHealth = 0;
    	}
    	healthText.text = currentHealth.ToString();
    }
    
    public void AddHealth(int healAmount)
    {
    	currentHealth += healAmount;
    	if(currentHealth > maxHealth)
    	{
    		currentHealth = maxHealth;
    	}
    	
    	healthText.text = currentHealth.ToString();
    	
    }
    
    public void UpdateAmmoUI()
    {
    	ammoText.text = currentAmmo.ToString();
    }
    
    
    
}
