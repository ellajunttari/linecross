using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject pointPrefab;
    public int gridWidth = 15;
    public int gridHeight = 15;
    public Camera mainCamera;

    private GameObject[,] points;
    private LineRenderer[,] lines;

    // Start is called before the first frame update
    void Start()
    {
        StartGrid();
    }

    void DrawSquare(LineRenderer line, int x, int y)
    {
        List<Vector3> linePoints = new List<Vector3>();
        linePoints.Add(new Vector3(x, y + 1));
        linePoints.Add(new Vector3(x, y));
        linePoints.Add(new Vector3(x + 1, y));
        linePoints.Add(new Vector3(x + 1, y + 1));
        linePoints.Add(new Vector3(x, y + 1));
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.positionCount = 5;
        line.SetPositions(linePoints.ToArray());
        line.useWorldSpace = true;
    }

    void StartGrid()
    {
        // Create an array of point GameObjects and LineRenderers
        points = new GameObject[gridWidth, gridHeight];
        lines = new LineRenderer[gridWidth, gridHeight];
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                points[x, y] = Instantiate(pointPrefab, new Vector3(x, y), Quaternion.identity);
                lines[x, y] = points[x, y].AddComponent<LineRenderer>();
                DrawSquare(lines[x, y], x, y);
            }
        }
        mainCamera.transform.position = new Vector3(gridWidth/2, gridHeight/2, mainCamera.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}