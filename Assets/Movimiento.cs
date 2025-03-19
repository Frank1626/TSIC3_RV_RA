using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Movimiento : MonoBehaviour
{
    public GameObject model;
    public ObserverBehaviour[] ImageTargets;
    // Nos indica el marcador actual.
    public int currentTarget;
    // Velocidad con la cual se traslada mi modelo.
    public float speed = 1.0f;
    // Control interno dentro del código
    private bool isMoving = false;
    // Nos movemos al siguiente marcador
    
    public void moveToNextMarker(int targetIndex)
    {
        if (!isMoving && ImageTargets != null && targetIndex >= 0 && targetIndex < ImageTargets.Length)
        {
            if (ImageTargets[targetIndex] == null)
            {
                Debug.LogError("El ImageTarget en la posición " + targetIndex + " es null.");
                return;
            }
            
            StartCoroutine(MoveModel(targetIndex));
        }
        else
        {
            Debug.LogError("El índice es inválido o ImageTargets es null.");
        }
    }

    // Realizando una corutina.
    private IEnumerator MoveModel(int targetIndex)
    {
        isMoving = true;

        // Verifica si el modelo está asignado.
        if (model == null)
        {
            Debug.LogError("El modelo no está asignado.");
            isMoving = false;
            yield break;
        }

        // Verifica si el target es válido y tiene un TargetStatus con un valor adecuado.
        ObserverBehaviour target = ImageTargets[targetIndex];

        if (target == null || target.TargetStatus.Status == Status.NO_POSE)
        {
            Debug.LogError("El Target en el índice " + targetIndex + " es null o no tiene un estado válido.");
            isMoving = false;
            yield break;
        }

        // Verifica si el target está correctamente seguido.
        if (target.TargetStatus.Status != Status.TRACKED && target.TargetStatus.Status != Status.EXTENDED_TRACKED)
        {
            Debug.LogWarning("El estado del target no es TRACKED ni EXTENDED_TRACKED.");
            isMoving = false;
            yield break;
        }

        // Obtener posiciones
        Vector3 startPosition = model.transform.position;
        Vector3 endPosition = target.transform.position;

        // Trazando la trayectoria a realizar
        float journey = 0;

        while (journey <= 1f)
        {
            // Velocidad a la que se mueven los elementos.
            journey += Time.deltaTime * speed;
            model.transform.position = Vector3.Lerp(startPosition, endPosition, journey);
            yield return null;
        }

        isMoving = false;
    }
}

