using BussinessObject;

namespace DataAccess
{
    public class MemberDAO
    {
        private static List<MemberObject> MemberList = new List<MemberObject>();
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }
        public List<MemberObject> GetCarList => MemberList;

        public MemberObject GetCarByID(int memberID)
        {
            MemberObject member = MemberList.SingleOrDefault(pro => pro.MemberID == memberID);
            return member;
        }

        public void AddNew(MemberObject member)
        {
            MemberObject pro = GetCarByID(member.MemberID);
            if (pro == null)
            {
                MemberList.Add(member);
            }
            else
            {
                throw new Exception("Member is already exists.");
            }
        }

        public void Update(MemberObject member)
        {
            MemberObject c = GetCarByID(member.MemberID);
            if (c != null)
            {
                var index = MemberList.IndexOf(c);
                MemberList[index] = member;
            }
            else
            {
                throw new Exception("Car does not already exists.");
            }
        }

        //public void Remove(int CarID)
        //{
        //    Car p = GetCarByID(CarID);
        //    if (p != null)
        //    {
        //        CarList.Remove(p);
        //    }
        //    else
        //    {
        //        throw new Exception("Car does not already exists.");
        //    }
        //}

    }
}