using UnityEngine;
using System.Collections;
 
public class FPSDisplay : MonoBehaviour
{
	 public int Font_Size=6;
	float deltaTime = 0.0f;

    void Update()
	{
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
	}
 
	void OnGUI()
	{
		int w = Screen.width, h = Screen.height;
 
		GUIStyle style = new GUIStyle();
 
		Rect rect = new Rect(0, 0, w, h * 2/ 100);
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = h * Font_Size/ 120;
		style.normal.textColor =  Color.white;
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
		string text = string.Format(" {1:0.} fps ({0:0.0} ms)" ,msec, fps);
		GUI.Label(rect, text, style);
	}

}