using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backend
{
	public class SparvisClient : SingletonMonobehaviour<SparvisClient>
	{
		public string _hostUrl = "http://3.138.70.50:1337/";

		[SerializeField]
		private List<RequestMessage> _requests;

		private bool _isInitialized = false;


		public void DispatchRequest<T>(RequestMessage request, Action<ResponseMessage<T>> listener)
		{
			_requests.Add (request);

			GameObject requestMakerObject = new GameObject ("web request");
			requestMakerObject.transform.SetParent (transform);
			RequestDispatcher requestMaker = requestMakerObject.AddComponent<RequestDispatcher> ();

			requestMaker.Request (request, abjadResponse => {

				listener(GenericResponseFromResponse<T>(abjadResponse));
				RequestMessage req = _requests.Find(areq => areq == abjadResponse._request);
				if(req != null)
					_requests.Remove(req);
			});
		}


		private static ResponseMessage<T> GenericResponseFromResponse<T>(SparvisResponse response)
		{
			ResponseMessage<T> resp = new ResponseMessage<T> ();

			if (response.data != null)
			{
				if (typeof(T) == typeof(string))
					resp._entity = (T)response.data;
				else
					resp._entity = SparvisSerializer.Deserialize<T> (response.data.ToString ());
			}

			resp._status = response.status;
			resp._message = response.message;
			resp._payload = response._payload;
			resp._request = response._request;
			resp._statusCode = response.statusCode;
			return resp;
		}


	}
}