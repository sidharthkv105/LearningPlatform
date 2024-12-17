using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using LearningPlatform.Models;
using System.Data;

namespace LearningPlatform.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
            SqlParameter[] parameters = {
            new SqlParameter("@Username", username),
            new SqlParameter("@Password", password)
        };

            var dt = dbHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                int userId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                Session["UserId"] = userId;
                return RedirectToAction("UserProfile", new { id = userId });
            }

            ViewBag.ErrorMessage = "Invalid username or password";
            return View();
        }

        public ActionResult UserProfile(int id)
        {
            var dbHelper = new DatabaseHelper();

            // Fetch user progress
            string progressQuery = "SELECT * FROM UserProgress WHERE UserId = @UserId";
            SqlParameter[] progressParams = { new SqlParameter("@UserId", id) };
            var progressData = dbHelper.ExecuteQuery(progressQuery, progressParams);

            // Fetch achievements
            string achievementsQuery = "SELECT * FROM Achievements WHERE UserId = @UserId";
            SqlParameter[] achievementsParams = { new SqlParameter("@UserId", id) };
            var achievementsData = dbHelper.ExecuteQuery(achievementsQuery, achievementsParams);

            // Fetch leaderboard with Username
            string leaderboardQuery = "SELECT TOP 10 L.RankId, L.UserId, L.Points, U.Username " +
                                      "FROM Leaderboard L " +
                                      "JOIN Users U ON L.UserId = U.UserId " +
                                      "ORDER BY L.Points DESC";
            var leaderboardData = dbHelper.ExecuteQuery(leaderboardQuery);

            var leaderboardList = new List<Leaderboard>();
            foreach (DataRow row in leaderboardData.Rows)
            {
                leaderboardList.Add(new Leaderboard
                {
                    RankId = Convert.ToInt32(row["RankId"]),
                    UserId = Convert.ToInt32(row["UserId"]),
                    Points = Convert.ToInt32(row["Points"]),
                    Username = row["Username"].ToString() 
                });
            }

            ViewBag.LeaderboardData = leaderboardList;


            // Fetch rewards
            string rewardQuery = "SELECT * FROM Rewards WHERE UserId = @UserId";
            SqlParameter[] rewardParams = { new SqlParameter("@UserId", id) };
            var rewardData = dbHelper.ExecuteQuery(rewardQuery, rewardParams);

            ViewBag.ProgressData = progressData;
            ViewBag.AchievementsData = achievementsData;
            ViewBag.LeaderboardData = leaderboardList;
            ViewBag.RewardData = rewardData;
            ViewBag.CurrentUserId = id.ToString(); 

            return View();
        }


    }

}