using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace CPP_LevelEditor
{
	public class LuaSerializer : ILuaSerializer
	{
		string directory;
		ILuaFormatter luaFormatter;

		public LuaSerializer(string fileDirectory = "Assets\\Scripts\\LevelEditor\\")
		{
			this.directory = fileDirectory;
			luaFormatter = new LuaFormatter();
		}

		public void CreateLuaFile(IList<ISerializableObject> gameObjects, string fileName)
		{
			string newFileLoc = createFileName(fileName);
			UnityEngine.Debug.LogFormat("Creating {0}.lua at: {1}", fileName, newFileLoc);
			string tableName = "GameObjects";
			string luaRequires = string.Format("require('LuaGameScripts\\\\GameObject')\n");

			using (StreamWriter outputFile = new StreamWriter(newFileLoc))
			{
				outputFile.WriteLine(luaRequires);
				outputFile.WriteLine(tableName + " = {}");

				for (int index = 0; index < gameObjects.Count; index++)
				{
					outputFile.WriteLine(luaFormatter.CreateFormattedGameObject(index, tableName, gameObjects[index]));
				}
			}
		}

		public void CreateLuaFile(IList<ISerializableUI> gameObjects, string fileName)
		{
			string newFileLoc = createFileName(fileName);
			UnityEngine.Debug.LogFormat("Creating {0}.lua at: {1}", fileName, newFileLoc);
			string tableName = "Buttons";
			string luaRequires = string.Format("require('LuaGameScripts\\\\UIObject')\n");

			using (StreamWriter outputFile = new StreamWriter(newFileLoc))
			{
				outputFile.WriteLine(luaRequires);
				outputFile.WriteLine(tableName + " = {}");

				for (int index = 0; index < gameObjects.Count; index++)
				{
					outputFile.WriteLine(luaFormatter.CreateFormattedUIObject(index, tableName, gameObjects[index]));
				}
			}
		}

		/// <summary>
		/// Checks if the filename already exists.
		/// If it does it adds (1) to the filename and checks if that exists.
		/// Returns a valid filename.
		/// </summary>
		/// <param name="fileName"></param>
		private string createFileName(string fileName)
		{
			string tempFileLoc = directory + fileName + ".lua";
			UnityEngine.Debug.LogFormat("Checking if file: {0} exists", tempFileLoc);

			if (File.Exists(tempFileLoc))
			{
				UnityEngine.Debug.LogFormat("File already exists.");
				string newFileName = string.Format("{0}({1})", fileName, 1);
				return createFileName(newFileName);
			}
			else
			{
				UnityEngine.Debug.LogFormat("{0}.lua doesn't exist yet", fileName);
				return tempFileLoc;
			}
		}
	}
}