using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Rainbow : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private float _duration;
    void Start()
    {
        StartCoroutine(BecomeRainbow(_material, _duration));
    }

    private IEnumerator BecomeRainbow(Material material, float duration)
    {
        Color32[] colorArray = new Color32[7] { new Color32(255, 0, 0, 1), new Color32(255, 127, 0, 1), new Color32(255, 255, 0, 1), new Color32(0, 255, 0, 1), new Color32(0, 0, 255, 1), new Color32(75, 0, 130, 1), new Color32(148, 0, 211, 1)};
        Color32 startColor = material.color;
        float currentTime = 0;

        foreach (var targetColor in colorArray)
        {
            while (currentTime < duration)
            {
                Color32 currentColor = Color32.Lerp(startColor, targetColor, currentTime / duration);
                material.color = currentColor;
                currentTime += Time.deltaTime;

                yield return null;
            }
            material.color = targetColor;
            startColor = targetColor;
            currentTime = 0;
            yield return null;
        }

    }
}
