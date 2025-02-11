// UMD IMDM290 
// Instructor: Myungin Lee
// This tutorial introduce a way to draw spheres and align them in a circle with colors.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    GameObject[] spheres;
    static int numSphere = 50;
    float time = 0f;
    Vector3[] initPos;
    // Start is called before the first frame update
    void Start()
    {
        spheres = new GameObject[numSphere];
        initPos = new Vector3[numSphere];

        foreach (GameObject sphere in spheres)
        {
            // sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            // This will cause an error. Why?
            // foreach is a read only iterator that iterates dynamically classes that implement IEnumerable, each cycle in foreach will call the IEnumerable to get the next item, the item you have is a read only reference,
        }

        // Let there be spheres..
        spheres = new GameObject[numSphere];
        initPos = new Vector3[numSphere];

        float r = 2f;

        for (int i = 0; i < numSphere; i++)
        {
            float t = (2 * Mathf.PI * i) / numSphere;

            float x = r * (Mathf.Sqrt(2) * Mathf.Pow(Mathf.Sin(t), 3));
            float y = r * (-Mathf.Pow(Mathf.Cos(t), 3) - Mathf.Pow(Mathf.Cos(t), 2) + 2 * Mathf.Cos(t));

            initPos[i] = new Vector3(x, y, 0f);
            spheres[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            spheres[i].transform.position = initPos[i];
            // Get the renderer of the spheres and assign colors.
            Renderer sphereRenderer = spheres[i].GetComponent<Renderer>();
            // hsv color space: https://en.wikipedia.org/wiki/HSL_and_HSV
            float hue = (float)i / numSphere; // Hue cycles through 0 to 1
            Color color = Color.HSVToRGB(hue, 1f, 1f); // Full saturation and brightness
            sphereRenderer.material.color = color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        for (int i = 0; i < numSphere; i++)
        {
            spheres[i].transform.position = initPos[i] + new Vector3(0f, 0f, 3f * Mathf.Sin(time));
            Renderer sphereRenderer = spheres[i].GetComponent<Renderer>();
            float hue = (float)i / numSphere;
            Color color = Color.HSVToRGB(Mathf.Abs(hue * Mathf.Sin(time)), Mathf.Cos(time), 2f + Mathf.Cos(time));
            sphereRenderer.material.color = color;


            float size = Mathf.Abs(Mathf.Sin(time + i * 0.2f)) * 0.5f + 0.5f;
            spheres[i].transform.localScale = new Vector3(size, size, size);

            spheres[i].transform.Rotate(new Vector3(0f, 30f * Time.deltaTime, 0f));
        }
    }

}
