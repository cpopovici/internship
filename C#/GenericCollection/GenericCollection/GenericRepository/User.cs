using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollection.GenericRepository
{
    class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public User(int id, string name, string lastname)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastname;
        }

        public override string ToString()
        {
            return String.Format($"  Id: {Id}, Name: {Name} {LastName}");
        }
    }

    class UserRepository : IRepository<User>
    {
        private List<User> userList;

        public IEnumerable<User> List
        {
            get
            {
                return userList;
            }
        }

        public UserRepository()
        {
            userList = new List<User>();
        }

        public void Add(User entity)
        {
            userList.Add(entity);
            Console.WriteLine($"{entity} Added to DB (to list)!");
        }

        public void Delete(User entity)
        {
            userList.Remove(entity);
            Console.WriteLine($"{entity} Deleted from DB (from list)!");
        }

        public User FindById(int Id)
        {
            return userList.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Update(User entity)
        {
            var user = userList.Where(x => x.Id == entity.Id).FirstOrDefault();
            if (user != null)
            {
                user.Name = entity.Name;
                user.LastName = entity.LastName;
            }
        }
    }
}
