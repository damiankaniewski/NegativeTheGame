using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFader : MonoBehaviour
{
    public Transform player;
    public float fadeDistance = 10f;
    
    private GameObject textMeshTransform;
    private GameObject textMeshShadowTransform;
    private TextMeshPro textMesh;
    private TextMeshPro textMeshShadow;

    void Start()
    {
        textMeshShadowTransform = transform.GetChild(0).gameObject;
        textMeshTransform = transform.GetChild(1).gameObject;
        
        textMesh = textMeshTransform.GetComponent<TextMeshPro>();
        textMeshShadow = textMeshShadowTransform.GetComponent<TextMeshPro>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        float alpha = Mathf.Clamp01(1 - (distance / fadeDistance));
        
        textMesh.color = new Color(1, 1, 1, alpha);
        textMeshShadow.color = new Color(0, 0, 0, alpha);
        Debug.Log(textMesh.color);
    }
}
