using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLibrary
{
    public class UserService
    {
        struct UserEntity
        {
            internal int Id { get; }
            internal User User { get; }
            public UserEntity(int id, User user)
            {
                Id = id;
                User = user;
            }
        }
        private readonly List<UserEntity> userEntities = new List<UserEntity>();

        public void Add(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            int newId = 1; // TODO: generate new id!
            userEntities.Add(new UserEntity(newId, user));
            //return newId;
        }

        public void Delete(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            userEntities.RemoveAll(x => x.User.Equals(user));
        }

        public IEnumerable<User> Search(params Predicate<User>[] predicates)
        {
            if (predicates == null) throw new ArgumentNullException(nameof(predicates));

            if (!userEntities.Any())
                return null;
            if (!predicates.Any())
                return userEntities.Select(userEntity => userEntity.User);
            var commonPredicate = predicates[0];
            if (predicates.Length > 1)
                foreach (var predicate in predicates)
                    commonPredicate += predicate;
            var foundEntities = userEntities.Where(x => commonPredicate(x.User));
            var entities = foundEntities as IList<UserEntity> ?? foundEntities.ToList();
            return entities.Any() ? entities.Select(userEntity=>userEntity.User) : null;
        }

    }
}
