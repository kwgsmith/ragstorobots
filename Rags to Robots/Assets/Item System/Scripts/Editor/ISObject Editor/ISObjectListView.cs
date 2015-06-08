using UnityEngine;
using System.Collections;

namespace WarpwareStudios.ItemSystem.Editor
{
	
	public partial class ISObjectEditor
	{
		Vector2 _scrollPos = Vector2.zero;
		int _listViewWidth = 200;

		void ListView()
		{
			_scrollPos = GUILayout.BeginScrollView (_scrollPos, "Box", GUILayout.Width(_listViewWidth), GUILayout.ExpandHeight(true));

			ShowList ();

			GUILayout.EndScrollView ();
		}

		void ShowList()
		{
			GUILayout.BeginVertical (GUILayout.ExpandWidth (true), GUILayout.ExpandHeight (true));

			if (weapon)
				ShowWeapons ();
			if (armor)
				ShowArmor();
			if (tools)		
				ShowTools ();
			if (components)
				ShowComponents();
			if (consumables)
				ShowConsumables();

			GUILayout.EndVertical ();
		}

		void ShowWeapons()
		{
			for (int i = 0; i < weaponDatabase.Count; i++) 
			{
				ISObject chosen = weaponDatabase.Get(i);
				if(GUILayout.Button(chosen.Name, "Label"))
				{
					weapon = true;
					showNewWeaponDetails = true;
					temp = chosen;
				}
			}
		}

		void ShowArmor()
		{
			for (int i = 0; i < armorDatabase.Count; i++) 
			{
				ISObject chosen = armorDatabase.Get(i);
				if(GUILayout.Button(chosen.Name, "Label"))
				{
					armor = true;
					showNewArmorDetails = true;
					tempArmor = (ISArmor)chosen;
				}
			}
		}

		void ShowTools()
		{
		}

		void ShowComponents()
		{
			for (int i = 0; i < componentDatabase.Count; i++) 
			{
				ISObject chosen = componentDatabase.Get(i);
				if(GUILayout.Button(chosen.Name, "Label"))
				{
					components = true;
					showNewComponentDetails = true;
					tempComponent = (ISComponent)chosen;
				}
			}
		}

		void ShowConsumables()
		{
		}
	}
}
