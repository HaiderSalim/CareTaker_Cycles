using UnityEngine;
using UnityEditor;

public class UCXColliderSetup : MonoBehaviour
{
    [MenuItem("Tools/Setup UCX Colliders")]
    static void SetupColliders()
    {
        foreach (GameObject go in Selection.gameObjects)
        {
            var meshObjects = go.GetComponentsInChildren<Transform>();
            foreach (var t in meshObjects)
            {
                if (t.name.StartsWith("UCX_"))
                {
                    GameObject colGO = t.gameObject;
                    MeshCollider collider = colGO.GetComponent<MeshCollider>();
                    if (collider == null)
                        collider = colGO.AddComponent<MeshCollider>();
                    
                    colGO.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }

        Debug.Log("✅ UCX Colliders setup complete.");
    }
}