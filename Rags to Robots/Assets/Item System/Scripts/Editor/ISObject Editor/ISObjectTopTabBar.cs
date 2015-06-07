using UnityEngine;
using System.Collections;

namespace WarpwareStudios.ItemSystem.Editor
{
	
	public partial class ISObjectEditor
	{
		
		bool weapon, armor, tools, components, consumables, about;

		void TopTabBar()
		{
			GUILayout.BeginHorizontal ("Box", GUILayout.ExpandWidth (true));

			WeaponTab ();
			ArmorTab (); 
			ToolsTab ();
			ComponentsTab ();
			ConsumablesTab ();
			AboutTab ();  

			GUILayout.EndHorizontal ();
		}

		//tab for weapons
		void WeaponTab()
		{
			if (GUILayout.Button ("Weapons")) 
			{
				ClearDetails();
				weapon = true;
				armor = false;
				tools = false;
				components = false;
				consumables = false;
				about = false;
			}
		}

		//tab for armor
		void ArmorTab()
		{
			if(GUILayout.Button ("Armor"))
			{
				ClearDetails();
				
				weapon = false;
				armor = true;
				tools = false;
				components = false;
				consumables = false;
				about = false;
			}
		}

		//tabs for tools
		void ToolsTab()
		{
			if(GUILayout.Button ("Tools"))
			{
				ClearDetails();
				
				weapon = false;
				armor = false;
				tools = true;
				components = false;
				consumables = false;
				about = false;
			}
		}

		//Tab for crafting components
		void ComponentsTab()
		{
			if(GUILayout.Button ("Components"))
			{
				ClearDetails();
				
				weapon = false;
				armor = false;
				tools = false;
				components = true;
				consumables = false;
				about = false;
			}
		}

		//tab for consumables
		void ConsumablesTab()
		{
			if(GUILayout.Button ("Consumables"))
			{
				ClearDetails();

				weapon = false;
				armor = false;
				tools = false;
				components = false;
				consumables = true;
				about = false;
			}
		}

		void AboutTab()
		{
			if(GUILayout.Button ("About"))
			{
				ClearDetails();
				weapon = false;
				armor = false;
				tools = false;
				components = false;
				consumables = false;
				about = true;
			}
		}
	}
}
