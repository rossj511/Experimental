using UnityEngine;
using System.Collections;

public class Rotate_Object : MonoBehaviour
{
	private float x,y,z = 0.0f;
	private int rotate_dimension = 1;
	private bool can_rotate;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Rotate();
	
	}
	public void Rotate()
	{

		if(Input.GetAxis("360_Triggers")>0.001 && can_rotate == true)
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
		if(Input.GetAxis("360_Triggers")<-0.050 && can_rotate == true)
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
	void OnTriggerEnter(Collider other)
	{
		can_rotate = true;
	}
	//When no longer colliding with trigger
	void OnTriggerExit(Collider other)
	{
        can_rotate=false;
    }
}
