namespace Models {
    public interface IBooksDBSettings
    {
        string BookCollectionName {get;set;}
        string ConnectionString {get;set;}
        string DatabaseName {get;set;}
    }
    public class BooksDBSetting : IBooksDBSettings {
        public string BookCollectionName {get;set;}
        public string ConnectionString {get;set;}
        public string DatabaseName {get;set;}
    }
}