using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour {
	[HideInInspector]
	public double latitude;
	[HideInInspector]
	public double longitude;
	[HideInInspector]
	public string text;

	public TextMesh messageText;

	public void SetText(string text){
		// 여기서는 텍스트의 길이에 따라 텍스트와 MesageBubble의 크기를 조정해야 합니다. 
		// 지금은 공백만 새 줄 문자로 바꿉니다.
		string newText = text.Replace (" ", "\n");
		messageText.text = newText;
	}

	void Start(){
		// 카메라를 텍스트의 캔버스 구성 요소에 설치합니다. 
		// 문자의 레이어가 메시지 스프라이트 위에 항상 표시되도록 카메라를 추가해야 했습니다.
		messageText.GetComponent<Canvas> ().worldCamera = Camera.main;
	}

	void Update () {
		// 버블이 항상 카메라를 향하도록 합니다.
		//transform.LookAt (Camera.main.transform);
	}
}