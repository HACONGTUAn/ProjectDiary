using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


    public class RemoveAllMissingFromHierarchy : MonoBehaviour
    {
#if UNITY_EDITOR
    [ContextMenu("Remove ALL Missing Scripts (Self + Children)")]
    public void RemoveMissingScriptsRecursive()
    {
        int totalRemoved = 0;
        Transform[] allTransforms = GetComponentsInChildren<Transform>(true);

        foreach (Transform t in allTransforms)
        {
            int removed = GameObjectUtility.RemoveMonoBehavioursWithMissingScript(t.gameObject);
            if (removed > 0)
            {
                Debug.Log($"Removed {removed} missing script(s) from: {t.name}", t.gameObject);
                totalRemoved += removed;
            }
        }

      
    }
#endif
}
[CustomEditor(typeof(RemoveAllMissingFromHierarchy))]
public class RemoveAllMissingFromHierarchyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        RemoveAllMissingFromHierarchy remover = (RemoveAllMissingFromHierarchy)target;

        GUILayout.Space(10);
        GUI.backgroundColor = Color.red;
        if (GUILayout.Button("Remove ALL Missing Scripts", GUILayout.Height(40)))
        {
            remover.RemoveMissingScriptsRecursive();
        }
        GUI.backgroundColor = Color.white;
    }
}
