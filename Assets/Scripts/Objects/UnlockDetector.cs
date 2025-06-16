using UnityEngine;

public class UnlockDetector : MonoBehaviour
{
    [SerializeField] RectTransform collisionUnlock;
    [SerializeField] RectTransform CollsionObject;
    public bool Unlock;
    void Update()
    {
        if (RectOverlaps(collisionUnlock, CollsionObject))
        {
            Unlock = true;
            Debug.Log("entraron en colision");
        }
        else
        {
            Unlock = false;
        }
    }
    bool RectOverlaps(RectTransform rect1, RectTransform rect2)
    {
        Rect a = GetWorldRect(rect1);
        Rect b = GetWorldRect(rect2);
        return a.Overlaps(b);
    }
    Rect GetWorldRect(RectTransform rt)
    {
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners);
        Vector2 size = corners[2] - corners[0];
        return new Rect(corners[0], size);
    }
}
