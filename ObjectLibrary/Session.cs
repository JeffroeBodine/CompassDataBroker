using System;
using System.Runtime.Serialization;
using FluentNHibernate.Mapping;

namespace ObjectLibrary
{
    [DataContract]
    public class Session : BaseObject
    {
        [DataMember(Order = 100)]
        public virtual long FkUser { get; set; }
        [DataMember(Order = 101)]
        public virtual DateTime CreateDate { get; set; }

        public Session()
        {
        }

        public Session(long id, string name, long fkUser, DateTime createDate) : base(id, name)
        {
            FkUser = fkUser;
            CreateDate = createDate;
        }

        public class Map : ClassMap<Session>
        {
            public Map()
            {
                Id(x => x.ID).Column("ID").GeneratedBy.Identity();
                Map(x => x.Name);
                Map(x => x.FkUser);
                Map(x => x.CreateDate);
            }
        }
    }


}
