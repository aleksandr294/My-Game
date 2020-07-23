using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : NPC
{
    [SerializeField] protected int damage;

    [SerializeField] protected float stopping_distance;
    [SerializeField] protected float time_btw_attack;
    [SerializeField] protected float start_time_btw_attack;
    [SerializeField] protected float attack_range;

    [SerializeField] protected bool angry = false;
    [SerializeField] protected bool run = true;
    [SerializeField] protected bool attack = false;
    [SerializeField] protected bool dead = false;

    [SerializeField] protected LayerMask what_is_opponent;

    protected Transform player;
    [SerializeField] protected Transform attack_pose;

    protected abstract void Attack();

    protected abstract void Angry();
}
