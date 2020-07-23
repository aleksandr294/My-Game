using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBarEvent
{
    private readonly List<Action<float>> _callbacks = new List<Action<float>>();

    public void Subscribe(Action<float> callback)
    {
        _callbacks.Add(callback);
    }

    public void Publish(float health)
    {
        foreach (var callback in _callbacks)
        {
            callback(health);
        }
    }
}

public class HeroDamageEvent
{
    private readonly List<Action<float>> _callbacks = new List<Action<float>>();

    public void Subscribe(Action<float> callback)
    {
        _callbacks.Add(callback);
    }

    public void Publish(float damage)
    {
        foreach (var callback in _callbacks)
        {
            callback(damage);
        }
    }
}

public class ResetSkillEvent
{
    private readonly List<Action<int>> _callbacks = new List<Action<int>>();

    public void Subscribe(Action<int> callback)
    {
        _callbacks.Add(callback);
    }

    public void Publish(int index)
    {
        foreach (var callback in _callbacks)
        {
            callback(index);
        }
    }
}

public class ReduceSkillEvent
{
    private readonly List<Action<int, float>> _callbacks = new List<Action<int, float>>();

    public void Subscribe(Action<int, float> callback)
    {
        _callbacks.Add(callback);
    }

    public void Publish(int index, float restore)
    {
        foreach (var callback in _callbacks)
        {
            callback(index, restore);
        }
    }
}

public class HealthBarEvent
{
    private readonly List<Action<float>> _callbacks = new List<Action<float>>();

    public void Subscribe(Action<float> callback)
    {
        _callbacks.Add(callback);
    }

    public void Publish(float health)
    {
        foreach (var callback in _callbacks)
        {
            callback(health);
        }
    }
}

public class KickEvent
{
    private readonly List<Action<Collider2D, int>> _callbacks = new List<Action<Collider2D, int>>();

    public void Subscribe(Action<Collider2D, int> callback)
    {
        _callbacks.Add(callback);
    }

    public void Publish(Collider2D col, int damage)
    {
        foreach (var callback in _callbacks)
        {
            callback(col, damage);
        }
    }
}

public class TransitionCharacterEvent
{
    private readonly List<Action<int, bool>> _callbacks = new List<Action<int, bool>>();

    public void Subscribe(Action<int, bool> callback)
    {
        _callbacks.Add(callback);
    }

    public void Publish(int index, bool is_day)
    {
        foreach (var callback in _callbacks)
        {
            callback(index, is_day);
        }
    }
}

public class EventAggregator
{
    public static EnemyHealthBarEvent enemy_health_bar_event = new EnemyHealthBarEvent();
    public static HeroDamageEvent hero_damage_event = new HeroDamageEvent();
    public static ResetSkillEvent reset_skill_event = new ResetSkillEvent();
    public static ReduceSkillEvent reduce_skill_event = new ReduceSkillEvent();
    public static HealthBarEvent health_bar_event = new HealthBarEvent();
    public static KickEvent kick_event = new KickEvent();
    public static TransitionCharacterEvent transition_character_event = new TransitionCharacterEvent();
}
