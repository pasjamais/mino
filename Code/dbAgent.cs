using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace mino
{
    public class dbAgent
    {
        minoContext db;
        public dbAgent()
        {
            db = new minoContext();
        }
        public void Close()
        {
            db.Dispose();
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
        public List <Cabinet> Get_Cabinets()
        { 
            var cabinets = db.Cabinets.ToList();
            return cabinets;
        }
        public List<User> Get_Users()
        {
            var users = db.Users.ToList();
            return users;
        }

        
        public BindingList<Query> Get_Queries_BindingList()
        {
            return db.Queries.Local.ToBindingList();
        }
        public List<Query> Get_Queries()
        {
            var queries = db.Queries.ToList();
            return queries;
        }

        public void AddQuery(Query query)
        {
            db.Queries.Add(query);
            db.SaveChanges();
        }
        public void AddCartridgeRotation(TechCartridgesRotation techCartridgesRotation)
        {
            db.TechCartridgesRotations.Add(techCartridgesRotation);
            db.SaveChanges();
        }
        public List<ServiceJournal> Get_Journal()
        {
            var journals = db.ServiceJournals.ToList();
            return journals;
        }
    }
}
