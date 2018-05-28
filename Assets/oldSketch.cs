using UnityEngine;
using System.Collections;

public class oldSketch : MonoBehaviour {

    public GameObject myPrefab;

    // Use this for initialization
    void Start() { 
    
        int totalCubes = 30;
        float totalDistance = 2.9f;
             
        //sin distro
        for (int i = 0; i < totalCubes; i++)
        {
            float perc = i / (float)totalCubes;
            float sin = Mathf.Sin(perc * Mathf.PI/2);

            float x = 1.8f + sin * totalDistance;
            float y = 5.0f;
            float z = 0.0f;
            
            var newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);

            newCube.GetComponent<CubeScript>().SetSize(.45f * (1.0f - perc));
            newCube.GetComponent<CubeScript>().rotateSpeed = .2f + perc*4.0f;
            newCube.transform.Find("New Text").GetComponent<TextMesh>().text = "Hullo Again";
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
