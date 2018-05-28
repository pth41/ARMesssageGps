using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using LitJson;

public class MessageService : MonoBehaviour {

	/// <summary>
	/// 이 클래스는 새 메시지를 삭제, 로드 및 작성하기 위해
	/// 서버와의 통신을 처리합니다.
	/// 새 메시지 개체가 여기에 인스턴스화됩니다.
	/// </summary>
	private static MessageService _instance;
	public static MessageService Instance { get { return _instance; } } 

	public Transform mapRootTransform;

	public GameObject messagePrefabAR;

	void Awake(){
		_instance = this;
	}

	public void RemoveAllMessages(){			
	}

	public void LoadAllMessages() {
		StartCoroutine (LoadAllMessagesRoutine());
	}

	IEnumerator LoadAllMessagesRoutine(){
		//WWW www = new WWW(loadURL);
		//yield return www;

		//if (www.error == null) {
		//	Debug.Log ("Message load To Server...");
		//} else {
		//	Debug.Log ("Error Loading Message Data...");
		//}

		List<GameObject> messageObjectList = new List<GameObject> ();

		//LitJson.JsonData getData = LitJson.JsonMapper.ToObject(www.text);

		//for(int i = 0; i < getData["Msginfo"].Count;, i++) {
			// 메시지ar오브젝트 인스턴스화 및 데이터 로드
			GameObject MessageBubble = Instantiate (messagePrefabAR,mapRootTransform);
			Message message = MessageBubble.GetComponent<Message>();

			//message.latitude = double.Parse(getData["Msginfo"][i]["lat"].ToString());
			//message.longitude = double.Parse(getData["Msginfo"][i]["lon"].ToString());
			//message.text = getData["Msginfo"][i]["text"].ToString();
			messageObjectList.Add(MessageBubble);
		//}
		// 객체 목록을 배치할 수 있도록 ARMessageProvider 에게 전달
		MessageProvider.Instance.LoadARMessages (messageObjectList);
	}

	public void SaveMessage(double lat, double lon, string text){
		StartCoroutine (SaveMessageRoutine (lat, lon, text));
	}

	IEnumerator SaveMessageRoutine(double lat, double lon, string text){
		//WWWForm form = new WWWForm();
		//form.AddField("lat", lat.ToString());
		//form.AddField("lon", lon.ToString());
		//form.AddField("text", text);

		//WWW www = new WWW(saveURL, form);
		//yield return www;

		//if (www.error == null) {
		//	Debug.Log ("Message Saved To Server...");
		//} else {
		//	Debug.Log ("Error Saving Message Data...");
		//}
	}
}