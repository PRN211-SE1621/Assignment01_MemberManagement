using BussinessObject;
using DataAccess.Context;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
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

        public IEnumerable<MemberObject> GetAllMembers() => MemberDBContext.Instance.GetMemberList();

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
            MemberObject member = null;
            try
            {
                int intId = int.Parse(id);
                member = MemberDBContext.Instance.GetMemberByID(intId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return member;
        }

        public List<MemberObject> SearchMemberById(string id)
        {
            List<MemberObject> resultList = new List<MemberObject>();
            try
            {

                if (GetMemberById(id) != null)
                    resultList.Add(GetMemberById(id));
                int intId = int.Parse(id);
                foreach (MemberObject member in MemberDBContext.Instance.GetMemberList())
                {
                    if (member.MemberID.ToString().Contains(id) && !member.MemberID.ToString().Equals(id))
                    {
                        resultList.Add(member);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return resultList;
        }

        public List<MemberObject> SearchMemberByIdAndName(string searchName, string searchId)
        {
            List<MemberObject> resultList = new List<MemberObject>();
            if (searchName == null || searchName.Equals(""))
            {
                if (searchId == null || searchId.Equals(""))
                {
                    resultList.AddRange(GetAllMembers());
                }
                else
                {
                    resultList.AddRange(SearchMemberById(searchId));
                }
            }
            else
            {
                if (searchId == null || searchId.Equals(""))
                {
                    resultList.AddRange(SearchMemberByName(searchName));
                }
                else
                {
                    foreach (MemberObject member in SearchMemberById(searchId))
                    {
                        if (member.MemberID.ToString().Contains(searchId))
                        {
                            resultList.Add(member);
                        }
                    }
                }
            }
            return resultList;
        }

        public List<MemberObject> SearchMemberByName(string name)
        {
            List<MemberObject> resultList = new List<MemberObject>();
            foreach (MemberObject member in MemberDBContext.Instance.GetMemberList())
            {
                if (member.MemberName.Contains(name))
                {
                    resultList.Add(member);
                }
            }
            return resultList;
        }

        public bool UpdateMember(string id, MemberObject updatedMemberInfo)
        {
            throw new NotImplementedException();
        }
    }
}