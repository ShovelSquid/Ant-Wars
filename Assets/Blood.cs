using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public GameObject bloodPrefab;
    public List<Sprite> bloodSpritesBig;
    public List<Sprite> bloodSpritesSmall;
    public Color freshBloodColor = Color.red;
    public Color driedBloodColor = new Color(1f, 0f, 0f, 0f);
    public float colorTime = 1f;

    public void PlayBloodEffect(Vector3 position, bool big)
    {
        GameObject bloodInstance = Instantiate(bloodPrefab, position, Quaternion.identity);
        SpriteRenderer sr = bloodInstance.GetComponent<SpriteRenderer>();
        sr.sprite = big ? bloodSpritesBig[Random.Range(0, bloodSpritesBig.Count)] : bloodSpritesSmall[Random.Range(0, bloodSpritesSmall.Count)];
        sr.color = freshBloodColor;
        StartCoroutine(ChangeColorOverTime(sr, freshBloodColor, driedBloodColor, colorTime));
    }

    /// <summary>
    /// Smoothly transitions a SpriteRenderer's color from startColor to endColor over the specified duration.
    /// </summary>
    /// <param name="spriteRenderer">The SpriteRenderer to change</param>
    /// <param name="startColor">The starting color</param>
    /// <param name="endColor">The target color</param>
    /// <param name="duration">Time in seconds for the transition</param>
    public IEnumerator ChangeColorOverTime(SpriteRenderer spriteRenderer, Color startColor, Color endColor, float duration)
    {
        float elapsedTime = 0f;
        
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            spriteRenderer.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }
        
        // Ensure we end at exactly the target color
        spriteRenderer.color = endColor;
    }
}
