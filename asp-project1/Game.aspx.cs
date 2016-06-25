using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using asp_project1.Models;
using System.Web.ModelBinding;
namespace asp_project1
{
    /*
 * Project Made By: Gurpanth Singh 200299024 and Dilpreet Singh
 * Game Tracking App
 * 
 * 
 * */
    public partial class Game : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Populate the Games
            if (!IsPostBack)
            {
                //get the student data
                this.GetGames();
            }
        }
        protected void GetGames()
        {
            using (GameConnection db = new GameConnection())
            {
                var Games = (from allGames in db.games
                             select allGames);

                //Bind the result
                GamesGridView.DataSource = Games.ToList();
                GamesGridView.DataBind();
            }
        }

        protected void GamesGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int selectedRow = e.RowIndex;
            //get the select game id using the grids
            int gameID = Convert.ToInt32(GamesGridView.DataKeys[selectedRow].Values["gameID"]);
            //Removing  the data
            using (GameConnection db = new GameConnection())
            {
                game deletedGame = (from gameRecords in db.games
                                    where gameRecords.gameID == gameID
                                    select gameRecords).FirstOrDefault();

                //delete the selected game from the database
                db.games.Remove(deletedGame);

                db.SaveChanges();
                //Refresh the grid
                this.GetGames();
            }
        }
    }
}