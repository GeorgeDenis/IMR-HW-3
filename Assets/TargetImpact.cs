using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TargetImpact : MonoBehaviour
{
    public GameObject particleEffectPrefab;
    public TextMeshPro scoreText;
    private float currentScore = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {

            float distance = Vector3.Distance(transform.position, other.transform.position);
            currentScore = ComputeScore(distance);
            UpdateScoreText();
            currentScore = 0;
            TriggerParticleEffect();
        }
    }

    float ComputeScore(float distance)
    {
        return 1000 / (distance + 1);
    }

    void TriggerParticleEffect()
    {

        if (particleEffectPrefab)
        {
            Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
        }
    }
    void UpdateScoreText()
    {
        if (scoreText)
        {
            scoreText.text = "Score: " + currentScore.ToString("0");
        }
    }
}
