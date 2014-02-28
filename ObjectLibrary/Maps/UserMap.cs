using FluentNHibernate.Mapping;

namespace ObjectLibrary.Maps
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.ID);
            Map(x => x.Name);
            Map(x => x.Password);
            Map(x => x.Salt);
        }
    }
}