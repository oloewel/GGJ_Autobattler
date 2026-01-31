using UnityEngine;

class Waffen : MonoBehaviour
{
    [SerializeField] private Mesh newMesh;

    private MeshFilter meshFilter;

    void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
    }

    public void ChangeMesh()
    {
        if (meshFilter == null)
        {
            Debug.LogError("MeshFilter not found!");
            return;
        }

        if (newMesh == null)
        {
            Debug.LogError("New mesh is not assigned!");
            return;
        }

        meshFilter.mesh = newMesh;
    }

    void Funktion()
    {
        
    }
}
