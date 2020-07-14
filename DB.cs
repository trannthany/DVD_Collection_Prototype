using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace DVDLib
{
    public class DB
    {
        const string CSTRING = @"Data Source=C:\Users\sigma\Thany\SQLiteDatabaseBrowserPortable\Databases\DVD_Collection.db;Version=3";
        //fetch a list of DVDs from the database
        public static List<DVD> LoadAllDVDs() 
        {
            List<DVD> dvds = new List<DVD>();
           
            using (SQLiteConnection conn = new SQLiteConnection(CSTRING)) 
            {
                conn.Open();
                string sql_command = string.Format("select * from DVDs");
                using (SQLiteCommand cmd = new SQLiteCommand(sql_command, conn)) 
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader()) 
                    {
                        while (rdr.Read()) 
                        {
                            DVD dvd = new DVD (rdr.GetString(1), 
                                rdr.GetString(2),
                                rdr.GetInt32(3),
                                rdr.GetString(4));
                            dvd.ID = rdr.GetInt32(0);
                            dvds.Add(dvd);
                        }
                        rdr.Close();
                    }
                }
                conn.Close();
            }

            return dvds;
        }

        //Add a DVD into the database
        public static void AddDVD(DVD dvd) 
        {
           
            using (SQLiteConnection conn = new SQLiteConnection(CSTRING)) 
            {
                conn.Open();
                
                using (SQLiteCommand cmd = new SQLiteCommand(conn)) 
                {
                    cmd.CommandText = string.Format("INSERT INTO DVDs (Title, Director, Year, Language)" +
                        " VALUES ('{0}', '{1}', {2}, '{3}')", dvd.Title, dvd.Director, dvd.Year, dvd.Language);
                    cmd.ExecuteNonQuery();
                }

               conn.Close();
            }
        }

        //Update a DVD in the Database (using its id as the key field
        public static void UpdateDVD(DVD dvd) 
        {
           
            using (SQLiteConnection conn = new SQLiteConnection(CSTRING))
            {
                conn.Open();
                string title = dvd.Title;           

                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = string.Format("UPDATE DVDs SET Title='{0}', Director='{1}', Year={2}, Language='{3}'" +
                        " WHERE ID={4}", dvd.Title, dvd.Director, dvd.Year, dvd.Language, dvd.ID);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        //Delete a DVD in the database given its id
        public static void DeleteDVD(int id) 
        {
            
            using (SQLiteConnection conn = new SQLiteConnection(CSTRING))
            {
                conn.Open();
               

                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = string.Format("DELETE FROM DVDs WHERE ID='{0}'", id);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }
    }
}
