using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPP_LevelEditor
{
	interface ILuaSerializer
	{
		void CreateLuaFile(IList<ISerializableObject> gameObjects, string fileName);
		void CreateLuaFile(IList<ISerializableUI> gameObjects, string fileName);
	}
}
