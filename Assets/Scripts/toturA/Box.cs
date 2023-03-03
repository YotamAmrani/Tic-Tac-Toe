using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Mark mark;
    public int index;
    public bool isMarked;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        index = transform.GetSiblingIndex();
        isMarked = false;
        mark = Mark.None;
    }
    public void SetAsMarked(Sprite sprite, Mark mark)
    {
        this.isMarked = true;
        this.mark = mark;
        // spriteRenderer.color = color;
        spriteRenderer.sprite = sprite;
        Debug.Log(mark);
        // Disable the circle collider
        GetComponent<CircleCollider2D>().enabled = false;
    }
}
