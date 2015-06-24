using UnityEngine;
using UnityEditor;
using System.Collections;

public class CustomAssetUtil : MonoBehaviour {

	public static T CreateAsset<T>(string path) where T : ScriptableObject{
		
		T asset = ScriptableObject.CreateInstance<T> ();
		
//		var newPath = AssetDatabase.GenerateUniqueAssetPath(path);
		
		AssetDatabase.CreateAsset(asset, "Assets/" + path + ".asset");
		
		AssetDatabase.SaveAssets();
		
		return asset;
		
	}

}
