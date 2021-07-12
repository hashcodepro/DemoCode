using System;
using System.Collections.Generic;

namespace DapperDemo
{
    class Config
    {
        public const string ConnectionString = "User ID=postgres;Password=1234;Host=localhost;Port=5432;Database=postgres";
    }
    class Program
    {
        static void Main(string[] args)
        {
            // getAll();
            // insert();
            // getById();
            // OneToManyInnerJoin();
            // OneToManyLeftJoin();
            // ManyToManyInnerJoin();
            MultipleRelationshipInnerAndLeftJoin();
        }

        public static void getAll()
        {
            UserRepository userRepo = new UserRepository(Config.ConnectionString);

            List<User> result = userRepo.GetAll();

            result.FormatOutput();
        }

        public static void insert()
        {
            UserRepository userRepo = new UserRepository(Config.ConnectionString);

            User newUser = new User
            {
                Email = "bobo@gmail.com",
                FirstName = "Bobo",
                LastName = "Jon"
            };

            userRepo.Insert(newUser);
        }

        public static void getById()
        {
            UserRepository userRepo = new UserRepository(Config.ConnectionString);

            User result = userRepo.GetById(5);

            result.FormatOutput();
        }

        public static void OneToManyInnerJoin()
        {
            UserRepository userRepo = new UserRepository(Config.ConnectionString);

            List<User> result = userRepo.OneToManyInnerJoin();

            result.FormatOutput();
        }

        public static void OneToManyLeftJoin()
        {
            UserRepository userRepo = new UserRepository(Config.ConnectionString);

            List<User> result = userRepo.OneToManyLeftJoin();

            result.FormatOutput();
        }

        public static void ManyToManyInnerJoin()
        {
            UserRepository userRepo = new UserRepository(Config.ConnectionString);

            List<User> result = userRepo.ManyToManyInnerJoin();

            result.FormatOutput();
        }

        public static void MultipleRelationshipInnerAndLeftJoin()
        {
            UserRepository userRepo = new UserRepository(Config.ConnectionString);

            List<User> result = userRepo.MultipleRelationshipInnerAndLeftJoin();

            result.FormatOutput();
        }
    }
}
