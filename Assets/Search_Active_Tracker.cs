﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


namespace CRI.ConnectedGymnasium
{
	public class Search_Active_Tracker : MonoBehaviour
	{
		void OnEnable()
		{
			Debug.Log("Testing connection for devices");
			SteamVR_Events.DeviceConnected.Listen(OnDeviceConnected);
		}

		// A SteamVR device got connected/disconnected
		private void OnDeviceConnected(int index, bool connected)
		{

			if (connected)
			{
				if (OpenVR.System != null)
				{
					//lets figure what type of device got connected
					ETrackedDeviceClass deviceClass = OpenVR.System.GetTrackedDeviceClass((uint)index);
					if (deviceClass == ETrackedDeviceClass.Controller)
					{
						Debug.Log("Controller got connected at index:" + index);
					}
					else if (deviceClass == ETrackedDeviceClass.GenericTracker)
					{
						Debug.Log("Tracker got connected at index:" + index);
						if (index > 0)
							PlayerManager.Instance.trackers[index - 1].GetComponent<ActiveTracker>().toActivate = true;
					}
				}
			}
		}
	}
}