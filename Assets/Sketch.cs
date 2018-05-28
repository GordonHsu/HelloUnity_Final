using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using
using System.Collections;
using UnityEngine.Networking;

public class Sketch : MonoBehaviour {
    public GameObject myPrefab;
    string _WebsiteURL = "https://ghsu477.azurewebsites.net/tables/product?zumo-api-version=2.0.0";

    public float X { get; private set; }
    public float Y { get; private set; }
    public float Z { get; private set; }
    //string jsonResponse;



    void Start () {
        //Reguest.GET can be called passing in your ODATA url as a string in the form:
        //http://{Your Site Name}.azurewebsites.net/tables/{Your Table Name}?zumo-api-version=2.0.0
        //The response produce is a JSON string
        //old code string jsonResponse = Request.GET(_WebsiteURL);



        WWW myWww = new WWW(_WebsiteURL);
        while (myWww.isDone == false) ;
        //{ }
        string jsonResponse = myWww.text;

        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
        Emergency[] emergencies = JsonReader.Deserialize<Emergency[]>(jsonResponse);

        //----------------------
        //YOU WILL NEED TO DECLARE SOME VARIABLES HERE SIMILAR TO THE CREATIVE CODING TUTORIAL

        int i = 0;
        int totalCubes = 30;
        float totalDistance = 2.9f;
        //----------------------

        //We can now loop through the array of objects and access each object individually
        foreach (Emergency emergency in emergencies)
        {
            //Example of how to use the object
            Debug.Log("This Emergency name is: " + emergency.EmergencyName);
            //----------------------
            //YOUR CODE TO INSTANTIATE NEW PREFABS GOES HERE

            X = emergency.x;
            Y = emergency.y;
            Z = emergency.z;
            float perc = i / (float)totalCubes;
            float sin = Mathf.Sin(perc * Mathf.PI / 2);

            float x = 1.8f + sin * totalDistance;
            float y = 5.0f;
            float z = 0.0f;

            var newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);

            newCube.GetComponent<CubeScript>().SetSize(.45f * (1.0f - perc));
            newCube.GetComponent<CubeScript>().rotateSpeed = .2f + perc * 4.0f;
            newCube.transform.Find("New Text").GetComponent<TextMesh>().text = emergency.EmergencyName;//"Hullo Again";
            i++;

            //----------------------
        }
	}



    // Update is called once per frame
    void Update () {
	
	}

}
