using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class SyncBoxCollider : MonoBehaviour
{
    public RectTransform targetRectTransform;
    public BoxCollider boxCollider;
    public void UpdateColliderSize()
    {
        if (targetRectTransform == null) return;

        float x = targetRectTransform.rect.width;
        float y = targetRectTransform.rect.height;

        boxCollider.size = new Vector2(x, y);
        boxCollider.center = Vector3.zero;
    }
}
[CustomEditor(typeof(SyncBoxCollider))]
public class SyncBoxColliderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SyncBoxCollider script = (SyncBoxCollider)target;

        if (GUILayout.Button("UpdateBox"))
        {
            script.UpdateColliderSize();
        }
    }
}
