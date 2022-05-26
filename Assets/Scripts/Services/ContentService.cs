using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ContentService
{
    // Brand Control Variables
    public BrandData selectedBrand;
    public BrandDashBoard selectedBrandDashboard;
    public BrandMenu selectedBrandMenu;

	#region GamesAPI
	public void AddGame(AddNewGameRequestData addGameRequestData, Action<Backend.ResponseMessage<Game>> gameListener)
	{
		Backend.ContentAPI.AddGame(addGameRequestData, gameListener);
	}
	public void GetAllGames(Action<Backend.ResponseMessage<Game[]>> gameListener)
	{
		Backend.ContentAPI.GetAllGames(gameListener);
	}
	public void GetGameByID(string gameID, Action<Backend.ResponseMessage<Game>> gameListener)
	{
		Backend.ContentAPI.GetGameByID(gameID, gameListener);
	}

    public void GetAllGamesForDropDown(Action<List<GameDropdown>> listener)
    {
        
    }

    #endregion GamesAPI

    #region Season

    public void GetCurrentSeason(Action<SeasonAndLeague> listener)
    {

    }

    #endregion

    public void CreateTournament(CreateTournamentRequestData addTournamentRequestData, Action<Backend.ResponseMessage<Tournament>> tournamentListener)
	{
		Backend.ContentAPI.CreateTournament(addTournamentRequestData, tournamentListener);
	}

    public void CreateTournamentDummy(CreateTournamentRequestData addTournamentRequestData, Action<Backend.ResponseMessage<Tournament>> tournamentListener)
    {
        Backend.ContentAPI.CreateTournamentDummy(addTournamentRequestData, tournamentListener);
    }

    public void GetAllTournaments(Action<Backend.ResponseMessage<Tournament[]>> gameListener)
	{
		Backend.ContentAPI.GetAllTournaments(gameListener);
	}
	public void GetTournamentByID(string tournamentID, Action<Tournament> tournamentListener)
	{
        Backend.ContentAPI.GetTournamentByID(tournamentID, (tournamentData) => {

            if (tournamentData._statusCode != (int)System.Net.HttpStatusCode.OK)
            {
                
            }
            else if (tournamentData._statusCode == (int)System.Net.HttpStatusCode.OK)
            {
                tournamentListener?.Invoke(tournamentData._entity);
            }

        });
    }
	public void GetAvailableTournaments(Action<Backend.ResponseMessage<List<Tournament>>> tournamentListener)
	{
		Backend.ContentAPI.GetAvailableTournaments(tournamentListener);
	}

    public void GetAvailableTournamentsAndChallenges(Action<Backend.ResponseMessage<List<Tournament>>> tournamentListener)
    {
        Backend.ContentAPI.GetAvailableTournamentsAndChallenges(tournamentListener);
    }


}
