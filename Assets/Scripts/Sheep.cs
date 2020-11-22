using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{

    [SerializeField] private SpriteRenderer sheepRenderer;
    [SerializeField] private Sprite cutSheepSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Shaving()
    {
        sheepRenderer.sprite = cutSheepSprite;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0) == false) return;
        Shaving();
    }
}
