using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using BucketList.Business;

namespace BucketList
{
    public class Persistcode
    {
        private string _connectionString;
        public Persistcode()
        {
            _connectionString = @"server=localhost;user id=root;persistsecurityinfo=True;database=bucketlistaliilyaan;password=test123";
        }
        public List<BucketItem> GetBucketItemFromDb()
        {
            List<BucketItem> lijst = new List<BucketItem>();
            //1 de connectie
            MySqlConnection conn = new MySqlConnection(_connectionString);
            //2 command
            MySqlCommand cmd = new MySqlCommand("select * from bucketitems ", conn);
            //3 records opvragen
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //4 Elk record inlezen via een lus
            //zolang er records zijn
            while (dataReader.Read() == true)
            {
                //elk record stoppen we in een lijst van type persoon
                //we maken gebruik van de constructor Persoon met id
                lijst.Add(new BucketItem(Convert.ToInt16(dataReader["id"]),
                    dataReader["Omschrijving"].ToString(),
                    Convert.ToBoolean(dataReader["Gedaan"]))); 

            }
            conn.Close();
            return lijst;
        }
        public void AddBucketItemToDb(BucketItem bucket)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("Insert into bucketitems(Omschrijving, gedaan) VALUES (@omschrijving, @gedaan)", conn);
            cmd.Parameters.AddWithValue("omschrijving", bucket.Omschrijving);
            cmd.Parameters.AddWithValue("gedaan", bucket.Gedaan);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DelBucketItem(int id)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("delete from bucketitems where id = " + id.ToString(), conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void WijzigBucketItem(int id, BucketItem bucket)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("update bucketitems set Omschrijving = @omschrijving, Gedaan = @gedaan where id = " + id.ToString(), conn);
            cmd.Parameters.AddWithValue("omschrijving", bucket.Omschrijving);
            cmd.Parameters.AddWithValue("gedaan", bucket.Gedaan);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public int GetAantalBucketItems()
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("select count(*) from bucketitems", conn);
            conn.Open();
            int aantal = Convert.ToInt16(cmd.ExecuteScalar());
            conn.Close();
            return aantal;
        }
        
    }
}
