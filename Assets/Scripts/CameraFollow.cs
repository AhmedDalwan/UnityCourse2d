using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ÇáãßÇä ÇáĞí ÓÊÊÊÈÚå ÇáßÇãíÑÇ (ÓäÖÚ ãÇÑíæ åäÇ)
    public float smoothSpeed = 0.125f; // ÓÑÚÉ äÚæãÉ ÍÑßÉ ÇáßÇãíÑÇ
    public Vector3 offset; // ÇáãÓÇİÉ ÇáËÇÈÊÉ Èíä ÇáßÇãíÑÇ æãÇÑíæ

    void LateUpdate()
    {
        if (target == null) return;

        // ÊÍÏíÏ ÇáãæŞÚ ÇáãÓÊåÏİ ááßÇãíÑÇ ÈäÇÁğ Úáì ãæŞÚ ãÇÑíæ ãÚ ÅÖÇİÉ ÇáãÓÇİÉ (Offset)
        Vector3 desiredPosition = target.position + offset;

        // ÊÍÑíß ÇáßÇãíÑÇ ÈÓáÇÓÉ äÍæ ÇáãæŞÚ ÇáãÓÊåÏİ ÈÇÓÊÎÏÇã Lerp
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}