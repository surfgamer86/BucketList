using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketList.Business
{
    class BusinessController
    {
        private Persistcode _persistcode = new Persistcode();
        public List<BucketItem> getbucketitems()
        {
            List<BucketItem> lijst = new List<BucketItem>();
            foreach (BucketItem bucketitem in _persistcode.GetBucketItemFromDb())
            {
                lijst.Add(bucketitem);
            }
            return lijst;
        }
        public void AddBucketItem(string omschrijving, bool gedaan)
        {
            BucketItem bucket = new BucketItem(omschrijving, gedaan);
            _persistcode.AddBucketItemToDb(bucket);
        }
        public void DelBucketItem(int id)
        {
            _persistcode.DelBucketItem(id);
        }
        
    }
}
