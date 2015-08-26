using UnityEngine;
using UObject = UnityEngine.Object;
using GObject = UnityEngine.GameObject;
using URandom = UnityEngine.Random;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.Networking;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class CollideHandler : ExtBehaviour {
	[Serializable]
	public class Handler : UnityEvent<GameObject> {}

	[FormerlySerializedAs("OnEnter")]
	[SerializeField]
	public Handler OnEnter = new Handler();
	[FormerlySerializedAs("OnExit")]
	[SerializeField]
	public Handler OnExit = new Handler();
	[FormerlySerializedAs("OnStay")]
	[SerializeField]
	public Handler OnStay = new Handler();

	void Start () {
	}
	
	void Update () {
	}

	void OnTriggerEnter2D (Collider2D other) {
		OnEnter.Invoke (other.gameObject);
	}

	void OnTriggerExit2D (Collider2D other) {
		OnExit.Invoke (other.gameObject);
	}

	void OnTriggerStay2D (Collider2D other) {
		OnStay.Invoke (other.gameObject);
	}
}
