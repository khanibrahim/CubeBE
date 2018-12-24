namespace BO.Master
{
    public class Userdetail : Base
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public long PropertyId { get; set; }
        public string RoleName { get; set; }
        public Property Property { get; set; }
    }
}
