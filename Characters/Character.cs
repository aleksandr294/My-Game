using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected float speed;

    protected bool facing_right = true;
    protected Animator animator;

    [SerializeField] public float health;

    protected int State
    {
        get { return (int)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    public abstract void Run();

    public void Flip()
    {
        facing_right = !facing_right;
        transform.Rotate(0, 180, 0);
        //Vector3 theScale = transform.localScale;
        //theScale.x *= -1;
        //transform.localScale = theScale;
    }

    public void PlaySoundEffect(AudioSource audio_source, float next_sound, float sound_rite, AudioClip audioClip)
    {
        next_sound = Time.time + sound_rite;
        audio_source.pitch = Random.Range(0.9f, 1.1f);
        audio_source.Play();
        //audio_source.PlayOneShot(audioClip);

    }


}
