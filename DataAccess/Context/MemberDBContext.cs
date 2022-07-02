using AutomobileLibrary.DataAccess;
using BussinessObject;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess.Context
{
    public class MemberDBContext : BaseDAL
    {
        private static MemberDBContext instance = null;
        private static readonly object instanceLock = new object();

        public MemberDBContext() : base()
        {
        }
        public static MemberDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDBContext();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<MemberObject> GetMemberList()
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select member_id, member_name, email, password, city, country, role from Members";
            var members = new List<MemberObject>();
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    members.Add(new MemberObject()
                    {
                        MemberID = dataReader.GetInt32(0),
                        MemberName = dataReader.GetString(1),
                        Email = dataReader.GetString(2),
                        Password = dataReader.GetString(3),
                        City = dataReader.GetString(4),
                        Country = dataReader.GetString(5),
                        Role = dataReader.GetString(6)
                    }); ;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return members;
        }

        public MemberObject GetMemberByID(int memberID)
        {
            MemberObject member = null;
            IDataReader dataReader = null;
            string SQLSelect = "Select member_id, member_name, email, password, city, country, role from Members " +
                "where member_id = @MemberID";
            try
            {
                var param = dataProvider.CreateParameter("@MemberID", 4, memberID, DbType.Int32);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    member = new MemberObject()
                    {
                        MemberID = dataReader.GetInt32(0),
                        MemberName = dataReader.GetString(1),
                        Email = dataReader.GetString(2),
                        Password = dataReader.GetString(3),
                        City = dataReader.GetString(4),
                        Country = dataReader.GetString(5),
                        Role = dataReader.GetString(6)
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return member;
        }

        public void AddNew(MemberObject member)
        {
            try
            {
                if(GetMemberByID(member.MemberID) != null)
                {
                    throw new Exception("Member is already exist");
                }
                if(GetMemberByEmail(member.Email) != null)
                {
                    throw new Exception("Email is already exist");
                }
                string SQLInsert = "Insert Members values (@MemberID, @MemberName, @Email, @Password, @City, @Country, @Role)";
                var parameters = new List<SqlParameter>();
                parameters.Add(dataProvider.CreateParameter("@MemberID", 4, member.MemberID, DbType.Int32));
                parameters.Add(dataProvider.CreateParameter("@MemberName", 500, member.MemberName, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@Email", 100, member.Email, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@Password", 100, member.Password, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@City", 500, member.City, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@Country", 500, member.Country, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@Role", 100, member.Role, DbType.String));
                dataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { CloseConnection(); }
        }

        public void Update(MemberObject member)
        {
            try
            {
                MemberObject c = GetMemberByID(member.MemberID);
                if (c != null)
                {
                    string SQLUpdate = "Update Members set member_name = @MemberName, email = @Email, " +
                        " city = @City, country = @Country where member_id = @MemberID";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@MemberID", 4, member.MemberID, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@MemberName", 500, member.MemberName, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Email", 100, member.Email, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@City", 500, member.City, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Country", 500, member.Country, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Role", 100, member.Role, DbType.String));
                    dataProvider.Update(SQLUpdate, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("Member does not already exist.");
                }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { CloseConnection(); }
        }

        public void Remove(MemberObject member)
        {
            try
            {
                MemberObject c = GetMemberByID(member.MemberID);
                if (c != null)
                {
                    string SQLDelete = "Delete Members where member_id = @MemberID";
                    var param = dataProvider.CreateParameter("@MemberID", 4, member.MemberID, DbType.Int32);
                    dataProvider.Delete(SQLDelete, CommandType.Text, param);
                }
                else
                {
                    throw new Exception("Member does not already exist.");
                }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { CloseConnection(); }
        }

        public MemberObject GetUserByEmailAndPassword(string email, string password)
        {
            IDataReader dataReader = null;
            string SQLCheckLogin = "SELECT member_id, member_name, email, password, city, country, role FROM members " +
                "where email = @Email and password = @Password";
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(dataProvider.CreateParameter("@Email", 100, email, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@Password", 100, password, DbType.String));
                dataReader = dataProvider.GetDataReader(SQLCheckLogin, CommandType.Text, out connection, parameters.ToArray());
                if (dataReader.Read())
                {
                    var member = new MemberObject()
                    {
                        MemberID = dataReader.GetInt32(0),
                        MemberName = dataReader.GetString(1),
                        Email = dataReader.GetString(2),
                        Password = dataReader.GetString(3),
                        City = dataReader.GetString(4),
                        Country = dataReader.GetString(5),
                        Role = dataReader.GetString(6)
                    };
                    return member;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return null;
        }
        public List<MemberObject> getAllMembersFilterByCountryAndCity(string country, string city)
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select member_id, member_name, email, password, city, country, role from Members where country like @Country and city like @City";
            var members = new List<MemberObject>();
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(dataProvider.CreateParameter("@Country", 100, "%"+country+"%", DbType.String));
                parameters.Add(dataProvider.CreateParameter("@City", 100, "%"+city+"%", DbType.String));
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, parameters.ToArray());
                while (dataReader.Read())
                {
                    members.Add(new MemberObject()
                    {
                        MemberID = dataReader.GetInt32(0),
                        MemberName = dataReader.GetString(1),
                        Email = dataReader.GetString(2),
                        Password = "******",//dataReader.GetString(3),
                        City = dataReader.GetString(4),
                        Country = dataReader.GetString(5),
                        Role = dataReader.GetString(6)
                    }); ;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return members;
        }

        public MemberObject GetMemberByEmail(string email)
        {
            MemberObject member = null;
            IDataReader dataReader = null;
            string SQLSelect = "Select member_id, member_name, email, password, city, country, role from Members " +
                "where email = @Email";
            try
            {
                var param = dataProvider.CreateParameter("@Email", 100, email, DbType.String);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    member = new MemberObject()
                    {
                        MemberID = dataReader.GetInt32(0),
                        MemberName = dataReader.GetString(1),
                        Email = dataReader.GetString(2),
                        Password = dataReader.GetString(3),
                        City = dataReader.GetString(4),
                        Country = dataReader.GetString(5),
                        Role = dataReader.GetString(6)
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return member;
        }    
    }
}
