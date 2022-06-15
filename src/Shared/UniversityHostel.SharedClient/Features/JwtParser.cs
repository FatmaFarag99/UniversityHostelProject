namespace UniversityHostel.SharedClient;

public static class JwtParser
{
    public static IEnumerable<Claim> ExtractClaimsFromJwt(string jwt)
    {
        List<Claim> claims = new List<Claim>();
        string payload = jwt.Split(".")[1];

        byte[] jsonBytes = ParseBase64WithoutPadding(payload);

        Dictionary<string, object> KeyValuePairs = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        ExtractRolesFromJWT(claims, KeyValuePairs);

        claims.AddRange(KeyValuePairs.Select(e => new Claim(e.Key, e.Value.ToString())));

        return claims;
    }
    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "==";
                break;
            case 3: base64 += "=";
                break;
        }
        return Convert.FromBase64String(base64);
    }
    private static void ExtractRolesFromJWT(List<Claim> claims, Dictionary<string, object> keyValuePairs)
    {
        keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);
        if (roles != null)
        {
            var parsedRoles = roles.ToString().Trim().TrimStart('[').TrimEnd(']').Split(',');
            if (parsedRoles.Length > 1)
            {
                foreach (var parsedRole in parsedRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, parsedRole.Trim('"')));
                }
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, parsedRoles[0]));
            }
            keyValuePairs.Remove(ClaimTypes.Role);
        }
    }
}
