using UnityEngine;
using UnityEditor;
using System.Collections;

namespace WarpwareStudios.ItemSystem.Editor
{
	
	public partial class ISQualityDatabaseEditor
	{
		//list all of the stored qualities in the database
		private void ListView()
		{
			_scrollPos = EditorGUILayout.BeginScrollView (_scrollPos, GUILayout.ExpandHeight(true));
			DisplayQualities ();

			EditorGUILayout.EndScrollView ();

		}

		//function that layouts the GUI elements on the window
		private void DisplayQualities()
		{
			for (int i = 0; i < qualityDatabase.Count; i++) 
			{
				//create horizontal layout
				GUILayout.BeginHorizontal("Box");

				//Sprite
				if (qualityDatabase.Get(i).Icon)
					selectedTexture = qualityDatabase.Get(i).Icon.texture;
				else
					selectedTexture = null;

				//button to show sprite as well as choose it
				if (GUILayout.Button (selectedTexture, GUILayout.Width (SPRITE_BUTTON_SIZE), GUILayout.Height (SPRITE_BUTTON_SIZE))) 
				{
					//On click bring up object picker window
					int controlID = EditorGUIUtility.GetControlID(FocusType.Passive);
					EditorGUIUtility.ShowObjectPicker<Sprite>(null, true,null,controlID);
					selectedIndex = i;
				}



				//assign chosen object to selectedItem's sprite
				string commandName = Event.current.commandName;
				if (commandName == "ObjectSelectorUpdated" ) 
				{
					if (selectedIndex != -1)
					{
						qualityDatabase.Get(i).Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
						selectedIndex = -1;
					}
					Repaint();
				}


				GUILayout.BeginVertical();
				//Name
				qualityDatabase.Get(i).Name = GUILayout.TextField(qualityDatabase.Get(i).Name);

				//delete button
				if(GUILayout.Button("X", GUILayout.Width(30), GUILayout.Height(30)))
				{
					if(EditorUtility.DisplayDialog("Delete", "Are you sure you want to delete " + qualityDatabase.Get(i).Name, "Delete", "Cancel"))
					{
						qualityDatabase.Remove(i);
					}
				}

				GUILayout.EndVertical();
				GUILayout.EndHorizontal();
			}
		}

	}
}
