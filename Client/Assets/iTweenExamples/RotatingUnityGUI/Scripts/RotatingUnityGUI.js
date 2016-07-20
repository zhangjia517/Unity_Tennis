private var currentAngle : float = 0;
private var targetAngle : float = 0;
private var buttonSize : Vector2 = Vector2(120,50);
private var buttonRect : Rect;

function Start(){
	buttonRect = new Rect((Screen.width/2) - (buttonSize.x/2),(Screen.height/2) - (buttonSize.y/2),buttonSize.x,buttonSize.y);
}

function OnGUI(){
	var matrixBackup : Matrix4x4 = GUI.matrix;
	currentAngle = iTween.FloatUpdate(currentAngle, targetAngle, 3);
    GUIUtility.RotateAroundPivot(currentAngle, new Vector2(buttonRect.x + (buttonRect.width/2), buttonRect.y + (buttonRect.height/2)));
      if(GUI.Button(buttonRect, "Click to Flip!")){
		targetAngle +=180;
	}
    GUI.matrix = matrixBackup;
}