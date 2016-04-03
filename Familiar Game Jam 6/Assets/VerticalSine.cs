using Extensions.UnityEngine;
using UnityEngine;
using System.Collections;

public class VerticalSine : MonoBehaviour
{

    public float yOrigin = 0.0f;
    public float amplitude = 0.5f;
    public float offset = 0.0f;
    public float frequency = 0.5f;

    public float time = 0.0f;

    void Update()
    {
        time += Time.deltaTime;
        this.transform.SetPositionY(yOrigin + (Mathf.Sin(time * frequency + offset) * amplitude),
                                    TransformSpace.Local);
    }

}