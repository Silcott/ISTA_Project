using DAL;
using DAL.Classes;
using System.Data;
using System;

namespace BLL
{
    public class Dashboard_BL
    {
        public void CreateClient( string firstName, string lastName, string email, string password )
        {
            var newClient = new Client( )
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            using ( var db = new DataConn_DB() )
            {
                db.clients.Add( newClient );
                db.SaveChanges( );
            }
        }

        public void UpdateClient( int clientId, Client client )
        {
            using ( var db = new DataConn_DB() )
            {
                var currentClient = db.clients.Find( clientId );
                currentClient.FirstName = client.FirstName;
                currentClient.LastName = client.LastName;
                currentClient.Email = client.Email;

                db.SaveChanges( );
            }
        }

        public void DeleteClient( int clientId )
        {
            using ( var db = new DataConn_DB() )
            {
                var currentClient = db.clients.Find( clientId );
                db.clients.Remove( currentClient );

                db.SaveChanges( );
            }
        }
    }
}
