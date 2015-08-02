using UnityEngine;
using UObject = UnityEngine.Object;
using GObject = UnityEngine.GameObject;
using URandom = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.Networking;
using UnityEditor;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using System.Xml;


public class Todo : EditorWindow {
	public string path = "todo.xml";

	string newTask = "";
	XmlDocument document = new XmlDocument();
	XmlElement root;

	[MenuItem ("Window/To Do")]
	public static void ShowWindow() {
		EditorWindow.GetWindow (typeof(Todo));
	}

	void Create() {
		XmlTextWriter writer = new XmlTextWriter ("todo.xml", System.Text.Encoding.UTF8);
		writer.WriteStartDocument ();
		writer.WriteStartElement ("tasks");
		writer.WriteEndElement ();
		writer.Close ();
	}

	void OnGUI () {
		try {
			document.Load (path);
		} catch (Exception e) {
			Create ();
			document.Load (path);
		}

		EditorGUILayout.Space ();

		EditorGUILayout.BeginHorizontal ();
		newTask = EditorGUILayout.TextField ("New Task", newTask);
		if (GUILayout.Button ("Post", GUILayout.Width (100))) {
			XmlNode task = document.CreateElement ("task");
			XmlAttribute attr = document.CreateAttribute ("complete");
			attr.Value = "false";
			task.InnerText = newTask;
			document.DocumentElement.AppendChild (task);
			task.Attributes.Append (attr);
			document.Save (path);
		} EditorGUILayout.EndHorizontal ();
		
		EditorGUILayout.Space ();

		foreach (XmlNode task in document.DocumentElement) {
			if (EditorGUILayout.ToggleLeft (
				task.InnerText, 
				task.Attributes["complete"].Value == "true")
			) {
				task.Attributes ["complete"].Value = "true";
				document.Save (path);
			} else {
				task.Attributes ["complete"].Value = "false";
				document.Save (path);
			}
		}
	}
}