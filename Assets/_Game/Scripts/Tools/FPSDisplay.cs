using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour {

	float deltaTime=0.0f;

	
	public bool isShowFPS;
	public Text FPSLabel;
	
	//display settings
	public bool isChangeScreenSuit=false;
	public	int ManualWidth;
	public  int ManualHeight;
	int manualHeight;
	
	void Awake()
	{
		Application.targetFrameRate=60;
	}
	
	void Start()
	{
		if(isChangeScreenSuit)
		{
			if (System.Convert.ToSingle(Screen.height) / Screen.width > System.Convert.ToSingle(ManualHeight) / ManualWidth)
				manualHeight = Mathf.RoundToInt(System.Convert.ToSingle(ManualWidth) / Screen.width * Screen.height);
			else
				manualHeight = ManualHeight;
			Camera camera = GetComponent<Camera>();
			float scale =System.Convert.ToSingle(manualHeight / ManualHeight);
			camera.fieldOfView*= scale;
		}

		if(!isShowFPS)
			FPSLabel.gameObject.SetActive(false);
	}
	
	void Update()
	{
		if(isShowFPS)
		{
			deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
			
			float msec = deltaTime * 1000.0f;
			float fps = 1.0f / deltaTime;
			FPSLabel.text=string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
		}
		
		
	}
}
