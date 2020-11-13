<Query Kind="Program">
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
    var url = "https://maps.googleapis.com/maps/api/staticmap?markers=52.459703,-1.860283&size=190x125&zoom=12&key=AIzaSyAg5lwS3ugdAVGf5gdgNvLe_0-7XcMICIM";
    GetKey(url, "_rVus3ObLa1JnQQCjdLg1mLwDZE=").Dump();
}


string GetKey(string url, string keyString)
{
    ASCIIEncoding encoding = new ASCIIEncoding();

    // converting key to bytes will throw an exception, need to replace '-' and '_' characters first.
    string usablePrivateKey = keyString.Replace("-", "+").Replace("_", "/");
    byte[] privateKeyBytes = Convert.FromBase64String(usablePrivateKey);

    Uri uri = new Uri(url);
    byte[] encodedPathAndQueryBytes = encoding.GetBytes(uri.LocalPath + uri.Query);

    // compute the hash
    HMACSHA1 algorithm = new HMACSHA1(privateKeyBytes);
    byte[] hash = algorithm.ComputeHash(encodedPathAndQueryBytes);

    // convert the bytes to string and make url-safe by replacing '+' and '/' characters
    string signature = Convert.ToBase64String(hash).Replace("+", "-").Replace("/", "_");

    // Add the signature to the existing URI.
    return uri.Scheme + "://" + uri.Host + uri.LocalPath + uri.Query + "&signature=" + signature;
}

