﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityPureMVC.Interfaces;

public class Count2Mediator : UnityPureMVC.Patterns.Mediator {

	public new const string NAME = "Count2Mediator";

	private MyBox box{
		get{ return ((GameObject)ViewComponent).GetComponent<MyBox>(); }
	}

	private Count2Proxy proxy;
	//IMediatorPlug needs
	public Count2Mediator(string mediatorName, object viewComponent ):base(mediatorName, viewComponent ) {}

	public override string[] ListNotificationInterests()
	{
		IList<string> list = new List<string>();
		list.Add(Count2Proxy.UPDATED);
		return list.ToArray();
	}

	public override void HandleNotification(INotification notification)
	{                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
		switch( notification.Name ){
		case  Count2Proxy.UPDATED:
			box.UpdateLabel( proxy.GetCount().ToString() );
			break;
		}
	}

	public override void OnRegister()
	{
		Debug.Log("OnRegister:" + MediatorName );
		proxy = Facade.RetrieveProxy( Count2Proxy.NAME ) as Count2Proxy;
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
