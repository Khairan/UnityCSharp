using UnityEngine;


[ExecuteInEditMode]
public class TestExecuteInEditMode : MonoBehaviour
{
    private void OnEnable()
    {
        var tempRenderer = GetComponent<Renderer>();
        if (tempRenderer != null) tempRenderer.material.color = Random.ColorHSV();
    }
}