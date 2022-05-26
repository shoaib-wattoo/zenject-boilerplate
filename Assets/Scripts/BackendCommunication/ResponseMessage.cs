using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backend
{
	public class ResponseMessage<T>
	{
		public T _entity;
		public bool _status;
		public int _statusCode;
		public string _message;
		public long _timeStamp;
		public string _payload;
		public RequestMessage _request;


		public override string ToString ()
		{
			return string.Format ("[ResponseMessage] _statusCode = {0}, _entity = {1}, _message = {2}", _statusCode, _entity, _message);
		}

	
		public static ResponseMessage<T> GenericResponseFromResponse<T>(SparvisResponse response)
		{
			Debug.Log ("AbjadResponse response = " + response.data);
	
			ResponseMessage<T> resp = new ResponseMessage<T> ();
			resp._entity = SparvisSerializer.Deserialize<T> (response.data.ToString());
			resp._message = response.message;
			resp._payload = response._payload;
			resp._request = response._request;
			resp._statusCode = response.statusCode;
            resp._status = response.status;
            return resp;
		}
	}
		
}
