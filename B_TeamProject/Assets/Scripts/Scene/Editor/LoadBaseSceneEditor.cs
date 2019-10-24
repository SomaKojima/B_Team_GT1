using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.IO;

// エディター拡張クラス
[CustomEditor(typeof(LoadBaseScene))]
public class EditorLoadBaseScene : Editor
{
    LoadBaseScene obj;
    SerializedProperty o_scenePath;


    private void OnEnable()
    {
        obj = (LoadBaseScene)target;
        o_scenePath = serializedObject.FindProperty("scenePath");
    }

    public override void OnInspectorGUI()
    {

        OnInspectorPullDownOfScenePath();

        serializedObject.ApplyModifiedProperties();
    }

    // シーンパス選択のプルダウン
    private void OnInspectorPullDownOfScenePath()
    {
        // プルダウンに表示する文字列
        List<string> sceneNames = new List<string>();

        // ビルド設定に登録されているシーンを取得
        EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
        int index = 0;          // インデックス
        int selectedIndex = 0;  // 選択中のシーン
        foreach (EditorBuildSettingsScene scene in scenes)
        {
            // ファイルネームを取得
            string fileName = Path.GetFileName(scene.path);
            sceneNames.Add(fileName);
            // 選択中のシーンを見つける
            if (o_scenePath.stringValue == scene.path)
            {
                selectedIndex = index;
            }

            index++;
        }

        // 選択中のシーンの更新
        o_scenePath.stringValue = scenes[EditorGUILayout.Popup(selectedIndex, sceneNames.ToArray())].path;
    }
}