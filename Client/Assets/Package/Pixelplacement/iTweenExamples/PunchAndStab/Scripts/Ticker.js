var squeak:AudioClip;

function Slam(amount:int){
	iTween.PunchRotation(gameObject,iTween.Hash("y",amount,"time",2));	
	iTween.Stab(gameObject,iTween.Hash("audioclip",squeak,"pitch",Random.Range(.9,1),"volume",Random.Range(.5,1)));
}

