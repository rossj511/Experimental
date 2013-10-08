using UnityEngine;
using System.Collections;

public class Piano : MonoBehaviour 
{
	public AudioClip key;
	private bool can_play;
	private bool no_delay = true;
	private bool use_call = false;
	private float timer = 3.0f;
	private float x,y,z = 0.0f;
	private int rotate_dimension = 1;
	// Use this for initialization
	void Start () 
	{
		can_play = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	public void Use()
	{
		// A Button is read from Input Positive Button "joystick button 0"
		if(Input.GetButtonDown ("360_AButton") && can_play == true && no_delay == true)
		{
			audio.clip = key;
			audio.Play();
			no_delay = false;
			use_call = true;
			StartTimer();
		}
		if(Input.GetAxis("360_Triggers")>0.001 && can_play == true)
		{
			if(rotate_dimension == 1)
			{
				x=1;
				y=0;
				z=0;
			}
			else if(rotate_dimension == 2)
			{
				x=0;
				y=1;
				z=0;
			}
			else if(rotate_dimension == 3)
			{
				x=0;
				y=0;
				z=1;
			}
			transform.Rotate(x,y,z);
		}
		// Left Trigger is activated when pressure is under 0, or the dead zone.
		if(Input.GetAxis("360_Triggers")<-0.050 && can_play == true)
		{
			if(rotate_dimension == 1)
			{
				x=-1;
				y=0;
				z=0;
			}
			else if(rotate_dimension == 2)
			{
				x=0;
				y=-1;
				z=0;
			}
			else if(rotate_dimension == 3)
			{
				x=0;
				y=0;
				z=-1;
			}
			transform.Rotate(x,y,z);
			
		}
		if(Input.GetButtonDown ("360_LeftBumper"))
		{
			rotate_dimension--;
			if(rotate_dimension < 1)
			{
				rotate_dimension = 3;	
			}
		}
		
		// Right Bumper is read from Input Positive Button "joystick button 5"
		if(Input.GetButtonDown ("360_RightBumper"))
		{
			rotate_dimension++;
			if(rotate_dimension > 3)
			{
				rotate_dimension = 1;	
			}
		}
		
	}
	//Simple timer to prevent spamming the use button
	public void StartTimer()
	{
		if(use_call)
		{
	
			if(timer > 0)
			{
				timer -= Time.deltaTime;
			}
			else if(timer <= 0)
			{
				no_delay = true;
				use_call = false;
				timer = 3.0f;
			}
		}
	}
	//When colliding with trigger
	void OnTriggerEnter(Collider other)
	{
		can_play = true;
	}
	//When no longer colliding with trigger
	void OnTriggerExit(Collider other)
	{
        can_play=false;
    }
}
