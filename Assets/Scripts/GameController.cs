using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameController : MonoBehaviour {

    private List<Vector3> gameMatrix;

    public GameObject ouros; 

    // Use this for initialization
    void Awake() {
        gameMatrix = CreateMatrix();

        SetupScene(12, ouros);

    }

    void SetupScene(int level, GameObject Obj)
    {
        for (int i = 0; i < level; i++)
        {
            Instantiate(Obj, PosRan(), Quaternion.identity);
        }
    }

    Vector3 PosRan()
    {
        int randomIndex = Random.Range(0, gameMatrix.Count);
        Vector3 randomPos = gameMatrix[randomIndex];
        gameMatrix.RemoveAt(randomIndex);

        return randomPos;
    }

    List<Vector3> CreateMatrix()
    {
        List<Vector3> matrix = new List<Vector3>();
        for (int x = -9; x < 10; x = x + 3)
        {
            for (int y = -9; y < 10; y = y + 3)
            {
                if (x != 0 & y != 0)
                {
                    matrix.Add(new Vector3(x, y, 0f));
                }
            }
        }

        return matrix;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
