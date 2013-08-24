﻿using UnityEngine;
using System.Collections;


/// <summary>
/// Motion system for platform games.
/// </summary>

[RequireComponent( typeof ( CharacterController ) )]

public class Motion : MonoBehaviour
{
	// properties
	
	public float layer = 0;
	
	public float gravity = 0.6f;
	
	public float speed = 8f;
	
	// configs
	
	public bool backUpX = false;
	
	public bool backUpY = false;
	
	// modifiers
	
	public Vector3 movement = Vector3.zero;
	
	public Vector3 impulse = Vector3.zero;
	
	// core
	
	private CharacterController controller;

	
	void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	
	void Update()
	{	
		// z is fixed.
		
		if ( transform.position.z != layer )
		{
			transform.position = new Vector3( transform.position.x, transform.position.y, layer );
		}
		
		// pack for backup.
		
		float yBack = movement.y;
		
		float xBack = movement.x;
		
		// motion over the object using movement.
		
		movement = transform.TransformDirection( movement );

		movement *= speed;
		
		// unpack if neccesary.
		
		if ( backUpX )
		{
			movement.x = xBack;
		}
		
		if ( backUpY )
		{
			movement.y = yBack;
		}
		
		// gravity control
		
		if ( !controller.isGrounded )
		{
			movement.y -= gravity;
		}
		else
		{	
			movement.y = movement.y < 0 ? 0 : movement.y;
		}
				
		// pure motion
		
		controller.Move( movement * Time.deltaTime );
	}
	

	void OnControllerColliderHit( ControllerColliderHit hit )
	{
		if ( ( controller.collisionFlags & CollisionFlags.Sides ) == 0 )
		{
			movement = Vector3.zero;
		}
	}
}
