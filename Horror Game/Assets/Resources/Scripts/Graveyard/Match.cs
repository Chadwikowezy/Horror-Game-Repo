using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : MonoBehaviour
{
    public Transform matchTargetPosition;

    public float matchLiftime;
    public float matchSpeed;

    private float currentMatchLife;

    private void Update()
    {
        currentMatchLife += Time.deltaTime;

        if (currentMatchLife > matchLiftime)
            Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        if (matchTargetPosition != null)
            if ((transform.position - matchTargetPosition.position).magnitude > 0.01f)
                transform.position = Vector3.Lerp(transform.position, matchTargetPosition.position, matchSpeed);
    }

    public void strikeMatch(Transform _matchTargetPosition)
    {
        matchTargetPosition = _matchTargetPosition;
    }
}
