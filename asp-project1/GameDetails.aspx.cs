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
     * Project Made By: Gurpanth Singh 200299024 and Dilpreet Singh 200306382
     * Game Tracking App
     * 
     * 
     * */
    public partial class GameDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetGame();
            }
        }

        protected void GetGame()
        {
            // populate the form with existing department data from the db
            int GameID = Convert.ToInt32(Request.QueryString["gameID"]);

            // connect to the EF DB
            using (GameConnection db = new GameConnection())
            {
                // populate a department instance with the departmentID from the URL parameter
                game updatedGame = (from Games in db.games
                                    where Games.gameID == GameID
                                    select Games).FirstOrDefault();

                // map the Department properties to the form controls
                if (updatedGame != null)
                {
                    teamA.Text = updatedGame.teamA;
                    teamB.Text = updatedGame.teamB;
                    teamAScore.Text = updatedGame.teamAScore.ToString();
                    teamBScore.Text = updatedGame.teamBScore.ToString();

                }

            }
        }


        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Redirect back to Students page
            Response.Redirect("~/Default.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            using (GameConnection db = new GameConnection())
            {
                game newGame = new game();

                if (football.Checked == true)
                {
                    var game = "football";
                    newGame.teamA = teamA.Text;
                    newGame.teamB = teamB.Text;
                    newGame.teamAScore = Convert.ToInt32(teamAScore.Text);
                    newGame.teamBScore = Convert.ToInt32(teamBScore.Text);
                    newGame.selectedGame = game;
                    db.games.Add(newGame);
                    db.SaveChanges();

                }

                if (cricket.Checked == true)
                {
                    var game = "cricket";
                    newGame.teamA = teamA.Text;
                    newGame.teamB = teamB.Text;
                    newGame.teamAScore = Convert.ToInt32(teamAScore.Text);
                    newGame.teamBScore = Convert.ToInt32(teamBScore.Text);
                    newGame.selectedGame = game;
                    db.games.Add(newGame);
                    db.SaveChanges();

                }

                if (hockey.Checked == true)
                {
                    var game = "hockey";
                    newGame.teamA = teamA.Text;
                    newGame.teamB = teamB.Text;
                    newGame.teamAScore = Convert.ToInt32(teamAScore.Text);
                    newGame.teamBScore = Convert.ToInt32(teamBScore.Text);
                    newGame.selectedGame = game;
                    db.games.Add(newGame);
                    db.SaveChanges();

                }
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}