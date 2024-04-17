using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
	
	public float speed;
	public Text scoretext;
	
	Rigidbody rb;
	
	float xInput;
	float yInput;
	
	int score = 0;
	public int winScore;
	
	public GameObject winText;
	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		//scoretext = "Score : " + score.ToString();
		Cursor.lockState = CursorLockMode.Locked;
		
	}
  
  
  
   // Update is called once per frame
    void Update()
    {
	    if(transform.position.y < -5f)
	    {
           SceneManager.LoadScene("Game");		
        }
    }
	
	private void FixedUpdate()
	{
		xInput = Input.GetAxis("Horizontal");
		yInput = Input.GetAxis("Vertical");
		
		rb.AddForce(xInput* speed, 0, yInput* speed);
	}
	
	
	
	
	
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Coin");
		{
			other.gameObject.SetActive(false);
			
			score = score + 1;
			scoretext.text = "Score: " + score.ToString();
			
			
			if(score >= winScore)
			{
				//gamewin
				winText.SetActive(true);
			}
				
		
		}
    }
} 

