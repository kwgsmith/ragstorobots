using UnityEditor;
using UnityEngine;
using System.Collections;

namespace WarpwareStudios.ItemSystem.Editor
{
	
	public partial class ISObjectEditor : EditorWindow 
	{
		ISWeaponDatabase weaponDatabase;
		ISArmorDatabase armorDatabase;
		ISToolDatabase toolDatabase;
		ISComponentDatabase componentDatabase;
		ISConsumableDatabase consumableDatabase;

		const string WEAPON_DATABASE_NAME = @"WWSItemSystemWeaponDatabase.asset";
		const string ARMOR_DATABASE_NAME = @"WWSItemSystemArmorDatabase.asset";
		const string TOOL_DATABASE_NAME = @"WWSItemSystemToolDatabase.asset";
		const string COMPONENT_DATABASE_NAME = @"WWSItemSystemComponentDatabase.asset";
		const string CONSUMABLE_DATABASE_NAME = @"WWSItemSystemConsumableDatabase.asset";
		const string DATABASE_PATH = @"Database";
		const string DATABASE_FULL_PATH = @"Assets/Item System/" + DATABASE_PATH + "/" + WEAPON_DATABASE_NAME;

		//set up menu and hotkey
		[MenuItem("Warpware Studios/Database/Item Editor %#w")]
		public static void init()
		{
			ISObjectEditor window = EditorWindow.GetWindow<ISObjectEditor> ();
			window.minSize = new Vector2 (800, 600);
			window.title = "Item System";
			window.Show ();
		}

		void OnEnable()
		{
			if(weaponDatabase == null)
				weaponDatabase = ISWeaponDatabase.GetDatabase<ISWeaponDatabase> (DATABASE_PATH, WEAPON_DATABASE_NAME);
			if(armorDatabase == null)
				armorDatabase = ISArmorDatabase.GetDatabase<ISArmorDatabase> (DATABASE_PATH, ARMOR_DATABASE_NAME);
			if(toolDatabase == null)
				toolDatabase = ISToolDatabase.GetDatabase<ISToolDatabase> (DATABASE_PATH, TOOL_DATABASE_NAME);
			if(componentDatabase == null)
				componentDatabase = ISComponentDatabase.GetDatabase<ISComponentDatabase> (DATABASE_PATH, COMPONENT_DATABASE_NAME);
			if(consumableDatabase == null)
				consumableDatabase = ISConsumableDatabase.GetDatabase<ISConsumableDatabase> (DATABASE_PATH, CONSUMABLE_DATABASE_NAME);

		}

		void OnGUI()
		{
			TopTabBar ();

			GUILayout.BeginHorizontal ();

			ListView ();
			ObjectDetails ();
		
			GUILayout.EndHorizontal ();

			BottomStatusBar ();
		}
	}
}