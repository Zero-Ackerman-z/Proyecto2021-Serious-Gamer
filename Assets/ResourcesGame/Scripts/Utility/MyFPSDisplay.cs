﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFPSDisplay : MonoBehaviour
{
	float deltaTime = 0.0f;
	float maxfps = -10000;
	float minfps = 10000;
	

	void Update()
	{
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
		Application.targetFrameRate = 60;
	}

	void OnGUI()
	{
		int w = Screen.width, h = Screen.height;

		GUIStyle style = new GUIStyle();

		Rect rect = new Rect(0, 0, w, h * 2 / 100);
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = h * 2 / 100;
		style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;

		if (fps > maxfps)
			maxfps = fps;
		if (fps < minfps)
			minfps = fps;

		//string text = string.Format("{0:0.0} ms ({1:0.} fps) ({1:0.} minfps ({1:0.} maxfps )", msec, fps, minfps, maxfps);
		string text = "ms("+ msec+") fps(" +fps.ToString().Substring(0,2)+") minfps("+minfps.ToString().Substring(0, 2) + ") maxfps("+maxfps.ToString().Substring(0, 2) + ")";
		GUI.Label(rect, text, style);
	}
}
