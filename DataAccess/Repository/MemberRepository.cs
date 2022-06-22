using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMememberRepository
    {
        bool IMememberRepository.ChangePassword(string id, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        MemberObject IMememberRepository.CheckLogin(string email, string password)
        {
            throw new NotImplementedException();
        }

        bool IMememberRepository.CreateMember(MemberObject newMember)
        {
            throw new NotImplementedException();
        }

        bool IMememberRepository.DeleteMember(string id)
        {
            throw new NotImplementedException();
        }

        List<MemberObject> IMememberRepository.GetAllMembers()
        {
            throw new NotImplementedException();
        }

        List<MemberObject> IMememberRepository.GetMemberByCity(string city)
        {
            throw new NotImplementedException();
        }

        List<MemberObject> IMememberRepository.GetMemberByCityAndCountry(string city, string country)
        {
            throw new NotImplementedException();
        }

        List<MemberObject> IMememberRepository.GetMemberByCountry(string country)
        {
            throw new NotImplementedException();
        }

        MemberObject IMememberRepository.GetMemberById(string id)
        {
            throw new NotImplementedException();
        }

        List<MemberObject> IMememberRepository.SearchMemberById(string id)
        {
            throw new NotImplementedException();
        }

        List<MemberObject> IMememberRepository.SearchMemberByIdAndName(string searchName, string searchId)
        {
            throw new NotImplementedException();
        }

        List<MemberObject> IMememberRepository.SearchMemberByName(string name)
        {
            throw new NotImplementedException();
        }

        bool IMememberRepository.UpdateMember(string id, MemberObject updatedMemberInfo)
        {
            throw new NotImplementedException();
        }
    }
}
