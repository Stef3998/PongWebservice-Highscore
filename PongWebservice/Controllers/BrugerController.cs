using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PongWebservice.Model;

namespace PongWebservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrugerController : ControllerBase
    {

        private const string connection = "Data Source=ponglegends.database.windows.net;Initial Catalog=PongDatabase;User ID=legendsadmin;Password=P@ssw0rd;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //private const string insertBruger = "insert into Bruger (Brugernavn) values (@Brugernavn)";

        // GET: api/Bruger
        [HttpGet]
        public IEnumerable<Bruger> GetBruger()
        {
            var result = new List<Bruger>();
            string sql = "select * from Bruger";
            using (SqlConnection databaseConnection = new SqlConnection(connection))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(sql, databaseConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //int bruger_id = reader.GetInt32(0);
                                string brugernavn = reader.GetString(1);
                                int highscore = reader.GetInt32(2);
                                int wins = reader.GetInt32(3);
                                int loses = reader.GetInt32(4);
                                int ai_wins = reader.GetInt32(5);
                                int ai_loses = reader.GetInt32(6);
                                int block_highscore = reader.GetInt32(7);
                                int block_total_points = reader.GetInt32(8);

                                var bruger = new Bruger()
                                {
                                    Brugernavn = brugernavn,
                                    Highscore = highscore,
                                    Wins = wins,
                                    Loses = loses,
                                    AI_Wins = ai_wins,
                                    AI_Loses = ai_loses,
                                    Block_Highscore = block_highscore,
                                    Block_Total_Points = block_total_points
                                };

                                result.Add(bruger);
                            }
                        }
                    }
                }
            }

            return result;
        }

        // GET: api/Bruger/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Bruger
        [HttpPost]
        public void PostBruger([FromBody] BrugerModel brugerModel)
        {
            string insertBruger = "INSERT into Bruger (Bruger_Id, Brugernavn) VALUES (@Id, @Brugernavn)";

            SqlConnection connect = new SqlConnection(connection);
            using (SqlCommand insertCommand = new SqlCommand(insertBruger, connect))
            {
                Console.WriteLine(brugerModel.ID + "  " + brugerModel.Brugernavn);
                connect.Open();
                insertCommand.Parameters.AddWithValue("@Id", brugerModel.ID);
                insertCommand.Parameters.AddWithValue("@Brugernavn", brugerModel.Brugernavn);
                int rowsAffeced = insertCommand.ExecuteNonQuery();
                //Console.WriteLine(rowsAffeced + " row(s) affected");
            }

        }

        // PUT: api/Bruger/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
