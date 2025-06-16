using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(SpriteRenderer))]
public class YSortingURP : MonoBehaviour
{
    public int sortingOffset = 0;
    private SpriteRenderer sr;
    private TilemapRenderer mr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        sr.sortingOrder = -(int)(transform.position.y * 100) + sortingOffset;
    }
}
