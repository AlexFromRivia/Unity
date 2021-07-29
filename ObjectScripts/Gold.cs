using UnityEngine;
using UnityEngine.UI;

class Gold : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyParticles;
    [SerializeField] private AudioClip _pickUpSound;
    [SerializeField] private AudioSource AudioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<CharacterInventory>()._goldAmount++;
            gameObject.GetComponent<Image>().enabled = false;
            //При уничтожении спавнить звук и "частицы золота"
            _destroyParticles.Play();
            AudioSource.PlayOneShot(_pickUpSound);
            Destroy(gameObject, 0.5f);
        }
    }
}