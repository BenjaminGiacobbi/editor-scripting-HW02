using UnityEngine;

public class Cube : MonoBehaviour
{
    public float _baseSize = 1;

    void Start()
    {
        GenerateColor();
    }

    private void Update()
    {
        float animation = _baseSize + Mathf.Sin(Time.time * 8f) * _baseSize / 7f;
        transform.localScale = Vector3.one * animation;
    }

    public void GenerateColor()
    {
        gameObject.GetComponent<Renderer>().sharedMaterial.color = Random.ColorHSV(); 
    }

    public void ResetColor()
    {
        gameObject.GetComponent<Renderer>().sharedMaterial.color = Color.white;
    }
}
