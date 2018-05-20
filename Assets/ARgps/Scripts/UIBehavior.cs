using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehavior : MonoBehaviour {
	/// <summary>
	/// 이 클래스에는 UI에서 버튼을 누르면 호출되는 기능들이 있습니다.
	/// </summary>
	private static UIBehavior _instance;
	public static UIBehavior Instance { get { return _instance; } } 

	public GameObject HomeScreen;
	public GameObject MessageScreen;
	public Text messageText;

	void Awake(){
		_instance = this;
		HomeScreen.SetActive (false);
		MessageScreen.SetActive (true);
	}

	public void ShowUI(){
		//HomeScreen.SetActive (true);
	}

	public void RemoveButtonDown(){
		HomeScreen.SetActive (false);
		//MessageService.Instance.RemoveAllMessages ();
		//ARMessageProvider.Instance.RemoveCurrentMessages ();
		StartCoroutine (DelayRemoveRoutine ());
	}

	IEnumerator DelayRemoveRoutine(){
		yield return new WaitForSeconds (2f);
		HomeScreen.SetActive (true);
	}

	public void MessageButtonDown(){
		HomeScreen.SetActive (false);
		MessageScreen.SetActive (true);
	}

	public void SubmitButtonDown(){
			//double lat = 현재 디아비스 위치의 Latitude
			//double lon = 현재 디바이스 위치의 Longitude

			//MessageService.Instance.SaveMessage (lat, lon, messageText.text);

		messageText.text = "";
		//HomeScreen.SetActive (true);
		//MessageScreen.SetActive (false);
		//StartCoroutine (DelayLoadMessagesRoutine ());
	}

	IEnumerator DelayLoadMessagesRoutine(){
		yield return new WaitForSeconds (1f);
		//MessageService.Instance.LoadAllMessages ();
	}
}