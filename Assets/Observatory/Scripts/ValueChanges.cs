using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueChanges : MonoBehaviour
{
    public GameObject planet;
    public Material material;

    public Image image;

    public int size;
    private float planetSize;

    public Button sizeButton;


    public void ColorChange()
    {   
        //image.GetComponent<Image>().color = Color.blue;
        planet.GetComponent<MeshRenderer>().material = material;        
    }

    public void SizeChange()
    {
        if (size == 1)
        {
            planetSize = 5.5f;
        }
        else if (size == 2)
        {
            planetSize = 6;
        }
        else if (size == 3)
        {
            planetSize = 6.5f;
        }
        else if (size == 4)
        {
            planetSize = 7;
        }
        else if (size == 5)
        {
            planetSize = 7.5f;
        }

        planet.GetComponent<Transform>().localScale = new Vector3(planetSize, planetSize, planetSize);
        
    }

    public void SpeedChange()
    {
        if (gameObject.tag == "sizeOne")
        {
            image.GetComponent<Movement>().speed = 0.1f;
            print("button1");
        }

        if (gameObject.tag == "sizeTwo")
        {
            image.GetComponent<Movement>().speed = 0.2f;
            print("BUTTON2");

        }

        if (gameObject.tag == "sizeThree")
        {
            image.GetComponent<Movement>().speed = 0.5f;
            print("BUTTON3");

        }

        if (gameObject.tag == "sizeFour")
        {
            image.GetComponent<Movement>().speed = 1;
            print("BUTTON4");

        }

        if (gameObject.tag == "sizeFive")
        {
            image.GetComponent<Movement>().speed = 1.5f;
            print("BUTTON5");

        }
    }
}
