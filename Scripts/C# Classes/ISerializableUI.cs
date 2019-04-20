namespace CPP_LevelEditor
{
	public enum UI_TYPE { BACKGROUND, BUTTON, IMAGE, TEXT }
	public enum BUTTON { START, EXIT, CREDIT, CONTINUE, RETURN }
	public interface ISerializableUI
	{
		float GetWidth();
		float GetHeight();
		UnityEngine.Vector3 GetPosition();
		UnityEngine.Quaternion GetRotation();
		UnityEngine.Vector3 GetScale();
		UI_TYPE GetUIType();
		string GetFont();
		string GetImage();
		int GetFontSize();
		BUTTON GetButtonType();
		string GetFontText();
	}
}
