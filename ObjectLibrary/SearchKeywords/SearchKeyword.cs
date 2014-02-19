namespace ObjectLibrary.SearchKeywords
{
    public abstract class SearchKeyword : BaseObject
    {
        protected SearchKeyword()
        { }

        protected SearchKeyword(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
