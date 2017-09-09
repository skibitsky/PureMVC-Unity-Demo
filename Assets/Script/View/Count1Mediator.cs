using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityPureMVC.Interfaces;

public class Count1Mediator : UnityPureMVC.Patterns.Mediator {

	public new const string NAME = "Count1Mediator";

	private MyBox box{
		get{ return ((GameObject)ViewComponent).GetComponent<MyBox>(); }
	}

	private CountProxy proxy;
	//IMediatorPlug needs
	public Count1Mediator(string mediatorName, object viewComponent ):base(mediatorName, viewComponent ) {}

	public override string[] ListNotificationInterests()
    {
        IList<string> list = new List<string>();
		list.Add(CountProxy.UPDATED);
        return list.ToArray();
    }

	public override void HandleNotification(INotification notification)
	{                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
		switch( notification.Name ){
		case  CountProxy.UPDATED:
			box.UpdateLabel( proxy.GetCount().ToString() );
			break;
		}
	}

	public override void OnRegister()
	{
		Debug.Log("OnRegister:" + MediatorName );
		proxy = Facade.RetrieveProxy( CountProxy.NAME ) as CountProxy;
		box.onClick = OnClick;
		box.UpdateLabel( proxy.GetCount().ToString() );
	}

	//Add count number
	void OnClick(){
		proxy.Add();
	}

	public override void OnRemove()
	{
		Debug.Log("Remove:" + MediatorName );
	}
}
