using System.Collections.Generic;
using Opsive.UltimateCharacterController.Camera;
using Opsive.UltimateCharacterController.Events;
using UnityEngine;
using Utils;

public class OnPerspectiveSwitch : MonoBehaviour
{
    public CameraController cameraController;
    // public Material invisibleMaterial;
    public List<SkinnedMeshRenderer> invisibleWhenFPS;
    public Transform itemsParentRight;
    public Transform itemsParentLeft;

    private void Start()
    {
        cameraController.OnChangePerspectivesEvent.AddListener(DisableMesh);
    }

    void DisableMesh(bool perspective)
    {
        foreach (var meshRenderer in invisibleWhenFPS)
        {
            meshRenderer.enabled = !perspective;
        }

        DisableAllChildMesh(itemsParentLeft, !perspective);
        DisableAllChildMesh(itemsParentRight, !perspective);
    }

    void DisableAllChildMesh(Transform parent, bool disabled)
    {
        foreach (var child in Tools.GetChildRecursive(parent.transform))
        {
            MeshRenderer mesh = child.gameObject.GetComponent<MeshRenderer>();
            SkinnedMeshRenderer skinnedMesh = child.gameObject.GetComponent<SkinnedMeshRenderer>();
            if(mesh != null) 
                mesh.enabled = disabled;
            if (skinnedMesh != null) 
                skinnedMesh.enabled = disabled;
        }
    }
}
