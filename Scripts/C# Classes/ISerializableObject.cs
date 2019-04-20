using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPP_LevelEditor
{
	public interface ISerializableObject
	{
		string GetName();
		ObjectInformation GetObjectInformation();
		UnityEngine.Vector3 GetPosition();
		UnityEngine.Quaternion GetRotation();
		UnityEngine.Vector3 GetScale();
	}
}
