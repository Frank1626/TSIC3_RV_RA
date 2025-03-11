using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public GameObject model; // Objeto al que aplicaremos la textura y el color
    public Material colorMaterial; // Material del objeto
    private Texture[] textures; // Array donde cargaremos las texturas

    void Start()
    {
        // Cargar todas las texturas desde "Resources/Texturas"
        textures = Resources.LoadAll<Texture>("Texturas");

        if (textures.Length == 0)
        {
            Debug.LogError("No se encontraron texturas en Resources/Texturas");
        }
    }

    public void ChangeColor_BTN()
    {
        if (model == null || colorMaterial == null || textures.Length == 0) return;

        Renderer renderer = model.GetComponent<Renderer>();

        // Generar un color aleatorio
        Color randomColor = Random.ColorHSV();
        colorMaterial.color = randomColor;

        // Elegir una textura aleatoria
        Texture randomTexture = textures[Random.Range(0, textures.Length)];
        colorMaterial.mainTexture = randomTexture;

        // Aplicar el material al modelo
        renderer.material = colorMaterial;
    }
}
