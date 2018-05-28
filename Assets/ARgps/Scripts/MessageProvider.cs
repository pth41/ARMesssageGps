using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageProvider : MonoBehaviour {
	/// <summary>
	/// 이 클래스에서는 GPS좌표에 따라 메시지가 로드되고 메시지가 제거되며 
	/// scene 내에서 메시지의 위치가 조정됩니다.
	/// </summary>
	private static MessageProvider _instance;
	public static MessageProvider Instance { get { return _instance; } }

	[HideInInspector]
	public List<GameObject> currentMessages = new List<GameObject>();
	[HideInInspector]
	public bool deviceAuthenticated = false;
	private bool gotInitialAlignment = false;


	void Awake(){
		_instance = this;
	}

	public void GotAlignment(){
		if (deviceAuthenticated){
			if (!gotInitialAlignment) {
				gotInitialAlignment = true;
				// 인증되면 UI활성화 설정
				UIBehavior.Instance.ShowUI ();
				// 첫번째 메시지 로드
				MessageService.Instance.LoadAllMessages ();
				Unity.Utilities.Console.Instance.Log("Loading UI and initial messages!", "lightblue");
			} else {
				UpdateARMessageLocations (디바이스의 GPS좌표);
				Unity.Utilities.Console.Instance.Log("Repositioning messages!", "lightblue");
			}
		} else {
			Debug.Log ("Got Alignment---DEVICE NOT AUTHENTICATED!");
		}
	}

	public void RemoveCurrentMessages(){
		foreach (GameObject messageObject in currentMessages) {
			Destroy (messageObject);
		}
		currentMessages.Clear ();
	}

	public void LoadARMessages(List<GameObject> messageObjectList){
		StartCoroutine (LoadARMessagesRoutine (messageObjectList));
	}

	// 서버에서 로드된 후 초기 메시지를 배치합니다.
	IEnumerator LoadARMessagesRoutine(List<GameObject> messageObjectList){

		RemoveCurrentMessages ();

		yield return new WaitForSeconds(2f);

		foreach (GameObject messageObject in messageObjectList) {

			Message thisMessage = messageObject.GetComponent<Message> ();

			Vector3 _targetPosition = 유니티 좌표로 변환된 (현실세계의 메시지 좌표)

				Debug.Log ("~~~~TARGET POSITION: " + _targetPosition);

			messageObject.transform.position = _targetPosition;
			messageObject.GetComponent<Message> ().SetText (thisMessage.text);
			// 나중에 위치를 업데이트할 수 있도록 목록에 추가
			currentMessages.Add(messageObject);
		}
	}
	// 이 위치는 우리의 위치가 업데이트될 때마다 메시지를 표시합니다.
	public void UpdateARMessageLocations(Vector2d currentLocation){

		if (currentMessages.Count > 0) {

			Debug.Log ("Repositioning Messages...");

			foreach (GameObject messageObject in currentMessages) {

				Message message = messageObject.GetComponent<Message> ();

				Vector3 _targetPosition = 유니티 좌표로 변환된 (현실세계의 메시지 좌표)

					messageObject.transform.position = _targetPosition;
			}
		}
	}
}