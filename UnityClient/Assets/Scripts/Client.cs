using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Client : MonoBehaviour {
	[SerializeField]
	TMP_InputField _messageInput;

	[SerializeField]
	Button _sendButton;

	[SerializeField]
	TMP_Text _messagesText;

	SignalRLib _ws;

	void Awake() {
		_sendButton.onClick.AddListener(OnSend);
	}

	void Start() {
		_ws = new SignalRLib();
		_ws.Init("https://konhit.xyz/chat_service/chat/", "Send");
		_ws.ConnectionStarted += (sender, args) => {
			AddText(args.Message);
		};
		_ws.MessageReceived += (sender, args) => {
			AddText(args.Message);
		};
	}

	void OnSend() {
		var message = _messageInput.text;
		_messageInput.text = "";
		_ws.SendMessage("Send", message);
	}

	void AddText(string text) {
		_messagesText.text += $"{text}\n";
	}
}
