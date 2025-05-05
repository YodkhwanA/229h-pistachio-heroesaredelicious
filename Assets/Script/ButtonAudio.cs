using UnityEngine;
using UnityEngine.EventSystems;



public class ButtonAudio : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public AudioClip hoverSound;    
    public AudioClip clickSound;
    public AudioClip bgSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgSound;
        audioSource.loop = true;
    }

    // �������������价�����
    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(hoverSound);  
    }

    // ����͡�����
    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.PlayOneShot(clickSound);  
    }
}

