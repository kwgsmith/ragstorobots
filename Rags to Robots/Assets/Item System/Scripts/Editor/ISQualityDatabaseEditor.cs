using UnityEditor;
using UnityEngine;
using System.Collections;

namespace WarpwareStudios.ItemSystem.Editor
{

	public class ISQualityDatabaseEditor : EditorWindow 
	{
		ISQualityDatabase qualityDatabase;
		ISQuality selectedItem;
		Texture2D selectedTexture;

		const int SPRITE_BUTTON_SIZE = 90;

		const string FILE_NAME = @"WWSItemSystemQualityDatabase.asset";
		const string DATABASE_FOLDER_NAME = @"Databases";
		const string DATABASE_FULL_PATH = @"Assets/Item System/" + DATABASE_FOLDER_NAME + "/" + FILE_NAME;

		//set up menu and hotkey
		[MenuItem("Warpware Studios/Database/Quality Editor %#i")]
		public static void init()
		{
			ISQualityDatabaseEditor window = EditorWindow.GetWindow<ISQualityDatabaseEditor> ();
			window.minSize = new Vector2 (400, 300);
			window.title = "Quality Database";
			window.Show ();
		}

		void OnEnable()
		{
			selectedItem = new ISQuality ();

			qualityDatabase = AssetDatabase.LoadAssetAtPath (DATABASE_FULL_PATH, typeof(ISQualityDatabase)) as ISQualityDatabase;
			if (qualityDatabase == null) 
			{
				if (!AssetDatabase.IsValidFolder("Assets/Item System/" + DATABASE_FOLDER_NAME))
				{
					AssetDatabase.CreateFolder("Assets/Item System", DATABASE_FOLDER_NAME);
				}
				qualityDatabase = ScriptableObject.CreateInstance<ISQualityDatabase>();
				AssetDatabase.CreateAsset(qualityDatabase, DATABASE_FULL_PATH);
				AssetDatabase.SaveAssets();
				AssetDatabase.Refresh();
			}
		}

		void OnGUI()
		{
			AddQualityToDatabase ();
		}

		void AddQualityToDatabase()
		{
			selectedItem.Name = EditorGUILayout.TextField ("Name: ", selectedItem.Name);
			if (selectedItem.Icon)
				selectedTexture = selectedItem.Icon.texture;
			else
				selectedTexture = null;

			//button to show sprite as well as choose it
			if (GUILayout.Button (selectedTexture, GUILayout.Width (SPRITE_BUTTON_SIZE), GUILayout.Height (SPRITE_BUTTON_SIZE))) 
			{
				//On click bring up object picker window
				int controlID = EditorGUIUtility.GetControlID(FocusType.Passive);
				EditorGUIUtility.ShowObjectPicker<Sprite>(null, true,null,controlID);
			}

			//assign chosen object to selectedItem's sprite
			string commandName = Event.current.commandName;
			if (commandName == "ObjectSelectorUpdated") 
			{
				selectedItem.Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
				Repaint();
			}

			if (GUILayout.Button ("Save")) 
			{
				if(selectedItem == null)
					return;

				qualityDatabase.database.Add(selectedItem);
				selectedItem = new ISQuality();
			}
		}
	}
}