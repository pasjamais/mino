using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;

namespace mino
{
    public class dbAgent
    {
        public static readonly String DB_Path_Debut = "Data Source=";
        public static readonly String DB_FileName = "mino.db";
        public static readonly String BackupDirName = "Backup";
        public static readonly String BackupFileName = "BackupDB";
  
        minoContext db;
        public dbAgent()
        {
            db = new minoContext();
        }

        #region  General
        public void Close()
        {
            db.Dispose();
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public static void Backup_DB()
        {
            String newfilename = (BackupFileName + " " + DateTime.Now.ToString()).Replace(':', '-');
            if (File.Exists(DB_FileName))
            {
                if (!Directory.Exists(BackupDirName)) Directory.CreateDirectory(BackupDirName);
                File.Copy(DB_FileName, BackupDirName + "\\" + newfilename);
            }
        }
        #endregion

        #region  Cabinet

        public void AddCabinet(Cabinet cabinet)
        {
            db.Cabinets.Add(cabinet);
            db.SaveChanges();
        }
        public List<Cabinet> Get_Cabinets()
        {
            var cabinets = db.Cabinets.ToList();
            return cabinets;
        }

        public void DeleteCabinet(Cabinet cabinet)
        {
            db.Cabinets.Remove(cabinet);
            db.SaveChanges();
        }
        #endregion

        #region PC
        public List<Pc> GetPCs()
        {
            var pcs = db.Pcs.ToList();
            return pcs;
        }

        public Pc GetPc(long id)
        {
            return db.Pcs.Find(id);

        }

        #endregion

        # region User
        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public List<User> Get_Users()
        {
            var users = db.Users.ToList();
            return users;
        }
        public void DeleteUser(User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public User GetUser(long id)
        {
            return db.Users.Find(id);

        }

        #endregion

        #region  Journal
        public List<ServiceJournal> Get_Journal()
        {
            var journals = db.ServiceJournals.ToList();
            return journals;
        }

        public void AddJournalRecord(ServiceJournal record)
        {
            db.ServiceJournals.Add(record);
            db.SaveChanges();
        }
        #endregion

        #region  TypesOfService

        public List<TypesOfService> Get_Manipulations()
        {
            var typesOfService = db.TypesOfServices.ToList();
            return typesOfService;
        }
        #endregion

        #region  TechCartridgesRotation
        public void AddCartridgeRotation(TechCartridgesRotation cartridgeRotation)
        {
            db.TechCartridgesRotations.Add(cartridgeRotation);
            db.SaveChanges();
        }

        #endregion

        #region  Query
        public String GetQueryText(int number)
        {
            // извлекаем нужный текст запроса из БД с помощью LINQ,
            // используя номер запроса
            var query_text = (from q in Get_Queries()
                              where q.Id == number
                              select q).Take(1).First().Text;
            return query_text;
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
                public Query Get_Query(int number)
        {
            var queries = db.Queries.ToList();
            return queries[number];
        }

        public void AddQuery(Query query)
        {
            db.Queries.Add(query);
            db.SaveChanges();
        }
        #endregion

        #region TechModelsOfPrinter
        public List<TechModelsOfPrinter> Get_Printer_Models()
        {
            var techModelsOfPrinter = db.TechModelsOfPrinters.ToList();
            return techModelsOfPrinter;
        }


        #endregion

        #region Place
        public void AddPlace(Place place)
        {
            db.Places.Add(place);
            db.SaveChanges();
        }
        public Place GetPlace(long id)
        {
            return db.Places.Find(id);

        }
        public List<Place> Get_Places()
        {
            var places = db.Places.ToList();
            return places;
        }
        public void DeletePlace(Place place)
        {

            db.Places.Remove(place);
            db.SaveChanges();
        }

        public bool isPlaceAlreadyExist(string placelName)
        {
            return (Get_Places().Exists(p => (p.Name == placelName)));

        }
        #endregion

        #region ModelOfCartridge
        public void AddCartridgeModel(TechModelsOfCartridge cartridgeModel)
        {
            db.TechModelsOfCartridges.Add(cartridgeModel);
            db.SaveChanges();
        }

        public TechModelsOfCartridge GetCartridgeModel(long id)
        {
            return db.TechModelsOfCartridges.Find(id);

        }
        public List<TechModelsOfCartridge> Get_CartridgeModels()
        {
            var cartridgeModels = db.TechModelsOfCartridges.ToList();
            return cartridgeModels;
        }

        public void DeleteCartridgeModel(TechModelsOfCartridge cartridgeModel)
        {
            db.TechModelsOfCartridges.Remove(cartridgeModel);
            db.SaveChanges();
        }

        public bool isCartridgeModelAlreadyExist(string cartridgeModelName)
        {
            return (Get_CartridgeModels().Exists(p => (p.Name == cartridgeModelName)));

        }
       
        #endregion


        #region Alliance
        public void AddAlliance(TechPrinterCartridgeAlliance printerCartridgeAlliance)
        {
            db.TechPrinterCartridgeAlliances.Add(printerCartridgeAlliance);
            db.SaveChanges();
        }

        public void DeleteAlliance(TechPrinterCartridgeAlliance printerCartridgeAlliance)
        {
            db.TechPrinterCartridgeAlliances.Remove(printerCartridgeAlliance);
            db.SaveChanges();
        }

        public List<TechPrinterCartridgeAlliance> Get_Alliances()
        {
            var alliances = db.TechPrinterCartridgeAlliances.ToList();
            return alliances;
        }

        public TechPrinterCartridgeAlliance GetAlliance(long id)
        {
            return db.TechPrinterCartridgeAlliances.Find(id);

        }
        public bool isAllianceAlreadyExist(long printerModelId, long cartridgeModelId)
        {
            return Get_Alliances().Exists(p => (p.PrinterModel == printerModelId && p.CartridgeModel == cartridgeModelId));
        }
        #endregion



    }
}
