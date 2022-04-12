using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
	public abstract void Enter(Guard guard);
	public abstract void Execute(Guard guard);
	public abstract void Exit(Guard guard);
}

public class StatePatrol : State {
	public override void Enter(Guard guard)
    {
		Debug.Log("Start patrolling!!!");
	}

	public override void Execute(Guard guard)
	{
		Debug.Log("Patrolling!!!");
	}

	public override void Exit(Guard guard)
	{
		//guard.ChangeState(new StateFollow(guard));
	}
}

public class StateFollow : State
{
	public override void Enter(Guard guard)
	{

	}

	public override void Execute(Guard guard)
	{

	}

	public override void Exit(Guard guard)
	{

	}
}

public class StateArrest : State
{
	public override void Enter(Guard guard)
	{

	}

	public override void Execute(Guard guard)
	{

	}

	public override void Exit(Guard guard)
	{

	}
}