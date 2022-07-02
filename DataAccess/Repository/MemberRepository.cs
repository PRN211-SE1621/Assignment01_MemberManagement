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
            => MemberDBContext.Instance.GetUserByEmailAndPassword(email, password);

        public bool CreateMember(MemberObject newMember)
        {
            try
            {
                MemberDBContext.Instance.AddNew(newMember);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteMember(string id)
        {
            MemberObject member = null;
            try
            {
                int intId = int.Parse(id);
                member = MemberDBContext.Instance.GetMemberByID(intId);
                MemberDBContext.Instance.Remove(member);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public IEnumerable<MemberObject> GetAllMembers() => MemberDBContext.Instance.GetMemberList();

        public List<MemberObject> GetMemberByCity(string city)
        {
            List<MemberObject> resultList = new List<MemberObject>();
            foreach (MemberObject member in MemberDBContext.Instance.GetMemberList())
            {
                if (member.City.Contains(city))
                {
                    resultList.Add(member);
                }
            }
            return resultList;
        }

        public List<MemberObject> GetMemberByCityAndCountry(string city, string country)
        {
            List<MemberObject> resultList = new List<MemberObject>();
            if(country == null || country.Equals(""))
            {
                if(city == null || city.Equals(""))
                {
                    resultList.AddRange(GetAllMembers());
                }
                else
                {
                    resultList.AddRange(GetMemberByCity(city));
                }
            }
            else
            {
                if (city == null || city.Equals(""))
                {
                    resultList.AddRange(GetMemberByCountry(country));
                }
                else
                {
                    foreach(MemberObject member in GetMemberByCountry(country))
                    {
                        if (member.City.Contains(city))
                        {
                            resultList.Add(member);
                        }
                    }
                }
            }
            return resultList;
        }

        public List<MemberObject> GetMemberByCountry(string country)
        {
            List<MemberObject> resultList = new List<MemberObject>();
            foreach (MemberObject member in MemberDBContext.Instance.GetMemberList())
                {
                    if (member.Country.Contains(country))
                    {
                        resultList.Add(member);
                    }
                }
            return resultList;
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

        public IEnumerable<MemberObject> SearchMemberByIdAndName(string id, string name)
        {
            List<MemberObject> resultList = new List<MemberObject>();
            if (name == null || name.Equals(""))
            {
                if (id == null || id.Equals(""))
                {
                    resultList.AddRange(GetAllMembers());
                }
                else
                {
                    resultList.AddRange(SearchMemberById(id));
                }
            }
            else
            {
                if (id == null || id.Equals(""))
                {
                    resultList.AddRange(SearchMemberByName(name));
                }
                else
                {
                    foreach (MemberObject member in SearchMemberById(id))
                    {
                        if (member.MemberID.ToString().Contains(id))
                        {
                            resultList.Add(member);
                        }
                    }
                }
            }
            return resultList;
        }

        public IEnumerable<MemberObject> SearchMemberByName(string name)
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

        public bool UpdateMember(MemberObject updatedMemberInfo)
        {
            try
            {
                MemberDBContext.Instance.Update(updatedMemberInfo);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<MemberObject> GetMembersFilterByCountryAndCity(string country, string city)
        {
            return MemberDBContext.Instance.getAllMembersFilterByCountryAndCity(country, city);
        }

        public IEnumerable<MemberObject> SortByMemberName(IEnumerable<MemberObject> members)
        {
            return members.OrderBy(member => member.MemberName);
        }
    }
}