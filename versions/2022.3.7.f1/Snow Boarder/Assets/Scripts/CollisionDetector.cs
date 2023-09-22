using UnityEngine;
public class CollisionDetector : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem CrashParticle;

    [SerializeField]
    private ParticleSystem DustParticle;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameManager.manager.GameOver)
        {
            if (other.tag == "PlayerHead")
            {
                CrashParticle.Play();
                GetComponent<AudioSource>().Play();
                GameManager.manager.LoadScene();
            }
            else if (other.tag == "PlayerBoard")
            {
                DustParticle.Play();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!GameManager.manager.GameOver)
        {
            if (other.tag == "PlayerBoard")
            {
                DustParticle.Stop();
            }
        }
    }
}
