﻿using UnityEngine;
using System.Collections;


/// <summary>
/// Silx dead. Game restart.
/// </summary>

public class SilxDead : MonoBehaviour
{
	public float hp = 3;
	
	public GUIText text; // to show the lifes.

	private float rate = 0;


	void Update()
	{
		if ( hp <= 0 )
		{
			Destroy( gameObject );
		}
		
		// prints the lives on screen.
		
		if ( text )
		{
			switch ( (int) hp )
			{
				case 3:
					
					text.text = "III";
					
					break;
					
				case 2:
					
					text.text = "II";
					
					break;

				case 1:
					
					text.text = "I";
					
					break;
					
				default:
					
					text.text = "";
					
					break;
			}
		}		
	}

	
	void OnCollisionEnter( Collision collision )
	{
		// respect the rate.
		
		if ( rate > Time.time )
		{
			return;
		}
		
		// detects collisions from the player bullets.
		
		if ( collision.gameObject.tag == "Bullet" && collision.gameObject.layer == LayerMask.NameToLayer( "EnemyFaction" ) )
		{
			hp -= 1;
			
			rate = Time.time + 1f; // 1 seconds invulnerability
		}
	}
}
