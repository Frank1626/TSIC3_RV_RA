using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public GameObject model;
    public Color color;
    public Material colorMaterial;
   
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeColor_BTN()
    {
        Color randomColor = Random.ColorHSV();

        // Aplica el color aleatorio al modelo
        model.GetComponent<Renderer>().material.color = randomColor;

        // Si hay un material asignado, cambia su color también
        if (colorMaterial != null)
        {
            colorMaterial.color = randomColor;
        }
    }
}
