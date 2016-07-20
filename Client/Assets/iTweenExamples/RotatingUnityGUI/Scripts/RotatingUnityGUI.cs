using UnityEngine;
using System.Collections;

public class RotatingUnityGUI : MonoBehaviour
{
	float currentAngle, targetAngle = 0;
	Vector2 buttonSize = new Vector2(120,50);
	Rect buttonRect;
	
	void Start(){
		buttonRect = new Rect((Screen.width/2) - (buttonSize.x/2),(Screen.height/2) - (buttonSize.y/2),buttonSize.x,buttonSize.y);	
	}
	
	void OnGUI(){
		Matrix4x4 matrixBackup = GUI.matrix;
		currentAngle = iTween.FloatUpdate(currentAngle, targetAngle, 3);
        GUIUtility.RotateAroundPivot(currentAngle, new Vector2(buttonRect.x + (buttonRect.width/2), buttonRect.y + (buttonRect.height/2)));
        if(GUI.Button(buttonRect, "Click to Flip!")){
			targetAngle +=180;
		}
        GUI.matrix = matrixBackup;
	}
}

