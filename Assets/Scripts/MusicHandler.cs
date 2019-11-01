﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour 
{
	private static MusicHandler instance;

	void Awake()
	{
		if (instance) 
		{
			DestroyImmediate (gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
			instance = this;
		}
	}
}
