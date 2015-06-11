using UnityEditor;
using UnityEngine;
using System.Collections;

namespace WarpwareStudios.ItemSystem.Editor
{

	public partial class ISQualityDatabaseEditor : EditorWindow 
	{
		ISQualityDatabase qualityDatabase;
		Texture2D selectedTexture;

		//List view scroll position variable
		Vector2 _scrollPos;
		//List view index of current item
		int selectedIndex = -1;

		const int SPRITE_BUTTON_SIZE = 45;

		const string DATABASE_NAME = @"WWSItemSystemQualityDatabase.asset";
		const string DATABASE_PATH = @"Database";

		//set up menu and hotkey
		[MenuItem("Warpware Studios/Database/Quality Editor %#w")]
		public static void init()
		{
			ISQualityDatabaseEditor window = EditorWindow.GetWindow<ISQualityDatabaseEditor> ();
			window.minSize = new Vector2 (400, 300);
			window.title = "Quality Database";
			window.Show ();
		}

		void OnEnable()
		{
			if(qualityDatabase == null)
				qualityDatabase = ISQualityDatabase.GetDatabase<ISQualityDatabase> (DATABASE_PATH, DATABASE_NAME);
		}

		void OnGUI()
		{
			ListView ();
			BottomBar ();
		}

		void BottomBar()
		{
			GUILayout.BeginHorizontal ("Box", GUILayout.ExpandWidth(true));

			GUILayout.Label ("Quality Levels: " + qualityDatabase.Count);

			if (GUILayout.Button ("Add")) 
			{
				qualityDatabase.Add (new ISQuality());
			}

			GUILayout.EndHorizontal();
		}

	}
}