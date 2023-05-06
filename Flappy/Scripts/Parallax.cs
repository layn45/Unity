using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer MeshRenderer;
    public float animationSpeed =1f;
    // Start is called before the first frame update
    private void Awake()
    {
        MeshRenderer =GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        MeshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime,0);
    }
}
