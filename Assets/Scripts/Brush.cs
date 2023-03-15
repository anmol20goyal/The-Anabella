using UnityEngine;
using UnityEngine.UI;

public class Brush : MonoBehaviour
{
	public Image canvas;
	public Color lineColor = Color.black;
	public float lineWidth = 3f;

	private Vector2 lastPos;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("Mouse clicked");
			lastPos = canvas.transform.InverseTransformPoint(Input.mousePosition);
			Debug.Log("Last position: " + lastPos);
		}
		else if (Input.GetMouseButton(0))
		{
			Vector2 currentPos = canvas.transform.InverseTransformPoint(Input.mousePosition);
			Debug.Log("Current position: " + currentPos);

			DrawLine(lastPos, currentPos);
			lastPos = currentPos;
		}
	}

	void DrawLine(Vector2 start, Vector2 end)
	{
		GameObject line = new GameObject("Line");
		line.transform.SetParent(canvas.transform);

		Image lineImage = line.AddComponent<Image>();
		lineImage.color = lineColor;

		RectTransform lineTransform = line.GetComponent<RectTransform>();
		lineTransform.sizeDelta = new Vector2(Vector2.Distance(start, end), lineWidth);
		lineTransform.pivot = new Vector2(0, 0.5f);
		lineTransform.position = (start + end) / 2f;

		float angle = Mathf.Atan2(end.y - start.y, end.x - start.x) * Mathf.Rad2Deg;
		lineTransform.rotation = Quaternion.Euler(0, 0, angle);
	}
}