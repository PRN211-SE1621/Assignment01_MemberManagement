using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;

namespace DataAccess.Repository
{
    public interface IMememberRepository
    {
        public bool CreateMember(MemberObject newMember);

        public bool DeleteMember(string id);

        public bool UpdateMember(string id, MemberObject updatedMemberInfo);

        public MemberObject GetMemberById(string id);

        public List<MemberObject> GetAllMembers();

        public List<MemberObject> SearchMemberByName(string name);

        public List<MemberObject> SearchMemberById(string id);

        public List<MemberObject> GetMemberByCity(string city);

        public List<MemberObject> GetMemberByCountry(string country);

        public MemberObject CheckLogin(string email, string password);

        public bool ChangePassword(string id, string oldPassword, string newPassword);

        public List<MemberObject> SearchMemberByIdAndName(string searchName, string searchId);

        public List<MemberObject> GetMemberByCityAndCountry(string city, string country);
    }
}
