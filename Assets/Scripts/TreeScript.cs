using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    public GameManager gameManager;
    private Material FoliageMat;
    [SerializeField]
    private GameObject TreeVer01, TreeVer02, TreeVer03, TreeVer04;

    private void Start()
    {
        FoliageMat = GetComponent<Material>();
        this.gameObject.GetComponent<MeshFilter>().sharedMesh = TreeVer01.GetComponent<Mesh>();
    }

    public void UpdateTree()
    {
        //change foliagemat based on socialcohesion level
       switch (gameManager.turnCounter)
        {
            case 1:
                this.gameObject.GetComponent<MeshFilter>().sharedMesh = TreeVer02.GetComponent<Mesh>();
                break;
            case 2:
                this.gameObject.GetComponent<MeshFilter>().sharedMesh = TreeVer03.GetComponent<Mesh>();
                break;
            case 3:
                this.gameObject.GetComponent<MeshFilter>().sharedMesh = TreeVer04.GetComponent<Mesh>();
                break;
        } 
    }
}
