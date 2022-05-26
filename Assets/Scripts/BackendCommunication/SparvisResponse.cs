using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backend
{
	public class SparvisResponse  
	{
		public bool status;
		public int statusCode;
		public string message;
		public object data;
		public long _timeStamp;
		public string _payload;
		public RequestMessage _request;
		public Dictionary<string, object> _headers = new Dictionary<string, object>();
		public override string ToString ()
		{
			return string.Format ("[ResponseMessage] _statusCode = {0}, _entity = {1}, _message = {2}", statusCode, data, message);
		}
	}
}