using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CPP_LevelEditor
{
	public class SerializableObject : MonoBehaviour, ISerializableObject
	{
		[SerializeField] ObjectInformation objectInformation;
		public string GetName() { return gameObject.name; }
		public ObjectInformation GetObjectInformation() { return objectInformation; }

		public Vector3 GetPosition()
		{
			return gameObject.transform.position;
		}

		public Quaternion GetRotation()
		{
			return gameObject.transform.rotation;
		}

		public Vector3 GetScale()
		{
			return gameObject.transform.localScale;
		}
	}
}