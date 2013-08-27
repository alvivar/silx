﻿using UnityEngine;
using System.Collections;


public class EnemyLocatorCompassMediator : MonoBehaviour
{
	public Transform target;
	
	private Vector3 worldPos = Vector3.zero;

	
	void Update()
	{	
		if ( target )
		{
			worldPos = target.position;	
		}
		else
		{
			// worldPos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
			
			transform.Rotate( Vector3.right * Time.deltaTime * 500 );
		}
        
		var diff = worldPos - transform.position;
 
		float angle = Mathf.Atan2( diff.y, diff.x ) * Mathf.Rad2Deg;
		
		transform.rotation = Quaternion.Euler( new Vector3( 0, 0, angle - 90 ) );
	}
}
