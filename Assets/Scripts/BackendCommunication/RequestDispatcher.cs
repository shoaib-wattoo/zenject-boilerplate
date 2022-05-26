using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using System.Net;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;


namespace Backend
{
	public class RequestDispatcher : MonoBehaviour 
	{
		public static DateTime _lastResponseTime = DateTime.Now;

		[SerializeField]
		// It is just for debug purposes that the variable is a serializeField.
		private RequestMessage _request;

		private SparvisResponse _response;
		private Action<SparvisResponse> _responseListener;


		public void Request(RequestMessage request, Action<SparvisResponse> callback)
		{
			PrepareUrlWithParameters (request);

			WebRequest wr = null;
			new Thread (() => {
				
				_request = request;
				_responseListener = callback;

				try {

					wr = WebRequest.Create(request._requestPath);

					request._headers.ToList ().ForEach (pair => {	wr.Headers[pair.Key] = pair.Value;	});

					wr.ContentType = "application/json";
					wr.Method = request._requestType.ToString();

					if((request._requestType & (RequestMessage.RequestType.POST | RequestMessage.RequestType.PUT)) > 0)
					{
						if(!string.IsNullOrEmpty(request._body))
						{
							byte[] byteArray = System.Text.Encoding.UTF8.GetBytes (request._body);

							Stream dataStream = wr.GetRequestStream();
							dataStream.Write (byteArray, 0, byteArray.Length);
							dataStream.Close();
						}
					}

					ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;

					Debug.Log("Sending req = " + request.ToString());

					Stream stream = wr.GetResponse ().GetResponseStream ();
					string strResponse = new StreamReader (stream).ReadToEnd ();

					_response = SparvisSerializer.Deserialize<SparvisResponse>(strResponse);
					_response.statusCode = (int) System.Net.HttpStatusCode.OK;

                    if (wr.Headers != null && wr.Headers.AllKeys != null)
					{
						wr.Headers.AllKeys.ToList().ForEach(aHeader => {
							_response._headers.Add(aHeader, wr.Headers[aHeader]);
						});

						if(wr.Headers.AllKeys.Contains(RequestMessage.KEY_PAYLOAD))
							_response._payload = wr.Headers[RequestMessage.KEY_PAYLOAD];
					}

				}
				catch (WebException we) {

					if(we.Response == null)
					{
						_response = new SparvisResponse () 
						{
							data = null,
							statusCode = (int) System.Net.HttpStatusCode.InternalServerError
						};	
					}
					else
					{
						HttpWebResponse res = (HttpWebResponse) we.Response;

						_response = new SparvisResponse () 
						{
							data = null,
							statusCode = (int) res.StatusCode,
						};
					}
				}
				catch(Exception e)
				{
					_response = new SparvisResponse () 
					{
						data = null,
						statusCode = (int)System.Net.HttpStatusCode.InternalServerError
					};
				}

				_response._request = request;
			}).Start();
		}


		public bool MyRemoteCertificateValidationCallback(System.Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
			bool isOk = true;
			// If there are errors in the certificate chain, look at each error to determine the cause.
			if (sslPolicyErrors != SslPolicyErrors.None) {
				for(int i=0; i<chain.ChainStatus.Length; i++) {
					if(chain.ChainStatus[i].Status != X509ChainStatusFlags.RevocationStatusUnknown) {
						chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
						chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
						chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
						chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
						bool chainIsValid = chain.Build((X509Certificate2)certificate);
						if(!chainIsValid) {
							isOk = false;
						}
					}
				}
			}
			return isOk;
		}


		/*public class SSLTest : ICertificatePolicy 
		{
			public bool CheckValidationResult (ServicePoint sp, X509Certificate certificate, WebRequest request, int error)
			{
				if (error == 0)
					return true;
				return false;
			}
		}*/


		private void PrepareUrlWithParameters(RequestMessage request)
		{
			string finalUrl = request._requestPath;
			List<KeyValuePair<string, string>> parameters = request._requestParameters.ToList ();
			for (int i = 0; i < parameters.Count; i++)
			{
				finalUrl += (i == 0 ? "?" : "&") + parameters [i].Key + "=" + parameters [i].Value;
			}
			request._requestPath = finalUrl;
		}


		protected void Update()
		{
			if (_response != null)
			{
				if(_responseListener != null)
					_responseListener (_response);

                Debug.Log("Response = " + SparvisSerializer.Serialize(_response));

                Destroy(gameObject);
			}
		}
	}
}