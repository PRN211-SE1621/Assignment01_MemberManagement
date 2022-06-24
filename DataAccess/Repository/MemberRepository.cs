using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;

namespace DataAccess.Repository
{
    public class MemberRepository : IMememberRepository
    {
        public bool ChangePassword(string id, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public MemberObject CheckLogin(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool CreateMember(MemberObject newMember)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMember(string id)
        {
            throw new NotImplementedException();
        }

        public List<MemberObject> GetAllMembers()
        {
            throw new NotImplementedException();
        }

        public List<MemberObject> GetMemberByCity(string city)
        {
            throw new NotImplementedException();
        }

        public List<MemberObject> GetMemberByCityAndCountry(string city, string country)
        {
            throw new NotImplementedException();
        }

        public List<MemberObject> GetMemberByCountry(string country)
        {
            throw new NotImplementedException();
        }

        public MemberObject GetMemberById(string id)
        {
            throw new NotImplementedException();
        }

        public List<MemberObject> SearchMemberById(string id)
        {
            throw new NotImplementedException();
        }

        public List<MemberObject> SearchMemberByIdAndName(string searchName, string searchId)
        {
            throw new NotImplementedException();
        }

        public List<MemberObject> SearchMemberByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMember(string id, MemberObject updatedMemberInfo)
        {
            throw new NotImplementedException();
        }
    }
}
