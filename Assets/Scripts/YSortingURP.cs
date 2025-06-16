using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class YSortingURP : MonoBehaviour
{
    public int sortingOffset = 0;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        sr.sortingOrder = -(int)(transform.position.y * 100) + sortingOffset;
    }
}
