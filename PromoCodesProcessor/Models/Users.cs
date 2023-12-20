namespace PromoCodesProcessor.Models
{
    public class Users
    {
        private List<Users> _usersList;

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        // Could be used to auto-create sample users.
        public Users()
        {
            _usersList = new List<Users>()
            {
                new Users()
                {
                    Id = 1,
                    Name = "Jayant Varma",
                    Email = "jayant@promos.com",
                    Password = "Jayant123#"
                },
                new Users()
                {
                    Id = 2,
                    Name = "Rahul Singh",
                    Email = "rahul@promos.com",
                    Password = "Rahul123#"
                },
                new Users()
                {
                    Id = 3,
                    Name = "Agha Sameer",
                    Email = "agha@promos.com",
                    Password = "Agha123#"
                }
            };
        }

        public class Users_Data
        {

            public required int user_id { get; set; }

            public required string user_name { get; set; } = string.Empty;

        }

        public IEnumerable<Users> getUsers()
        {
            return _usersList;
        }
    }
}
