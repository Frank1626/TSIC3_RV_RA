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

        // Generar un color aleatorio brillante y saturado
        Color randomColor = Random.ColorHSV(0f, 1f, 0.6f, 1f, 0.7f, 1f);

        // Establecer el color correctamente sin afectar transparencia
        colorMaterial.SetColor("_Color", randomColor); // Para Standard Shader
        // colorMaterial.SetColor("_BaseColor", randomColor); // Para URP Shader

        // Elegir una textura aleatoria
        Texture randomTexture = textures[Random.Range(0, textures.Length)];
        colorMaterial.mainTexture = randomTexture;

        // Aplicar el material al modelo
        renderer.material = colorMaterial;
    }
}
