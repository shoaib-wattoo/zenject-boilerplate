using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backend
{
	public class ContentAPI 
	{
        #region GamesAPI
        public static void AddGame(AddNewGameRequestData addGameRequestData, Action<ResponseMessage<Game>> gameListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "games/addGame";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(addGameRequestData.GetRequestParams())
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<Game>(getUserRequest, gameListener);
        }


        public static void GetAllGames(Action<ResponseMessage<Game[]>> gameListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "games/getAllGames";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<Game[]>(getUserRequest, gameListener);
        }

        public static void GetAllGamesForDropDown(Action<ResponseMessage<List<GameDropdown>>> gameListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "games/getAllGamesForDropDown";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest(getUserRequest, gameListener);
        }

        public static void GetGameByID(string gameID,Action<ResponseMessage<Game>> gameListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "games/getGameById/" + gameID;
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<Game>(getUserRequest, gameListener);
        }

        #endregion GamesAPI

        #region Season

        public static void GetCurrentSeason(Action<ResponseMessage<SeasonAndLeague>> seasonListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "sal/getCurrentSeason/" + Services.UserService._user._id;
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest(getUserRequest, seasonListener);
        }

        #endregion

        #region Tournament
        public static void CreateTournament(CreateTournamentRequestData addTournamentRequestData, Action<ResponseMessage<Tournament>> tournamentListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "tournaments/createTournament";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(addTournamentRequestData.GetRequestParams())
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<Tournament>(getUserRequest, tournamentListener);
        }

        public static void CreateTournamentDummy(CreateTournamentRequestData addTournamentRequestData, Action<ResponseMessage<Tournament>> tournamentListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "dummy/createTournament";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(addTournamentRequestData.GetRequestParams())
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<Tournament>(getUserRequest, tournamentListener);
        }

        public static void GetAllTournaments(Action<ResponseMessage<Tournament[]>> tournamentListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "tournaments/getAllTournaments";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<Tournament[]>(getUserRequest, tournamentListener);
        }
        public static void GetTournamentByID(string tournamentID, Action<ResponseMessage<Tournament>> tournamentListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "tournaments/getTournamentById/" + tournamentID;
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders
            };

            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<Tournament>(getUserRequest, tournamentListener);
        }

        public static void GetAvailableTournaments(Action<ResponseMessage<List<Tournament> >> tournamentListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "tournaments/getAllTournamentsByLeagueId/" + Services.UserService._user.leagueId;
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<List<Tournament>>(getUserRequest, tournamentListener);
        }

        public static void GetAvailableTournamentsAndChallenges(Action<ResponseMessage<List<Tournament>>> tournamentListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "tournaments/getAllTournamentsByProvidedIds";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _requestParameters = new Dictionary<string, string>() {
                    {"obj", SparvisSerializer.Serialize(new TournamentAndChallengeRequest(Services.UserService._user._id, Services.UserService._user.leagueId))}
                }
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<List<Tournament>>(getUserRequest, tournamentListener);
        }

        public static void GetTournamentsByUserId(Action<ResponseMessage<List<Tournament>>> tournamentListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "tournaments/getTournamentsByUserId/"+  Services.UserService._user._id;
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<List<Tournament>>(getUserRequest, tournamentListener);
        }

        public static void JoinTournament(UserTournamentRequestData joinTournamentRequestData, Action<ResponseMessage<Tournament>> tournamentListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "tournaments/joinTournament";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(joinTournamentRequestData.GetRequestParams())
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<Tournament>(getUserRequest, tournamentListener);
        }

        public static void RemoveTournament(UserTournamentRequestData removeTournamentRequestData, Action<ResponseMessage<Tournament>> tournamentListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "tournaments/leftTournament";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(removeTournamentRequestData.GetRequestParams())
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<Tournament>(getUserRequest, tournamentListener);
        }

        public static void TournamentDetail(string tournamentId, Action<ResponseMessage<TournamentDetail>> listener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "tournaments/getTournamentLatestGamePlayedDetail/" + tournamentId;
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest(getUserRequest, listener);
        }

        public static void GetChallengeDetail(string tournamentId, Action<ResponseMessage<List<ChallengeDetail>>> listener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "challenges/getChallengeDetailById/" + tournamentId;
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest(getUserRequest, listener);
        }

        #endregion Tournament

        #region PlayerSeedsForTournament
        public static void JoinLiveGame(JoinLiveGameRequestData addGameRequestData, Action<ResponseMessage<List<GameSeeds>>> gameListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "seedScore/addSeedAndScore";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(addGameRequestData.GetRequestParams())
            };

            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<List<GameSeeds>>(getUserRequest, gameListener);
        }

        public static void JoinLiveGameDummy(List<JoinLiveGameRequestData> addGameRequestData, Action<ResponseMessage<List<GameSeeds>>> gameListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "dummy/setSeedAndScore";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                _body = SparvisSerializer.Serialize(addGameRequestData.ToArray())
            };

            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<List<GameSeeds>>(getUserRequest, gameListener);
        }

        public static void GetGameSeeds(string tournamentID, Action<ResponseMessage<List<GameSeeds>>> gameListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "seedScore/getSeedAndScore/" + tournamentID;
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,
            };

            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<List<GameSeeds>> (getUserRequest, gameListener);
        }
        #endregion

        #region Property APIS
        public static void GetAllRestaurants(Action<ResponseMessage<List<Restaurant>>> gameListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "restaurant/getAllRestaurants";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,
            };

            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<List<Restaurant>>(getUserRequest, gameListener);
        }

        public static void GetRestaurantById(string restuarantID, Action<ResponseMessage<List<Restaurant>>> gameListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "restaurant/getRestaurantById/" + restuarantID;
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,
            };

            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<List<Restaurant>>(getUserRequest, gameListener);
        }

        public static void GetAllSpas(Action<ResponseMessage<List<Restaurant>>> gameListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "spa/getAllSpas";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,
            };

            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<List<Restaurant>>(getUserRequest, gameListener);
        }

        public static void GetSpaById(string spaID, Action<ResponseMessage<List<Spa>>> gameListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "spa/getSpaById/" + spaID;
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,
            };

            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<List<Spa>>(getUserRequest, gameListener);
        }

        public static void GetAllGolfs(Action<ResponseMessage<List<GolfData>>> gameListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "golf/getAllGolfs";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,
            };

            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<List<GolfData>>(getUserRequest, gameListener);
        }

        public static void GetGolfById(string restuarantID, Action<ResponseMessage<List<GolfData>>> gameListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "golf/getGolfById/" + restuarantID;
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,
            };

            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<List<GolfData>>(getUserRequest, gameListener);
        }

        #endregion

        #region Challenge
        public static void CreateChallenge(CreateChallengegData createChallengeData, Action<ResponseMessage<CreateChallengegData>> tournamentListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "challenges/createChallenge";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                //_body = SparvisSerializer.Serialize(createChallengeData.GetRequestParams())

                _body = SparvisSerializer.Serialize(createChallengeData)
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<CreateChallengegData>(getUserRequest, tournamentListener);
        }

        public static void FetchChallenge(string id,Action<ResponseMessage<List<ChallengeData>>> tournamentListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "challenges/getAllChallengesByUserId/" + id;
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<List<ChallengeData>>(getUserRequest, tournamentListener);
        }

        public static void AcceptOrRejectChallenge(string id, string gameId, bool accepted, Action<ResponseMessage<ChallengeData>> tournamentListener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "challenges/acceptOrRejectChallenge";


            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new System.Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

            };

            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest<ChallengeData>(getUserRequest, tournamentListener);
        }
        #endregion

        #region Leaderboard
        public static void FetchLeaderBoardData(LeaderboardRequest requestData, Action<ResponseMessage<LeaderboardData>> tournamentListener)
        {
            //TODO : For testing hardcoding the url
            string requestPath = SparvisClient.instance._hostUrl + "leaderBoard/getLearBoard";
            //string requestPath = "https://unity-3f107.firebaseio.com/sparvis/leaderboard/-MbqA6GzmSxQGIVX78RD.json";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,


                _requestParameters = new Dictionary<string, string>() {
                    {"obj", SparvisSerializer.Serialize(requestData)}
                }
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest(getUserRequest, tournamentListener);
        }

        #endregion

        #region Leagues
        public static void FetchLeagueData(Action<ResponseMessage<Leagues>> listener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "sal/getAllLeaguesForActiveSeason";
            //string requestPath = "https://unity-3f107.firebaseio.com/sparvis/leagues.json";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest(getUserRequest, listener);
        }

        #endregion

        #region Awards
        public static void FetchAwardsData(Action<ResponseMessage<AchievementsData>> listener)
        {
            //TODO : For testing hardcoding the url
            string requestPath = SparvisClient.instance._hostUrl + "achievement/getUserAchievementById/" + Services.UserService._user._id;
            //string requestPath = "https://unity-3f107.firebaseio.com/sparvis/awards.json";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest(getUserRequest, listener);
        }

        public static void ClaimAward(string seasonID, string achievementID, Action<ResponseMessage<AchievementsData>> listener)
        {
            //TODO : For testing hardcoding the url
            string requestPath = SparvisClient.instance._hostUrl + "achievement/claimUserAchievementById";
            //string requestPath = "https://unity-3f107.firebaseio.com/sparvis/awards.json";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,

                 _body = SparvisSerializer.Serialize(new Dictionary<string, string>() {
                    {"seasonId", seasonID},
                    {"userId", Services.UserService._user._id},
                    {"achievementId", achievementID}
                })
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest(getUserRequest, listener);
        }

        #endregion

        #region Brand

        public static void FetchBrands(Action<ResponseMessage<List<BrandData>>> listener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "brand/getAllBandTileForMobile";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest(getUserRequest, listener);
        }


        #endregion

        #region GeoFence
        public static void FetchGeoFenceWishList(Action<ResponseMessage<List<GeoFenceWishListData>>> listener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "inAppNot/getUserNotificationWatchList/"+Services.UserService._user._id;
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.GET,
                _payload = new Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest(getUserRequest, listener);
        }

        public static void FireGeoFenceNotification(string notiId, Action<ResponseMessage<List<GeoFenceWishListData>>> listener)
        {
            string requestPath = SparvisClient.instance._hostUrl + "inAppNot/fireInAppGeoFenceNotification";
            RequestMessage getUserRequest = new RequestMessage()
            {
                _requestType = RequestMessage.RequestType.POST,
                _payload = new Guid().ToString(),
                _requestPath = requestPath,
                _headers = RequestMessage._defaultHeaders,
                _body = SparvisSerializer.Serialize(new Dictionary<string, string>() {
                    {"userId", Services.UserService._user._id},
                    {"notiId", notiId}
                })
            };
            getUserRequest._headers.Add("Authorization", "Bearer " + Services.UserService._user.token);
            SparvisClient.instance.DispatchRequest(getUserRequest, listener);
        }

        #endregion
    }
}