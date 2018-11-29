using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueChanges : MonoBehaviour
{

    public GameObject planet;
    public Material[] materials;



    public Image image;

    public Button sizeButton1;
    public Button sizeButton2;
    public Button sizeButton3;
    public Button sizeButton4;
    public Button sizeButton5;






    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ColorChange()
    {

        if (gameObject.tag == "colorRed")
        {
            //image.GetComponent<Image>().color = Color.red;
            planet.GetComponent<MeshRenderer>().material = materials[0];

        }

        if (gameObject.tag == "colorGreen")
        {
            //image.GetComponent<Image>().color = Color.green;
            planet.GetComponent<MeshRenderer>().material = materials[1];

        }

        if (gameObject.tag == "colorBlue")
        {
            //image.GetComponent<Image>().color = Color.blue;
            planet.GetComponent<MeshRenderer>().material = materials[2];

        }



    }

    public void SizeChange()
    {

        if (gameObject.tag == "sizeOne")
        {
            //image.rectTransform.sizeDelta = new Vector2(25, 25);
            planet.GetComponent<Transform>().localScale = new Vector3(0.4F, 0.4F, 0.4F);
            sizeButton1.GetComponent<Image>().color = Color.black;
            sizeButton1.GetComponent<Text>().color = Color.white;



        }

        if (gameObject.tag == "sizeTwo")
        {
            //image.rectTransform.sizeDelta = new Vector2(50, 50);
            planet.GetComponent<Transform>().localScale = new Vector3(0.6F, 0.6F, 0.6F);
            sizeButton2.GetComponent<Image>().color = Color.black;
            sizeButton2.GetComponent<Text>().color = Color.white;


        }

        if (gameObject.tag == "sizeThree")
        {
            //image.rectTransform.sizeDelta = new Vector2(75, 75);
            planet.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
            sizeButton3.GetComponent<Image>().color = Color.black;
            sizeButton3.GetComponent<Text>().color = Color.white;


        }

        if (gameObject.tag == "sizeFour")
        {
            //image.rectTransform.sizeDelta = new Vector2(100, 100);
            planet.GetComponent<Transform>().localScale = new Vector3(1.5F, 1.5F, 1.5F);
            sizeButton4.GetComponent<Image>().color = Color.black;
            sizeButton4.GetComponent<Text>().color = Color.white;


        }

        if (gameObject.tag == "sizeFive")
        {
            //image.rectTransform.sizeDelta = new Vector2(200, 200);
            planet.GetComponent<Transform>().localScale = new Vector3(6, 6, 6);
            sizeButton5.GetComponent<Image>().color = Color.black;
            sizeButton5.GetComponent<Text>().color = Color.white;


        }
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
