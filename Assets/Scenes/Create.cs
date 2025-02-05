// UMD IMDM290 
// Instructor: Myungin Lee
// Drawing spheres aligned in a heart shape with colors.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    GameObject[] spheres;
    static int numSphere = 100; 
    Vector3[] initPos;

    void Start()
    {
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
}

