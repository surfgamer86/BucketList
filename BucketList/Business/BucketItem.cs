using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketList.Business
{
   public class BucketItem
    {
        private int id;
        private string omschrijving;
        private bool gedaan;
        
        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Omschrijving
        {
            get { return omschrijving; }
            set { omschrijving = value; }
        }
        public bool Gedaan
        {
            get { return gedaan; }
            set { gedaan = value; }
        }
        public BucketItem()
        {
            omschrijving = "";
            gedaan = false;
        }
        public BucketItem(int bid, string bomschrijving, bool bgedaan)
        {
            id = bid;
            omschrijving = bomschrijving;
            gedaan = bgedaan;
        }
        public BucketItem(string bomschrijving, bool bgedaan)
        {
            omschrijving = bomschrijving;
            gedaan = bgedaan;
        }
    }
}
