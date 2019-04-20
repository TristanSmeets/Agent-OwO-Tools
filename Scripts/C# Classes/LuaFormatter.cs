using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPP_LevelEditor
{
	class LuaFormatter : ILuaFormatter
	{
		public string CreateFormattedGameObject(int index, string tableName, ISerializableObject iSerializableObject)
		{
			string FormattedString = "";
			FormattedString += formatGameObjectCreation(index);
			FormattedString += formatPosition(index, iSerializableObject);
			FormattedString += formatRotation(index, iSerializableObject);
			FormattedString += formatScale(index, iSerializableObject);
			FormattedString += formatType(index, iSerializableObject);
			FormattedString += formatTableInsertion(index, tableName);
			return FormattedString;
		}

		private string formatTableInsertion(int index, string tableName)
		{
			return string.Format("table.insert({0}, newGameObject{1})\n", tableName, index);
		}

		private string formatType(int index, ISerializableObject serializableObject)
		{
			return string.Format("newGameObject{0}.Type = '{1}'\n", index, serializableObject.GetObjectInformation().GetObjectType());
		}

		private string formatScale(int index, ISerializableObject serializableObject)
		{
			string tempScale = string.Format("newGameObject{0}.Scale = ", index);
			tempScale += "{ ";
			tempScale += string.Format("x = {0}, y = {1}, z = {2}",
				serializableObject.GetScale().x,
				serializableObject.GetScale().y,
				serializableObject.GetScale().z);
			tempScale += " }\n";
			return tempScale;
		}
		/// <summary>
		/// Formats the Transforms rotation in euler angles.
		/// </summary>
		/// <param name="index"></param>
		/// <param name="serializableObject"></param>
		/// <returns>Returns a Formatted string with EulerAngles</returns>
		private string formatRotation(int index, ISerializableObject serializableObject)
		{
			string tempRotation = string.Format("newGameObject{0}.Rotation = ", index);
			tempRotation += "{ ";
			tempRotation += string.Format("x = {0}, y = {1}, z = {2}, w = {3}",
				serializableObject.GetRotation().x,
				serializableObject.GetRotation().y * -1,
				serializableObject.GetRotation().z * -1,
				serializableObject.GetRotation().w);
			tempRotation += " }\n";
			return tempRotation;
		}

		string formatGameObjectCreation(int index)
		{
			string objectCreation = string.Format("local newGameObject{0} = GameObject:new()\n", index);
			return objectCreation;
		}

		string formatPosition(int index,ISerializableObject serializableObject)
		{
			string temp = string.Format("newGameObject{0}.Position = ", index);
			temp += "{ ";
			temp += string.Format("x = {0}, y = {1}, z = {2}",
				serializableObject.GetPosition().x * - 1,
				serializableObject.GetPosition().y,
				serializableObject.GetPosition().z);
			temp += " }\n";

			return temp;
		}

		public string CreateFormattedUIObject(int index, string tableName, ISerializableUI serializableUI)
		{
			string FormattedString = "";
			FormattedString += formatUIOBjectCreation(index);
			FormattedString += formatUIPosition(index, serializableUI);
			FormattedString += formatUIRotation(index, serializableUI);
			FormattedString += formatUIScale(index, serializableUI);
			FormattedString += formatHeight(index, serializableUI);
			FormattedString += formatWidth(index, serializableUI);
			FormattedString += formatUIType(index, serializableUI);

			switch (serializableUI.GetUIType())
			{
				case UI_TYPE.BACKGROUND:
				case UI_TYPE.IMAGE:
					FormattedString += formatImage(index, serializableUI);
					break;
				case UI_TYPE.BUTTON:
					FormattedString += formatButtonType(index, serializableUI);
					FormattedString += formatImage(index, serializableUI);
					break;
				case UI_TYPE.TEXT:
					FormattedString += formatUIFont(index, serializableUI);
					FormattedString += formatFontSize(index, serializableUI);
					FormattedString += formatFontText(index, serializableUI);
					break;
			}
			FormattedString += formatUITableInsertion(index, tableName);
			return FormattedString;
		}

		private string formatUITableInsertion(int index, string tableName)
		{
			return string.Format("table.insert({0}, newUI{1})\n", tableName, index);
		}

		private string formatFontText(int index, ISerializableUI serializableUI)
		{
			return string.Format("newUI{0}.Text = '{1}'\n", index, serializableUI.GetFontText());
		}

		private string formatWidth(int index, ISerializableUI serializableUI)
		{
			return string.Format("newUI{0}.Width = {1}\n", index, serializableUI.GetWidth());
		}

		private string formatHeight(int index, ISerializableUI serializableUI)
		{
			return string.Format("newUI{0}.Height = {1}\n", index, serializableUI.GetHeight());
		}

		private string formatButtonType(int index, ISerializableUI serializableUI)
		{
			return string.Format("newUI{0}.ButtonType = '{1}'\n", index, serializableUI.GetButtonType());
		}

		private string formatFontSize(int index, ISerializableUI serializableUI)
		{
			return string.Format("newUI{0}.FontSize = {1}\n", index, serializableUI.GetFontSize());
		}

		private string formatImage(int index, ISerializableUI serializableUI)
		{
			return string.Format("newUI{0}.ImagePath = '{1}'\n", index, serializableUI.GetImage());
		}

		private string formatUIFont(int index, ISerializableUI serializableUI)
		{
			return string.Format("newUI{0}.FontPath = '{1}'\n", index, serializableUI.GetFont());
		}

		private string formatUIType(int index, ISerializableUI serializableUI)
		{
			return string.Format("newUI{0}.Type = '{1}'\n", index, serializableUI.GetUIType());
		}

		private string formatUIScale(int index, ISerializableUI serializableUI)
		{
			string formatScale = string.Format("newUI{0}.Scale = ", index);
			formatScale += "{ ";
			formatScale += string.Format("x = {0}, y = {1}, z = {2}",
				serializableUI.GetScale().x,
				serializableUI.GetScale().y,
				serializableUI.GetScale().z);
			formatScale += " }\n";
			return formatScale;
		}

		private string formatUIRotation(int index, ISerializableUI serializableUI)
		{
			string formatRotation = string.Format("newUI{0}.Rotation = ", index);
			formatRotation += "{ ";
			formatRotation += string.Format("x = {0}, y = {1}, z = {2}, w = {3}",
				serializableUI.GetRotation().x,
				serializableUI.GetRotation().y,
				serializableUI.GetRotation().z,
				serializableUI.GetRotation().w);
			formatRotation += " }\n";
			return formatRotation;
		}

		private string formatUIPosition(int index, ISerializableUI serializableUI)
		{
			string formatPosition = string.Format("newUI{0}.Position = ", index);
			formatPosition += "{ ";
			formatPosition += string.Format("x = {0}, y = {1}, z = {2}",
				serializableUI.GetPosition().x,
				1080 - serializableUI.GetPosition().y,
				serializableUI.GetPosition().z);
			formatPosition += " }\n";
			return formatPosition;
		}

		private string formatUIOBjectCreation(int index)
		{
			string formattedCreation = string.Format("local newUI{0} = UIObject:new()\n", index);
			return formattedCreation;
		}
	}
}
