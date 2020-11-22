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
    public GameObject itemsParentRight;
    public GameObject itemsParentLeft;

    private void Start()
    {
        cameraController.OnChangePerspectivesEvent.AddListener(DisableMesh);
    }

    void DisableMesh(bool perspective)
    {
        MeshRenderer mesh;
        foreach (var meshRenderer in invisibleWhenFPS)
        {
            meshRenderer.enabled = !perspective;
        }

        foreach (var child in Tools.GetChildRecursive(itemsParentRight.transform))
        {
            mesh = child.gameObject.GetComponent<MeshRenderer>();
            if(mesh != null)
                mesh.enabled = !perspective;
            
        }
        
        foreach (var child in Tools.GetChildRecursive(itemsParentLeft.transform))
        {
            mesh = child.gameObject.GetComponent<MeshRenderer>();
            if(mesh != null)
                mesh.enabled = !perspective;
        }
    }
}
