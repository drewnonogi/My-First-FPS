using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TargetPushable : MonoBehaviour
{
    public event EventHandler<OnTargedPushableHealthChangedEventArgs> OnTargetPushableHealthChanged;
    public class OnTargedPushableHealthChangedEventArgs : EventArgs
    {
        public float healthNormalized;
    }

    [SerializeField] private Transform explosionPrefab;

    [SerializeField] private int health = 10;
    [SerializeField] private int healthMax = 10;


    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float pushForce = 1000f;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.GetContact(0);
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);

        rigidBody.AddForce(contact.normal*pushForce);
        health--;
        OnTargetPushableHealthChanged?.Invoke(this, new OnTargedPushableHealthChangedEventArgs
        {
            healthNormalized = (float)health / healthMax
        });

        if (health == 0)
        {
            Instantiate(explosionPrefab, contact.point, rotation);

            Destroy(gameObject);
        }


    }
}

