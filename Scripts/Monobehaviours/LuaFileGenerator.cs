using System.Collections.Generic;
using UnityEngine;

namespace CPP_LevelEditor
{
	public class LuaFileGenerator : MonoBehaviour
	{
		public string Directory;
		public string FileName;

		string defaultName = "Level";

		ILuaSerializer luaSerializer;
		// Use this for initialization
		void Start()
		{
			if (Directory.Equals(""))
				luaSerializer = new LuaSerializer();
			else
				luaSerializer = new LuaSerializer(Directory);
		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.S))
			{
				if (FileName.Equals(""))
					OnClick(defaultName);
				else
					OnClick(FileName);
			}
			if (Input.GetKeyDown(KeyCode.E))
			{
				if (FileName.Equals(""))
					UISave(defaultName);
				else
					UISave(FileName);
			}
		}

		public void OnClick(string fileName)
		{
			IList<ISerializableObject> serializableObjects = GameObject.FindObjectsOfType<SerializableObject>();
			luaSerializer.CreateLuaFile(serializableObjects, fileName);
		}

		void UISave(string fileName)
		{
			IList<ISerializableUI> serializableUIs = GameObject.FindObjectsOfType<SerializableUI>();
			luaSerializer.CreateLuaFile(serializableUIs, fileName);
		}
	}
}
