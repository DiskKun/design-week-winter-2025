using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Conditions {

	public class AtTargetCT : ConditionTask {

		NavMeshAgent navAgent;
		bool firstTime = true;

        public BBParameter<Vector3> target;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
            navAgent = agent.GetComponent<NavMeshAgent>();

            return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			if (firstTime)
			{
				firstTime = false;
				return true;
			} else
			{
                return Vector3.Distance(target.value, navAgent.transform.position) < 1;
            }
        }
	}
}