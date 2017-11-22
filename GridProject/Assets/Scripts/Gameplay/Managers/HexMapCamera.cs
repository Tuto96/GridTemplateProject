using System.Collections;
using UnityEngine;

public class HexMapCamera : Singleton<HexMapCamera>
{

    Transform swivel,
    stick;
    float rotationAngle;
    float zoom = 0.0f;

    public float stickMinZoom,
    stickMaxZoom;
    public float swivelMinZoom,
    swivelMaxZoom;
    public float moveSpeedMinZoom,
    moveSpeedMaxZoom;
    public float rotationSpeed,
    focusTime;
    public HexGrid grid;

    public override void SingletonAwake ()
    {
        swivel = transform.GetChild (0);
        stick = swivel.GetChild (0);
    }

    void Update ()
    {
        float zoomDelta = Input.GetAxis ("Mouse ScrollWheel");
        if (zoomDelta != 0f)
        {
            AdjustZoom (zoomDelta);
        }

        float rotationDelta = Input.GetAxis ("Rotation");
        if (rotationDelta != 0f)
        {
            AdjustRotation (rotationDelta);
        }

        float xDelta = Input.GetAxis ("Horizontal");
        float zDelta = Input.GetAxis ("Vertical");
        if (xDelta != 0f || zDelta != 0f)
        {
            AdjustPosition (xDelta, zDelta);
        }
    }
    public float GetZoom ()
    {
        return zoom;
    }

    public float GetRotation ()
    {
        return rotationAngle;
    }

    void AdjustRotation (float delta)
    {
        rotationAngle += delta * rotationSpeed * Time.deltaTime;
        if (rotationAngle < 0f)
        {
            rotationAngle += 360f;
        }
        else if (rotationAngle >= 360f)
        {
            rotationAngle -= 360f;
        }
        transform.localRotation = Quaternion.Euler (0f, rotationAngle, 0f);
    }

    void AdjustPosition (float xDelta, float zDelta)
    {
        Vector3 direction = transform.localRotation * new Vector3 (xDelta, 0f, zDelta).normalized;
        float damping = Mathf.Max (Mathf.Abs (xDelta), Mathf.Abs (zDelta));
        float distance = Mathf.Lerp (moveSpeedMinZoom, moveSpeedMaxZoom, zoom) * damping * Time.deltaTime;

        Vector3 position = transform.localPosition;
        position += direction * distance;
        transform.localPosition = position;

        transform.localPosition = ClampPosition (position);
    }

    Vector3 ClampPosition (Vector3 position)
    {
        float xMax = (grid.cellCountX - 0.5f) * (2f * HexMetrics.innerRadius);
        position.x = Mathf.Clamp (position.x, 0f, xMax);

        float zMax = (grid.cellCountZ - 1) * (1.5f * HexMetrics.outerRadius);
        position.z = Mathf.Clamp (position.z, 0f, zMax);

        return position;
    }

    void AdjustZoom (float delta)
    {
        zoom = Mathf.Clamp01 (zoom + delta);

        float distance = Mathf.Lerp (stickMinZoom, stickMaxZoom, zoom);
        stick.localPosition = new Vector3 (0f, distance, 0f);

        float angle = Mathf.Lerp (swivelMinZoom, swivelMaxZoom, zoom);
        swivel.localRotation = Quaternion.Euler (angle, 0f, 0f);
    }

    public static bool Locked
    {
        set
        {
            instance.enabled = !value;
        }
    }

    public static void ValidatePosition ()
    {
        Require ();
        instance.AdjustPosition (0f, 0f);
    }

    public void Focus (HexCell cell)
    {
        StopAllCoroutines ();
        StartCoroutine (FocusCell (cell.transform.localPosition));
    }

    public void Focus (HexUnit unit)
    {
        StopAllCoroutines ();
        StartCoroutine (FocusCell (unit.transform.position));
    }

    IEnumerator FocusCell (Vector3 pos)
    {
        WaitForSeconds delay = new WaitForSeconds (1 / 60f);
        float zoomStep = (1.0f - zoom) / (focusTime * 60f);
        float xDelta = (pos.x - transform.localPosition.x) / (focusTime * 60f);
        float zDelta = (pos.z - transform.localPosition.z) / (focusTime * 60f);
        for (int i = 0; i < focusTime * 60; i++)
        {
            yield return delay;
            AdjustPosition (xDelta, zDelta);
            AdjustZoom (zoomStep);
        }
    }

}