using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake (float duration)
    { 
        float elapsed = 0.0f;
        Vector3 originalPos = transform.position;
        while (elapsed < duration)
        {     
            float x = Random.Range(originalPos.x-1f, originalPos.x+1f);
            float y = Random.Range(originalPos.y-1f, originalPos.y+1f);

            transform.position = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null; 
        }
    }
}
