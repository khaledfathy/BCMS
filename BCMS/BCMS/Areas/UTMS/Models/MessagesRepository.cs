using BCMS.Areas.UTMS.Hubs;
using BCMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace BCMS.Areas.UTMS.Models
{
    public class MessagesRepository
    {
        readonly string _connString = ConfigurationManager.ConnectionStrings["BorsaCapitalDataModel"].ConnectionString;
        //BorsaCapitalDataModel db = new BorsaCapitalDataModel();

        // For market caster
        public IEnumerable<Tadawel> GetAllMessages()
        {
            SqlDependency.Stop(_connString);
            var tdawol = new List<Tadawel>();
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                using (var command = new SqlCommand(@"SELECT [CODE], [NAME], [CASHFLOWIN], [CASHFLOWOUT], [TREND], [CHANGE] , [CHANGEPEST], [BESTASKQ], [BESTBIDP], [BESTBIDQ], [VOLUME], [VALUE], [TRANSACTIONS], [ASKBID], [CASHFLOWPLAN] FROM [dbo].[Tadawel]", connection))
                {
                    command.Notification = null;
                    var dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    SqlDependency.Start(_connString);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        tdawol.Add(item: new Tadawel { CODE = (double)reader["CODE"], NAME = (string)reader["NAME"], CASHFLOWIN = (double)reader["CASHFLOWIN"], CASHFLOWOUT = (double)reader["CASHFLOWOUT"], TREND = (string)reader["TREND"], CHANGE = (string)reader["CHANGE"], CHANGEPEST = (string)reader["CHANGEPEST"], BESTASKQ = (string)reader["BESTASKQ"], BESTBIDP = (string)reader["BESTBIDP"], BESTBIDQ = (string)reader["BESTBIDQ"], VOLUME = (string)reader["VOLUME"], VALUE = (string)reader["VALUE"], TRANSACTIONS = (string)reader["TRANSACTIONS"], ASKBID = (string)reader["ASKBID"], CASHFLOWPLAN = (string)reader["CASHFLOWPLAN"] });
                    }
                }
            }
            return tdawol;
        }

        // For borsa cloud
        public Object GetSectorsAndCategories()
        {
            SqlDependency.Stop(_connString);
            var tdawol = new List<Tadawel>();
            //var ccc = db.Tadawels.GroupBy(a=>a.RecordID).Select(x => x.Select(v=>new { v.NAME, v.CHANGE, v.Sector.SectorName})).ToList();

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                using (var command = new SqlCommand(@"SELECT  [NAME],[CHANGE] , [RecordId] FROM [dbo].[Tadawel] ", connection))
                {
                    command.Notification = null;
                    var dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    SqlDependency.Start(_connString);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        tdawol.Add(item: new Tadawel { NAME = (string)reader["NAME"], CHANGE = (string)reader["CHANGE"], RecordID = (int)reader["RecordID"] });
                    }
                }
            }
            return tdawol;
        }

        // Fire when change in database
        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                MessagesHub.SendMessages();
            }
        }

    }
}