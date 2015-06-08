using UnityEngine;
using System.Collections;

namespace WarpwareStudios.ItemSystem.Editor
{
	
	public partial class ISObjectEditor
	{
		void BottomStatusBar()
		{
			GUILayout.BeginHorizontal ("Box", GUILayout.ExpandWidth (true));
			
			GUILayout.Label ("StatusBar");
			
			GUILayout.EndHorizontal ();
		}
	}
}
