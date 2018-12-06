using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueChanges : MonoBehaviour
{
    public ValueChanges valueChanges;
    public GameManager gameManager;
   


    public GameObject planet;
    public Material[] materials;



    public Image image;

    public Button sizeButton1;
    public Button sizeButton2;
    public Button sizeButton3;
    public Button sizeButton4;
    public Button sizeButton5;



    //Size Change Values
    public Vector3 size1;
    public Vector3 size2;
    public Vector3 size3;
    public Vector3 size4;
    public Vector3 size5;

    //Speed Change Values
    public float PlanetSpeed;
    public float speed1;
    public float speed2;
    public float speed3;
    public float speed4;
    public float speed5;

    public float NewSpeed;


    public bool changedValue;



    // Use this for initialization
    void Start()
    {
        valueChanges = this;
        changedValue = false;
    }

    // Update is called once per frame
    void Update()
    {
        print(changedValue);
    }
    



    //UI Handles and buttons
    // Color Change Buttons
    public void ColorChangeRed()
    {
       
            print("ChangeMe");
        //image.GetComponent<Image>().color = Color.red;
        
            planet.GetComponent<MeshRenderer>().material = materials[0];

        
    
        
    }
    public void ColorChangeGreen()
    {

            //image.GetComponent<Image>().color = Color.green;
            planet.GetComponent<MeshRenderer>().material = materials[1];
       
    }
    public void ColorChangeBlue()
    {
        
            //image.GetComponent<Image>().color = Color.blue;
            planet.GetComponent<MeshRenderer>().material = materials[2];

        
    }


    // Size Change Buttons
    public void SizeChange1()
    {

            //image.rectTransform.sizeDelta = new Vector2(25, 25);
            planet.GetComponent<Transform>().localScale = size1;
           

        

    }
    public void SizeChange2()
    {
       
            //image.rectTransform.sizeDelta = new Vector2(50, 50);
            planet.GetComponent<Transform>().localScale = size2;
          


        
    }
    public void SizeChange3()
    {
        
            //image.rectTransform.sizeDelta = new Vector2(75, 75);
            planet.GetComponent<Transform>().localScale = size3;
         
    


    }
    public void SizeChange4()
    {
        
            //image.rectTransform.sizeDelta = new Vector2(100, 100);
            planet.GetComponent<Transform>().localScale = size4;
         


        

    }
    public void SizeChange5()
    {
          //image.rectTransform.sizeDelta = new Vector2(200, 200);
            planet.GetComponent<Transform>().localScale = size5;
       
 
    }


    //SpeedChange Buttons
    public void SpeedChange1()
    {
        
        changedValue = true;
        gameManager.ChangeSpeed = true;
        NewSpeed = speed1;
        //PlanetSpeed = PlanetSpeed* speed1;
        
        
    }
    public void SpeedChange2()
    {
        changedValue = true;
        gameManager.ChangeSpeed = true;
        NewSpeed = speed2;
       // PlanetSpeed = PlanetSpeed * speed2;
    }
    public void SpeedChange3()
    {
        changedValue = true;
        gameManager.ChangeSpeed = true;
        NewSpeed = speed3;
      
       // PlanetSpeed = PlanetSpeed * speed3;
    }
    public void SpeedChange4()
    {
        changedValue = true;
        gameManager.ChangeSpeed = true;
        NewSpeed = speed4;
       // PlanetSpeed = PlanetSpeed * speed4;
    }
    public void SpeedChange5()
    {
        changedValue = true;
        gameManager.ChangeSpeed = true;
        NewSpeed = speed5;
        //PlanetSpeed = PlanetSpeed * speed5;
    }

  

}
