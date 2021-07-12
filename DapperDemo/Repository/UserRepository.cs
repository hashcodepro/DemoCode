using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Npgsql;

namespace DapperDemo
{
    public class UserRepository
    {
        private readonly NpgsqlConnection _db;

        public UserRepository(string connectionString)
        {
            _db = new NpgsqlConnection(connectionString);
        }

        public List<User> GetAll()
        {
            return _db.Query<User>("Select * from Users").ToList();
        }

        public void Insert(User newUser)
        {
            string sql = @"insert into Users(email,firstName,lastName)
                        values(@email,@firstName,@lastName)";

            int result = _db.Execute(sql, newUser);

            if (result < 1)
                throw new Exception("No row was inserted into the table.");
            Console.WriteLine($"{result} row inserted successfully...");
        }

        public User GetById(int id)
        {
            string sql = @"select * from Users where Id = @id";

            return _db.Query<User>(sql, new { id }).Single();
        }

        public List<User> OneToManyInnerJoin()
        {
            string sql = @"select * 
                            from Users u
                            inner join Address a
                            on u.user_id = a.user_id";

            List<User> users = _db.Query<User, Address, User>(sql,
                                (user, address) =>
                                {
                                    user.Address = new List<Address>() { address };
                                    return user;
                                },
                                splitOn: "Address_Id").ToList();

            List<User> result = users
                                .GroupBy(u => u.User_Id)
                                .Select(g =>
                                {
                                    User groupedUser = g.First();
                                    groupedUser.Address = g.Select(a => a.Address.Single()).ToList();

                                    return groupedUser;
                                }).ToList();

            return result;
        }
        public List<User> OneToManyLeftJoin()
        {
            string sql = @"select * 
                            from Users u
                            left join Address a
                            on u.user_id = a.user_id";

            List<User> users = _db.Query<User, Address, User>(sql,
                                (user, address) =>
                                {
                                    user.Address = new List<Address>() { address };
                                    return user;
                                },
                                splitOn: "Address_Id").ToList();

            List<User> result = users
                                .GroupBy(u => u.User_Id)
                                .Select(g =>
                                {
                                    User groupedUser = g.First();
                                    groupedUser.Address = g.Select(a => a.Address.Single()).ToList();

                                    return groupedUser;
                                }).ToList();

            return result;
        }

        public List<User> ManyToManyInnerJoin()
        {
            string sql = @"select u.*,c.*
                            from Users u
                            inner join UserCommunity uc on uc.user_id = u.user_id
                            inner join Community c on c.community_id = uc.community_id;";

            List<User> users = _db.Query<User, Community, User>(sql,
                                (user, community) =>
                                {
                                    user.Community = new List<Community> { community };
                                    return user;
                                }, splitOn: "Community_Id").ToList();

            List<User> result = users
                                .GroupBy(u => u.User_Id)
                                .Select(g =>
                                {
                                    User groupedUser = g.First();
                                    groupedUser.Community = g.Select(c => c.Community.Single()).ToList();

                                    return groupedUser;
                                }).ToList();
            return result;
        }

        public List<User> MultipleRelationshipInnerAndLeftJoin()
        {
            string sql = @"select u.*,c.*,a.*
                    from Users u
                    inner join UserCommunity uc on uc.user_id = u.user_id
                    inner join Community c on c.community_id = uc.community_id
                    left join Address a on a.user_id = u.user_id;";

            List<User> users = _db.Query<User, Community, Address, User>(sql,
                    (user, community, address) =>
                    {
                        user.Community = new List<Community> { community };
                        user.Address = new List<Address> { address };
                        return user;
                    }, splitOn: "Community_id, Address_id").ToList();

            List<User> result = users
                    .GroupBy(u => u.User_Id)
                    .Select(g =>
                    {
                        User groupedUser = g.First();
                        groupedUser.Community = g.Select(c => c.Community.Single()).ToList();
                        groupedUser.Address = g.Select(a => a.Address.Single()).ToList();

                        groupedUser.Community = groupedUser.Community.Distinct().ToList();
                        groupedUser.Address = groupedUser.Address.Distinct().ToList();                        

                        return groupedUser;
                    }).ToList();

                    

            return result;
        }
    }
}