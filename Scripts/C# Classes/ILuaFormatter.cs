using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPP_LevelEditor
{
	interface ILuaFormatter
	{
		string CreateFormattedGameObject(int index, string tableName, ISerializableObject serializableObject);
		string CreateFormattedUIObject(int index, string tableName, ISerializableUI serializableUI);
	}
}
