using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

public class Pointer : MonoBehaviour {

    public Tilemap map;
    public Camera playerCam;

    public GameObject[,] gridArray;  
    public GameObject gridMapParent;

    public GameObject grass;
    public GameObject sky;

    public Transform temp;

    private int height = 5;
    private int width = 40;

	// Use this for initialization
	void Start () {
        GenerateGrid();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0))
        {
            Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            { //sets selection, waits for confirmation to claim
                if (hit.collider.gameObject.transform.position.y == -2 && !hit.collider.gameObject.GetComponent<Cultivation>().clickable)
                hit.collider.gameObject.GetComponent<Cultivation>().plantSeedOne = true;
                DisableArea1(hit);
                Debug.Log(hit.transform);
            }
        }
    }

    public void GenerateGrid()
    {
        gridArray = new GameObject[height * 2,width * 2];

        for (int i = width * -1; i < width; i++)
        {
            for (int j = height * -1; j < height; j++)
            {
                GameObject temp;
                if (j < 0) temp = Instantiate(grass);
                else temp = Instantiate(sky);
                temp.transform.parent = gridMapParent.transform;
                temp.transform.position = map.CellToWorld(new Vector3Int(i, j, 0));
                gridArray[j + height, i + width] = temp;
            }

        }
    }

    public void DisableArea1(RaycastHit hit)
    {
        for (int i = -2; i < 3; i++)
        {
            //gridArray[5, ].gameObject.GetComponent<Cultivation>().clickable = false;
        }
    }
}
