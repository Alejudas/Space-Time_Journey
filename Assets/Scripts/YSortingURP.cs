using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(TilemapRenderer))]
public class YSortingURP : MonoBehaviour
{
    public int sortingOffset = 0;
    private SpriteRenderer sr;
    private TilemapRenderer mr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        mr = GetComponent<TilemapRenderer>();
    }

    void LateUpdate()
    {
        sr.sortingOrder = -(int)(transform.position.y * 100) + sortingOffset;
        mr.sortingOrder = -(int)(transform.position.y * 100) + sortingOffset;
    }
}
