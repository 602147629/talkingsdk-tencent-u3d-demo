/**
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -quit \
  -projectPath $PROJECT_PATH \
  -executeMethod CommandBuild.BuildAndroid
*/

// Assets/Editor/CommandBuile.cs
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections.Generic;

public class CommandBuild
{
	static List<string> levels = new List<string>();
	public static void BuildAndroid()
	{
		foreach ( EditorBuildSettingsScene scene in EditorBuildSettings.scenes ) {
			if ( !scene.enabled ) continue;
			levels.Add( scene.path );
		}
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.Android);
        string[] scenes = { "Assets/aaa.unity" };
		string res = BuildPipeline.BuildPlayer(scenes, "TalkingSdkU3dDemo.apk", BuildTarget.Android, BuildOptions.None );
		if (res.Length > 0)
			throw new Exception("BuildPlayer failure: " + res);
	}
}
