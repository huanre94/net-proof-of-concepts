// See https://aka.ms/new-console-template for more information
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

for (int i = 0; i < 5; i++)
{
    Console.WriteLine(GenerateSalt().ToString());
}


static byte[] GenerateSalt()
{
    //using var rng = new RNGCryptoServiceProvider();
    //var rng2 = RandomNumberGenerator.GetInt32(10);
    byte[] salt = new byte[16]; // Adjust the size based on your security requirements
    RandomNumberGenerator.Create().GetBytes(salt);
    //rng.GetBytes(salt);
    return salt;
}


static string HashPassword(string password, byte[] salt)
{
    using (var sha256 = SHA256.Create())
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];

        // Concatenate password and salt
        Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
        Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

        // Hash the concatenated password and salt
        byte[] hashedBytes = sha256.ComputeHash(saltedPassword);

        // Concatenate the salt and hashed password for storage
        byte[] hashedPasswordWithSalt = new byte[hashedBytes.Length + salt.Length];
        Buffer.BlockCopy(salt, 0, hashedPasswordWithSalt, 0, salt.Length);
        Buffer.BlockCopy(hashedBytes, 0, hashedPasswordWithSalt, salt.Length, hashedBytes.Length);

        return Convert.ToBase64String(hashedPasswordWithSalt);
    }
}

static string JwtGenerate()
{
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key_here"));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken(
        issuer: "your_issuer",
        audience: "your_audience",
        expires: DateTime.Now.AddMinutes(30),
        signingCredentials: creds
    );
    return new JwtSecurityTokenHandler().WriteToken(token);
}
