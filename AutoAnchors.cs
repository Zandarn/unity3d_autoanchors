using UnityEngine;

[RequireComponent(typeof(RectTransform))]

public class AutoAnchors : MonoBehaviour
{
    private RectTransform rectTransform = null;
    private Bounds parentBounds;
    private Vector2 parentSize = Vector2.zero;
    private Vector2 positionMin = Vector2.zero;
    private Vector2 positionMax = Vector2.zero;

    public void SetAnchors()
    {
        this.rectTransform = gameObject.GetComponent<RectTransform>();

        this.parentBounds = RectTransformUtility.CalculateRelativeRectTransformBounds(transform.parent);
        this.parentSize = new Vector2(this.parentBounds.size.x, this.parentBounds.size.y);

        //anchor ratio => pixel position
        this.positionMin = new Vector2(this.parentSize.x * this.rectTransform.anchorMin.x, this.parentSize.y * this.rectTransform.anchorMin.y);
        this.positionMax = new Vector2(this.parentSize.x * this.rectTransform.anchorMax.x, this.parentSize.y * this.rectTransform.anchorMax.y);

        //offsetMin - lower left corner
        //offsetMax - upper right corner
        this.positionMin = this.positionMin + this.rectTransform.offsetMin;
        this.positionMax = this.positionMax + this.rectTransform.offsetMax;

        //pixel position => anchor ratio
        this.positionMin = new Vector2(this.positionMin.x / this.parentBounds.size.x, this.positionMin.y / this.parentBounds.size.y);
        this.positionMax = new Vector2(this.positionMax.x / this.parentBounds.size.x, this.positionMax.y / this.parentBounds.size.y);

        this.rectTransform.anchorMin = this.positionMin;
        this.rectTransform.anchorMax = this.positionMax;

        this.rectTransform.offsetMin = Vector2.zero;
        this.rectTransform.offsetMax = Vector2.zero;
    }
}
