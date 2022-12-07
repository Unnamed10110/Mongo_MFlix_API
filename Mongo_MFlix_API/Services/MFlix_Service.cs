using AutoMapper;
using Mongo_MFlix_API.Models;
using MongoDB.Driver;

namespace Mongo_MFlix_API.Services
{
    public class MFlix_Service
    {
        private readonly IMFlix_DBSettings DBSettings;
        private IMongoCollection<MFlix_Collection> mflix_Collection;
        public MFlix_Service(IMFlix_DBSettings DBSettings)
        {
            this.DBSettings = DBSettings;
            var clientMongo = new MongoClient(DBSettings.Server);
            var database = clientMongo.GetDatabase(DBSettings.Database);
            mflix_Collection = database.GetCollection<MFlix_Collection>(DBSettings.Collection);
        }

        public List<MFlix_Collection> GetAll()
        {
            return mflix_Collection.Find(x=>true).ToList();
        }
        public MFlix_Collection GetOne(string id)
        {
            var fullCollection=mflix_Collection.Find(x => x.Id==id).ToList();

            var partialCollection = new MFlix_Collection();

            {
                partialCollection.Title = fullCollection[0].Title;
                partialCollection.Genres = fullCollection[0].Genres;
                partialCollection.FullPlot = fullCollection[0].FullPlot;
                partialCollection.Released= fullCollection[0].Released;
                partialCollection.Id = fullCollection[0].Id;
                partialCollection.Runtime = fullCollection[0].Runtime;
                partialCollection.Year = fullCollection[0].Year;
                partialCollection.Poster = fullCollection[0].Poster;
                partialCollection.Plot = fullCollection[0].Plot;
            }

            return partialCollection;

        }
        public MFlix_Collection PostOne(MFlix_Collection document)
        {
            mflix_Collection.InsertOne(document);

            return document;

        }
        
        public MFlix_Collection Update(string id, MFlix_Collection document)
        {
            mflix_Collection.ReplaceOne(x=>x.Id==id,document);

            return document;

        }
        
        public MFlix_Collection Delete(string id)
        {
            var fullCollection=mflix_Collection.Find(x=>x.Id== id).ToList();
            mflix_Collection.DeleteOne(x=>x.Id==id);
            var partialCollection = new MFlix_Collection();

            {
                partialCollection.Title = fullCollection[0].Title;
                partialCollection.Genres = fullCollection[0].Genres;
                partialCollection.FullPlot = fullCollection[0].FullPlot;
                partialCollection.Released = fullCollection[0].Released;
                partialCollection.Id = fullCollection[0].Id;
                partialCollection.Runtime = fullCollection[0].Runtime;
                partialCollection.Year = fullCollection[0].Year;
                partialCollection.Poster = fullCollection[0].Poster;
                partialCollection.Plot = fullCollection[0].Plot;
            }

            return partialCollection;

        }
    }

}
