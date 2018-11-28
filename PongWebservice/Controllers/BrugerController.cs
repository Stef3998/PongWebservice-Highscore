using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
        //private const string connection1 = "Server=tcp:mylogicalserver12345.database.windows.net,1433;Initial Catalog=customerdatabase;Persist Security Info=False;User ID=steffen;Password=Test12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


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
                                int winstreak = reader.GetInt32(5);

                                var bruger = new Bruger()
                                {
                                    Brugernavn = brugernavn,
                                    Highscore = highscore,
                                    Wins = wins,
                                    Loses = loses,
                                    Winstreak = winstreak
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
        public void Post([FromBody] string value)
        {
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
