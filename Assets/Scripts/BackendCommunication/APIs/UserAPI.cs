using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backend
{
    public class UserAPI
    {

        public static void Login(string email, string password, Action<ResponseMessage<User>> userListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "users/loginUser";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(new Dictionary<string, string>() {
                    {"emailAddress", email},
                    {"password", password}
                })
            };
            //getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<User>(getUserRequest, userListener);
        }

        public static void Register(string email, string password, string phone, string firstname, string lastName, Action<ResponseMessage<User>> userListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "users/createUser";

            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(new Dictionary<string, string>() {
                    {"emailAddress", email},
                    {"password", password},
                    {"cellPhone", phone},
                    {"firstName", firstname},
                    {"lastName", lastName},
                    {"userName", firstname.ToLower() + lastName.ToLower()}
                })
            };
            //getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<User>(getUserRequest, userListener);
        }

        public static void VerifyOTP(string otp, Action<ResponseMessage<User>> userListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "users/verifyEmail";

            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(new Dictionary<string, string>() {
                    {"emailProofToken", otp}
                })
            };
            //getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<User>(getUserRequest, userListener);
        }

        public static void ForgetUsername(string email, Action<ResponseMessage<string>> userListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "users/forgetUserName";

            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(new Dictionary<string, string>() {
                    {"emailAddress", email}
                })
            };
            //getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<string>(getUserRequest, userListener);
        }

        public static void ForgetPassword(string email, string cellPhone, string clubNumber, Action<ResponseMessage<string>> userListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "users/forgetPassword";

            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(new Dictionary<string, string>() {
                    {"emailAddress", email}, 
                    {"cellPhone", cellPhone},
                    {"clubNumber", clubNumber}
                })
            };
            //getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<string>(getUserRequest, userListener);
        }

        public static void LinkAccount(string firstName, string lastName, string property, string playersClubAccNo, string accountPin, Action<ResponseMessage<string>> userListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "users/linkAccount";

            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(new LinkAccountData(
                    firstName,
                    lastName,
                    property,
                    playersClubAccNo,
                    accountPin
                ))
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<string>(getUserRequest, userListener);
        }

        public static void SetFCMToken(Action<ResponseMessage<User>> userListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "users/setFCMToken";

            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(new Dictionary<string, string>() {
                    {"id", Services.UserService._user._id}
                })
            };

            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<User>(getUserRequest, userListener);
        }

        public static void UpdateProfile(Action<ResponseMessage<User>> userListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "users/updateProfile";

            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(Services.UserService._user.ToDic())
            };

            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<User>(getUserRequest, userListener);
        }

        public static void GetUserById(string id, Action<ResponseMessage<User>> userListener)
        {
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = SparvisClient.instance._hostUrl + "users/" + id,
                _headers = RequestMessage._defaultHeaders
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<User>(getUserRequest, userListener);
        }

        public static void GetProfileByUserId(string id, Action<ResponseMessage<UserProfile>> userListener)
        {
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = SparvisClient.instance._hostUrl + "users/getUserProfile/" + id,
                _headers = RequestMessage._defaultHeaders
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest(getUserRequest, userListener);
        }

        // Friends APIs

        public static void SendFriendRequest(string toID, Action<ResponseMessage<SendRequestData>> userListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "social/sendRequest";

            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(new Dictionary<string, string>() {
                    {"reqTo", toID},
                    {"reqFrom", Services.UserService._user._id},
                    {"reqType", "friendRequest"}
                })
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest(getUserRequest, userListener);
        }

        public static void AcceptOrRejectFriendRequest(string userID, string requestID, string recordID, bool accept, Action<ResponseMessage<object>> userListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "social/acOrRejReq";

            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,
                _body = SparvisSerializer.Serialize(new AcceptRequest(requestID, recordID, userID, accept))
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest(getUserRequest, userListener);
        }

        public static void FetchFriendRequests(string id, Action<ResponseMessage<FriendRequest>> userListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "social/getRequests/" + id;
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(new Dictionary<string, string>() {
                    {"userId", id}
                })
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<FriendRequest>(getUserRequest, userListener);
        }

        public static void FetchFriends(string id, Action<ResponseMessage<Friends>> userListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "social/getFriends/" + id;
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(new Dictionary<string, string>() {
                    {"userId", id}
                })
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<Friends>(getUserRequest, userListener);
        }

        public static void SearchFriends(string email, string cellPhone, Action<ResponseMessage<Friend>> userListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "users/lookUpUser";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(new Dictionary<string, string>() {
                    {"emailAddress", email},
                    {"cellPhone", (cellPhone != "") ? cellPhone : ""}
                })
            };

            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<Friend>(getUserRequest, userListener);
        }

        #region Messages

        public static void CreatePredefinedMessage(CreatePredefinedMsgData createPredefinedMsgData, Action<ResponseMessage<string>> tournamentListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "messages/createPredefinedMessage";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(createPredefinedMsgData.GetRequestParams())
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<string>(getUserRequest, tournamentListener);
        }

        public static void GetPredefinedMessage(Action<ResponseMessage<List<PredefineMsg>>> gameListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "messages/getPredefinedMessages";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,
            };

            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<List<PredefineMsg>>(getUserRequest, gameListener);
        }

        public static void SendMessage(string subject, string senderId, string receiverId, string message, Action<ResponseMessage<object>> tournamentListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "messages/sendMessage";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(new Dictionary<string, string>() {
                    {"subject", subject},
                    {"senderId", senderId},
                    {"receiverId", receiverId},
                    {"message", message}
                })
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest(getUserRequest, tournamentListener);
        }

        public static void GetMessagesByUserID(string userID, Action<ResponseMessage<List<MessageData>>> tournamentListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "messages/getAllConversationByUserId/" + userID;
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(), 
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<List<MessageData>>(getUserRequest, tournamentListener);
        }

        #endregion


        #region MarketPlace

        public static void UpdateMarketPalce(string itemType, string itemAmount, Action<ResponseMessage<MarketPlaceData>> tournamentListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "market/createPurchase";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(new Dictionary<string, string>() {
                    {"type", itemType},
                    {"amount", itemAmount},
                    {"userId", Services.UserService._user._id}
                })
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest(getUserRequest, tournamentListener);
        }

        #endregion
    }

    public class LinkAccountData {
        public string firstName;
        public string lastName;
        public string property;
        public string playersClubAccNo;
        public string accountPin;

        public LinkAccountData(string firstName, string lastName, string property, string playersClubAccNo, string accountPin)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.property = property;
            this.playersClubAccNo = playersClubAccNo;
            this.accountPin = accountPin;
        }
    }
}

