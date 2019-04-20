using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CPP_LevelEditor
{
	public class SerializableUI : MonoBehaviour, ISerializableUI
	{
		RectTransform rectTransform;

		[SerializeField] UI_TYPE ui_Type = UI_TYPE.IMAGE;
		[SerializeField] BUTTON buttonType = BUTTON.CONTINUE;
		[SerializeField] string imagePath = "mge/UI/";
		[SerializeField] string fontPath = "mge/UI/";
		[SerializeField] int fontSize = 16;
		[SerializeField] string Text = "";
		void Start()
		{
			rectTransform = GetComponent<RectTransform>();
		}

		public float GetHeight()
		{
			return rectTransform.rect.height;
		}

		public Vector3 GetPosition()
		{
			return rectTransform.position;
		}

		public Quaternion GetRotation()
		{
			return rectTransform.rotation;
		}

		public Vector3 GetScale()
		{
			return rectTransform.localScale;
		}

		public float GetWidth()
		{
			return rectTransform.rect.width;
		}

		public UI_TYPE GetUIType()
		{
			return ui_Type;
		}

		public string GetFont()
		{
			return fontPath;
		}

		public string GetImage()
		{
			return imagePath;
		}

		public int GetFontSize()
		{
			return fontSize;
		}

		public BUTTON GetButtonType()
		{
			return buttonType;
		}

		public string GetFontText()
		{
			return Text;
		}
	}
}
