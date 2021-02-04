namespace System.IdentityModel.Tokens
{
    internal class JwtSecurityToken
    {
        private string stream;

        public JwtSecurityToken(string stream)
        {
            this.stream = stream;
        }
    }
}