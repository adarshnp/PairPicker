using UnityEngine;
using TMPro;
public class FPSCounter : MonoBehaviour
{
    public TMP_Text fpsText; 
    private float deltaTime = 0.0f;

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString() + " FPS";
    }
}
