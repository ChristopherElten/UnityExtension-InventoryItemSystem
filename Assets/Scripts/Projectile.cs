using UnityEngine;
using System.Collections;

public class Projectile : ScriptableObject {

	[SerializeField] string name;
	[SerializeField] Sprite sprite;
	[SerializeField] float range;
	[SerializeField] float weight;
	[SerializeField] ParticleSystem launchParticles;
	[SerializeField] TrailRenderer trail;
	[SerializeField] ParticleSystem impactParticles;

	public void init (string name, Sprite sprite, float range, float weight, ParticleSystem launchParticles, TrailRenderer trail, ParticleSystem impactParticles){
		this.name = name;
		this.sprite = sprite;
		this.range = range;
		this.weight = weight;
		this.launchParticles = launchParticles;
		this.trail = trail;
		this.impactParticles = impactParticles;
	}

}
