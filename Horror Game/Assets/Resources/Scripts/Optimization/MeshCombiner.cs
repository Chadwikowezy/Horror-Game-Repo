using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour
{
    public MeshFilter myFilter;

    private MeshFilter[] _filters;
    private Mesh _finalMesh;
    private CombineInstance[] _combiners;

    public void combineMesh()
    {
        Quaternion _oldRot = transform.rotation;
        Vector3 _oldPos = transform.position;
        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;

        _filters = GetComponentsInChildren<MeshFilter>();
        _finalMesh = new Mesh();
        _combiners = new CombineInstance [_filters.Length];

        for (int i = 0; i < _filters.Length; i++)
        {
            if (_filters[i].gameObject == gameObject)
                continue;

            _combiners[i].subMeshIndex = 0;
            _combiners[i].mesh = _filters[i].sharedMesh;
            _combiners[i].transform = _filters[i].transform.localToWorldMatrix;
        }

        _finalMesh.CombineMeshes(_combiners);
        GetComponent<MeshFilter>().sharedMesh = _finalMesh;

        transform.rotation = _oldRot;
        transform.position = _oldPos;
    }
}
