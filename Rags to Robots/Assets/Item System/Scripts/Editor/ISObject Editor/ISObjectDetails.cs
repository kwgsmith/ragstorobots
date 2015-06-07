using UnityEngine;
using System.Collections;

namespace WarpwareStudios.ItemSystem.Editor
{
	
	public partial class ISObjectEditor
	{

		ISObject temp = new ISWeapon();
		ISArmor tempArmor = new ISArmor();
		ISComponent tempComponent = new ISComponent();
		ISTool tempTool = new ISTool();
		ISConsumable tempConsumable = new ISConsumable();

		bool showNewWeaponDetails, showNewArmorDetails, showNewToolDetails, showNewComponentDetails, showNewConsumableDetails, showAbout;

		void ObjectDetails()
		{
			GUILayout.BeginVertical ("Box", GUILayout.ExpandWidth (true), GUILayout.ExpandHeight(true));

			GUILayout.BeginVertical (GUILayout.ExpandWidth (true), GUILayout.ExpandHeight(true));

			if (showNewWeaponDetails)
				DisplayNewWeapon ();
			if (showNewArmorDetails)
				DisplayNewArmor();
			if (showNewToolDetails)		
				DisplayNewTool ();
			if (showNewComponentDetails)
				DisplayNewComponent ();
			if (showNewConsumableDetails)
				DisplayNewConsumable ();
			if (showAbout)
				GUILayout.Label("About me");

			GUILayout.EndVertical ();
		
			GUILayout.BeginHorizontal (GUILayout.ExpandWidth (true));

			DisplayButtons ();
			GUILayout.EndHorizontal ();
			GUILayout.EndVertical ();
		}

		void DisplayNewWeapon()
		{
			temp.ShowStats ();
			
		}

		void DisplayNewArmor()
		{
			tempArmor.ShowStats ();	
		}

		void DisplayNewTool()
		{
			tempTool.ShowStats ();	
		}

		void DisplayNewComponent()
		{
			tempComponent.ShowStats ();	
		}

		void DisplayNewConsumable()
		{
			tempConsumable.ShowStats ();	
		}

		void DisplayButtons (){
			if (!weapon && !armor && !tools && !components && !consumables && !about) 
			{
				weapon = true;
			}
			if (!showNewWeaponDetails && weapon) 
			{
				if (GUILayout.Button ("Create Weapon")) 
				{
					Debug.Log ("Creating Weapon!");
					temp = new ISWeapon ();
					showNewWeaponDetails = true;
				}
			} 
			else if (!showNewArmorDetails && armor)
			{
				if (GUILayout.Button ("Create Armor")) {
					tempArmor = new ISArmor ();
					showNewArmorDetails = true;
				}
			}
			else if (!showNewToolDetails && tools)
			{
				if (GUILayout.Button ("Create Tool")) {
					tempTool = new ISTool ();
					showNewToolDetails = true;
				}
			}

			else if (!showNewComponentDetails && components)
			{
				if (GUILayout.Button ("Create Component")) {
					tempComponent = new ISComponent ();
					showNewComponentDetails = true;
				}
			}
			
			else if (!showNewConsumableDetails && consumables)
			{
				if (GUILayout.Button ("Create Consumable")) {
					tempConsumable = new ISConsumable ();
					showNewConsumableDetails = true;
				}
			}
			else if (about)
			{
				showAbout = true;
			}
			else 
			{
				 
				if (GUILayout.Button ("Save")) 
				{
					//add to weapon database
					if(weapon)
						weaponDatabase.Add((ISWeapon)temp);
					//add to armor database
					if(armor)
						armorDatabase.Add (tempArmor);
					//add to consumable database
					if(tools)
						toolDatabase.Add (tempTool);
					//add to consumable database
					if(components)
						componentDatabase.Add (tempComponent);
					//add to consumable database
					if(consumables)
						consumableDatabase.Add (tempConsumable);

					ClearDetails();
					ClearTemp();
				}
				
				if (GUILayout.Button ("Cancel")) 
				{
					ClearDetails();
					ClearTemp();
				}
			}
		}

		//gets the correct database to add the item to

		//clears the details screen for next object to show
		void ClearTemp()
		{
			tempTool = null;
			temp = null;
			tempArmor = null;
			tempComponent = null;
			tempConsumable = null;
		}

		//clears the details screen for next object to show
		void ClearDetails()
		{
			showNewWeaponDetails = false;
			showNewArmorDetails = false;
			showNewToolDetails = false;
			showNewComponentDetails = false;
			showNewConsumableDetails = false;
			showAbout = false;
		}
	}
}
