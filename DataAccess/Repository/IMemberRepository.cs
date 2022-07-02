using BussinessObject;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        public bool CreateMember(MemberObject newMember);

        public bool DeleteMember(string id);

        public bool UpdateMember(MemberObject updatedMemberInfo);

        public MemberObject GetMemberById(string id);

        public IEnumerable<MemberObject> GetAllMembers();

        public IEnumerable<MemberObject> SearchMemberByName(string name);
        public IEnumerable<MemberObject> SearchMemberByIdAndName(string id, string name);

        public List<MemberObject> SearchMemberById(string id);

        public List<MemberObject> GetMemberByCity(string city);

        public List<MemberObject> GetMemberByCountry(string country);

        public MemberObject CheckLogin(string email, string password);

        public void ChangePassword(int id, string oldPassword, string newPassword, string confirmPassword);
        public IEnumerable<MemberObject> SortByMemberName(IEnumerable<MemberObject> members);
        public IEnumerable<MemberObject> GetMembersFilterByCountryAndCity(string country, string city, IEnumerable<MemberObject> members);
    }
}