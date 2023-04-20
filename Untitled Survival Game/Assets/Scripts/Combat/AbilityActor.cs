using FishNet.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityActor : NetworkBehaviour
{
	[SerializeField]
	private Stats _stats;

	[SerializeField]
	private ToolType _toolType;

	[SerializeField]
	private Animator _animator;

	[SerializeField]
	private AnimatorOverrideController _animatorOverride;

	[SerializeField]
	private AudioSource _audioSource;

	[SerializeField]
	private ParticleHandler _particleHandler;


	[SerializeField]
	private TransformAnimator _transformAnimator;



	private Ability _abilityInUse;

	private bool _isAlive;

	public bool IsAlive { get { return _isAlive; } set {  _isAlive = value; } }


	public override void OnStartNetwork()
	{
		base.OnStartNetwork();

		_isAlive = true;
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
	}

	public void Initialize(Animator animator)
	{
		_animator = animator;

		if (_animatorOverride != null)
		{
			_animator.runtimeAnimatorController = _animatorOverride;
		}
	}


	#region Stats Accessors

	public bool HasStat(StatType statType)
	{
		return _stats.HasStat(statType);
	}


	public float GetStatValue(StatType statType)
	{
		return _stats.GetStatValue(statType);
	}


	public float GetStatMax(StatType statType)
	{
		return _stats.GetStatMax(statType);
	}


	[Server]
	public void SetStatValue(StatType statType, float value)
	{
		_stats.SetStat(statType, value);
	}


	[Server]
	public void AddToStat(StatType statType, float value)
	{
		_stats.AddToStat(statType, value);
	}


	public ToolType GetToolType()
	{
		return _toolType;
	}

	#endregion


	#region VisualAndAudioEffects

	public void SetAnimOverride(string animToOverride, AnimationClip animation)
	{
		if (_animatorOverride != null)
		{
			Debug.Log("Override: " + animToOverride + " On: " + gameObject.name);
			_animatorOverride[animToOverride] = animation;
		}
	}


	public void SetAnimTrigger(string animTrigger)
	{
		if (_animator != null)
		{
			Debug.Log("Set Trigger: " + animTrigger + " On: " + transform.parent.gameObject.name);
			_animator.SetTrigger(animTrigger);
		}
	}


	public void PlaySound(AudioClip sound)
	{

		if (IsServerOnly)
		{
			// No reason to play audio with no client and its so annoying every sound being doubled

			Debug.Log("IsServerOnly was true?");
			return;
		}


		if (sound != null && _audioSource != null)
		{
			//Debug.Log("Playing Sound: " + sound.name);

			_audioSource.PlayOneShot(sound);
		}
		else
		{
			Debug.Log("Attempted to Play Sound On: " + gameObject.name);
		}
		
	}


	public void PlayParticles(string name)
	{
		if (_particleHandler != null)
		{
			_particleHandler.PlayParticles(name);
		}
	}


	public void PlayParticles(ParticleSystem particleSystem)
	{
		if (particleSystem != null)
		{
			particleSystem.Play();
		}
	}


	public void PlayTransformAnimation(string transformAnimation)
	{
		if (_transformAnimator != null)
		{
			_transformAnimator.PlayAnimation(transformAnimation);
		}
	}


	public void KnockBack(Vector3 direction, float strength)
	{
		// Eventually want to check for immunity / resistance (would that be in stats?)

		Agent agent = GetComponent<Agent>();

		if (agent != null)
		{
			agent.KnockBack(direction, strength);
		}
	}

	#endregion


	private void AbilityAnimEvent()
	{
		//Debug.Log("AbilityAnimEvent asServer: " + IsServer);
	}


	private void Update()
	{
		
	}
}