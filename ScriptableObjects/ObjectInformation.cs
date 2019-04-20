using UnityEngine;

namespace CPP_LevelEditor
{
	public enum OBJECT_TYPE { CAMERA, EXIT, BOX, PLAYER, START, TILE, SWITCH }

	[CreateAssetMenu(menuName = "ObjectInfo")]
	public class ObjectInformation : ScriptableObject
	{
		[SerializeField] OBJECT_TYPE objectType = OBJECT_TYPE.TILE;
		public OBJECT_TYPE GetObjectType() { return objectType; }
	}
}